using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
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
            var stringDict = JsonSerializer.Deserialize<Dictionary<string, string>>(
                iconJsonStream, IconJsonContext.Default.DictionaryStringString) 
                             ?? new Dictionary<string, string>();

            var result = new Dictionary<TEnum, string>(stringDict.Count);
            foreach (var kvp in stringDict)
            {
                if (Enum.TryParse<TEnum>(kvp.Key, out var enumKey))
                {
                    result[enumKey] = kvp.Value;
                }
            }

            return result;
        }
    }
}