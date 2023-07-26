using System.Text.Json;

namespace Substitute.Console.Settings;

public class FileDefinition
{
    public string Name { get; set; } = "";
    public JsonElement Values { get; set; } = new JsonElement();
    public IEnumerable<string> Paths { get; set; } = Enumerable.Empty<string>();
    public bool Optional { get; set; } = false;
}
