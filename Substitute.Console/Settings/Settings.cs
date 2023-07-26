namespace Substitute.Console.Settings;

public class Settings
{
    public IEnumerable<Profile> Profiles { get; set; } = Enumerable.Empty<Profile>();
}
