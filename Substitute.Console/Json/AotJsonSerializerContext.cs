using System.Text.Json.Serialization;

namespace Substitute.Console.Json;

[JsonSerializable(typeof(Settings.Settings))]
[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    ReadCommentHandling = System.Text.Json.JsonCommentHandling.Skip)]
public partial class AotJsonSerializerContext : JsonSerializerContext
{
}
