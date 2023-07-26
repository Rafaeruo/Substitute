using Substitute.Console.Json;
using System.Text.Json;

namespace Substitute.Console.Parsing;

public class SettingsParser
{
    private const string PATH = "./configuration.json";
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("AOT", "IL3050:Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.", Justification = "<Pending>")]
    public async Task<Settings.Settings> Parse()
    {
        var file = File.OpenRead(PATH);
        var configuration = await JsonSerializer.DeserializeAsync<Settings.Settings>(file, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            TypeInfoResolver = new AotJsonSerializerContext()
        });

        // TODO handle parsing errors and check result for null values.

        return configuration;
    }
}

