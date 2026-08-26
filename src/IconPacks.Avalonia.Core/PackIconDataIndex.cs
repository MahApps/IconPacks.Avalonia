#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IconPacks.Avalonia.Core;

public static class PackIconDataIndex
{
    private static readonly object Gate = new();
    private static readonly Dictionary<Type, ReadOnlyDictionary<Enum, string>> Packs = new();

    public static ReadOnlyDictionary<Enum, string> Register(Type enumType, IDictionary<Enum, string>? icons = null)
    {
        lock (Gate)
        {
            if (!Packs.TryGetValue(enumType, out ReadOnlyDictionary<Enum, string>? value))
            {
                // Convert IDictionary<TKind, string> to IDictionary<Enum, string>
                var src = icons ?? PackIconDataFactory.Create(enumType);
                var dst = new Dictionary<Enum, string>(src.Count);
                foreach (var kv in src)
                {
                    dst[kv.Key] = kv.Value; // box TKind to Enum
                }

                value = new ReadOnlyDictionary<Enum, string>(dst);
                Packs[enumType] = value;
            }
            return value;
        }
    }

    public static bool TryGetPath(Enum kind, out string? path)
    {
        var type = kind.GetType();
        ReadOnlyDictionary<Enum, string>? packDictionary;
        lock (Gate)
        {
            if (!Packs.TryGetValue(type, out packDictionary))
            {
                packDictionary = Register(kind.GetType());
            }
        }
        
        return packDictionary.TryGetValue(kind, out path);
    }
}