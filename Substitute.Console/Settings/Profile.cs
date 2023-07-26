namespace Substitute.Console.Settings;

public class Profile
{
    public string Name { get; set; } = "";
    public IEnumerable<FileDefinition> Files { get; set; } = Enumerable.Empty<FileDefinition>();
}
