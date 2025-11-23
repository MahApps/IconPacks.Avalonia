using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia.Platform;

namespace IconPacks.Avalonia.Core
{
    [JsonSerializable(typeof(Dictionary<string, string>))]
    internal sealed partial class EnumDictionaryGenerationContext : JsonSerializerContext;

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
            var stringDictionary = System.Text.Json.JsonSerializer.Deserialize(iconJsonStream, EnumDictionaryGenerationContext.Default.DictionaryStringString) ?? [];
#if NETSTANDARD2_0
            return stringDictionary.ToDictionary(kvp => (TEnum)Enum.Parse(typeof(TEnum), kvp.Key), kvp => kvp.Value);
#else
            return stringDictionary.ToDictionary(kvp => Enum.Parse<TEnum>(kvp.Key), kvp => kvp.Value);
#endif

        }
    }
}