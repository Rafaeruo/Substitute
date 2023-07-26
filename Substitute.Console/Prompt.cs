using Substitute.Console.Parsing;
using Substitute.Console.Settings;
using Substitute.Console.Replacers;
using Substitute.Console.Files;
using PrompOptions = Sharprompt.Prompt;
using Sharprompt;

namespace Substitute.Console;

public class Prompt
{
    public async Task Run()
    {
        var profile = await GetProfile();
        System.Console.WriteLine("Using profile " + profile.Name);

        foreach (var fileDefinition in profile.Files)
        {
            if (fileDefinition.Optional && PromptForWetherToSkip(fileDefinition.Name))
            {
                continue;
            }

            foreach (var path in fileDefinition.Paths)
            {
                using var file = FileHandler.Open(path);

                // TODO support file types other than JSON, such as XML.
                var result = await new JsonReplacer().Replace(file, fileDefinition);

                if (result is null)
                {
                    continue;
                }

                await FileHandler.Save(file, result);
            }
        }
    }

    public async Task<Profile> GetProfile()
    {
        var settings = await new SettingsParser().Parse();

        return PromptForProfile(settings.Profiles);
    }

    private bool PromptForWetherToSkip(string name)
    {
        return PrompOptions.Confirm($"File \"{name}\" is marked as optional. Would you like to skip it?");
    }

    private Profile PromptForProfile(IEnumerable<Profile> profiles)
    {
        // TODO handle invalid profile count (less than one).

        if (profiles.Count() == 1)
        {
            return profiles.First();
        }

        var options = new SelectOptions<Profile>()
        {
            Items = profiles,
            Message = "Choose a profile",
            TextSelector = (profile) => profile.Name
        };
        var profileNames = profiles.Select(profile => profile.Name);
        return PrompOptions.Select(options);
    }
}
