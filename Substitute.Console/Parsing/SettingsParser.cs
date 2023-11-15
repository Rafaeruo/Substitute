using Substitute.Console.Json;
using System.Text.Json;

namespace Substitute.Console.Parsing;

public class SettingsParser
{
    private const string PATH = "./configuration.json";
    
    public async Task<Settings.Settings> Parse()
    {
        var file = File.OpenRead(PATH);
        var configuration = await JsonSerializer.DeserializeAsync(file, AotJsonSerializerContext.Default.Settings);

        // TODO handle parsing errors and check result for null values.

        return configuration;
    }
}

