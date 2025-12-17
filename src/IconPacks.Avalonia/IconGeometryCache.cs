#nullable enable
using System;
using System.Collections.Generic;
using Avalonia.Media;

namespace IconPacks.Avalonia;

internal static class IconGeometryCache
{
    private sealed class Entry
    {
        public Enum Key { get; }
        public StreamGeometry Geometry { get; }

        public Entry(Enum key, StreamGeometry geometry)
        {
            Key = key;
            Geometry = geometry;
        }
    }

    private static readonly object _Gate = new();
    private static readonly Dictionary<Enum, LinkedListNode<Entry>> _Map = new();
    private static readonly LinkedList<Entry> _Lru = new();

    public static StreamGeometry? GetOrAdd(Enum kind, Func<string?> getPathData)
    {
        var capacity = PackIconControl.GeometryCache;
        
        if (capacity <= 0)
            return CreateGeometry(getPathData);

        // Fast path: try hit
        lock (_Gate)
        {
            if (_Map.TryGetValue(kind, out var node))
            {
                _Lru.Remove(node);
                _Lru.AddFirst(node);
                return node.Value.Geometry;
            }
        }

        // Parse outside lock (parsing can be expensive)
        var created = CreateGeometry(getPathData);
        if (created is null)
            return null;

        lock (_Gate)
        {
            // Re-check in case it was added while we parsed
            if (_Map.TryGetValue(kind, out var existing))
            {
                _Lru.Remove(existing);
                _Lru.AddFirst(existing);
                return existing.Value.Geometry;
            }

            var newNode = new LinkedListNode<Entry>(new Entry(kind, created));
            _Lru.AddFirst(newNode);
            _Map[kind] = newNode;

            TrimUnsafe(capacity);
            return created;
        }
    }

    private static StreamGeometry? CreateGeometry(Func<string?> getPathData)
    {
        var data = getPathData();
        if (string.IsNullOrWhiteSpace(data))
            return null;

        return StreamGeometry.Parse(data);
    }

    private static void TrimUnsafe(int capacity)
    {
        while (_Map.Count > capacity && _Lru.Last is not null)
        {
            var last = _Lru.Last;
            _Lru.RemoveLast();
            _Map.Remove(last.Value.Key);
        }
    }

    public static void Clear()
    {
        lock (_Gate)
        {
            _Map.Clear();
            _Lru.Clear();
        }
    }
}