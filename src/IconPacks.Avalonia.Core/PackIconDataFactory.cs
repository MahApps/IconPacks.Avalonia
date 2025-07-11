﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Avalonia.Platform;

namespace IconPacks.Avalonia.Core
{
    public static class PackIconDataFactory<TEnum> where TEnum : struct, Enum
    {
        public static Lazy<ReadOnlyDictionary<TEnum, string>> DataIndex { get; }

        static PackIconDataFactory()
        {
            DataIndex = new Lazy<ReadOnlyDictionary<TEnum, string>>(() => new ReadOnlyDictionary<TEnum, string>(Create()));
        }

        public static IDictionary<TEnum, string> Create()
        {
            using var iconJsonStream = AssetLoader.Open(new Uri($"avares://{typeof(TEnum).Assembly.GetName().Name}/Resources/Icons.json"));
#pragma warning disable IL2026
            var options = new JsonSerializerOptions
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver()
            };
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<TEnum, string>>(iconJsonStream, options) ?? [];
#pragma warning restore IL2026
        }
    }
}