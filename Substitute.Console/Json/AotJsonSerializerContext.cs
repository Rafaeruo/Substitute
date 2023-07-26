using System.Text.Json.Serialization;

namespace Substitute.Console.Json;

[JsonSerializable(typeof(Settings.Settings))]
public partial class AotJsonSerializerContext : JsonSerializerContext
{
}
