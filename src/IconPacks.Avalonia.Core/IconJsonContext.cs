using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IconPacks.Avalonia.Core;

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Metadata, // works for trimming; use Serialization for NativeAOT if you want write support too
    PropertyNamingPolicy = JsonKnownNamingPolicy.Unspecified,
    PropertyNameCaseInsensitive = true
)]
[JsonSerializable(typeof(Dictionary<string, string>))]
internal partial class IconJsonContext : JsonSerializerContext
{
}