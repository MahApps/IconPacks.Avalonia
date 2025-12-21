#nullable enable
using System;
using System.Collections.Generic;
using Avalonia.Media;

namespace IconPacks.Avalonia.Core;

public static class PackIconGeometryCache
{
    /// <summary>
    /// Gets or sets the maximum number of icons to cache.
    /// </summary>
    public static int CacheSize
    {
        get => field;
        set
        {
            field = value;
            TrimUnsafe(field);
        }
    } = 100;
    
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

    public static StreamGeometry? GetOrAdd(Enum kind)
    {
        var capacity = CacheSize;
        string? path;
        
        if (capacity <= 0)
            return PackIconDataIndex.TryGetPath(kind, out path) ? 
                CreateGeometry(path) : null;

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
        PackIconDataIndex.TryGetPath(kind, out path);
        var created = CreateGeometry(path);
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

    private static StreamGeometry? CreateGeometry(string? data)
    {
        return data is null || string.IsNullOrWhiteSpace(data) 
            ? null 
            : StreamGeometry.Parse(data);
    }

    private static void TrimUnsafe(int capacity)
    {
        lock (_Gate)
        {
            while (_Map.Count > capacity && _Lru.Last is not null)
            {
                var last = _Lru.Last;
                _Lru.RemoveLast();
                _Map.Remove(last.Value.Key);
            }
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