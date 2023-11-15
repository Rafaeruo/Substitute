using System.Text.Json.Serialization;

namespace Substitute.Console.Json;

[JsonSerializable(typeof(Settings.Settings))]
[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
public partial class AotJsonSerializerContext : JsonSerializerContext
{
}
