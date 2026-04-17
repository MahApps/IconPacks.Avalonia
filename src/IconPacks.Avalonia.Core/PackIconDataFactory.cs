using System;
using System.Collections.Generic;
using System.Text.Json;
using Avalonia.Platform;

namespace IconPacks.Avalonia.Core
{
    public static class PackIconDataFactory
    {
        public static IDictionary<TEnum, string> Create<TEnum>() where TEnum : struct, Enum
        {
            using var iconJsonStream = AssetLoader.Open(new Uri($"avares://{typeof(TEnum).Assembly.GetName().Name}/Resources/Icons.json"));
            var stringDict = JsonSerializer.Deserialize(
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
        
        public static IDictionary<Enum, string> Create(Type enumType)
        {
            using var iconJsonStream = AssetLoader.Open(new Uri($"avares://{enumType.Assembly.GetName().Name}/Resources/Icons.json"));
            var stringDict = JsonSerializer.Deserialize<Dictionary<string, string>>(
                                 iconJsonStream, IconJsonContext.Default.DictionaryStringString) 
                             ?? new Dictionary<string, string>();

            var result = new Dictionary<Enum, string>(stringDict.Count);
            foreach (var kvp in stringDict)
            {
                try
                {
                    var enumKey = Enum.Parse(enumType, kvp.Key);
                    result[(Enum)enumKey] = kvp.Value;
                }
                catch
                {
                    // ignored
                }
            }

            return result;
        }
    }
}