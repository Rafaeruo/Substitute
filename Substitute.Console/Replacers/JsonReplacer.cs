using System.Text.Json.Nodes;
using System.Text.Json;
using Substitute.Console.Settings;

namespace Substitute.Console.Replacers
{
    public class JsonReplacer
    {
        public Task<string?> Replace(FileStream file, FileDefinition fileDefinition)
        {
            var document = JsonNode.Parse(file, null, new JsonDocumentOptions
            {
                CommentHandling = JsonCommentHandling.Skip
            })?.AsObject();

            if (document is null)
            {
                return Task.FromResult<string?>(null);
            }

            FillObject(document, fileDefinition.Values);

            var result = document.ToJsonString(new JsonSerializerOptions { WriteIndented = true });
            return Task.FromResult<string?>(result);
        }

        private void FillObject(JsonObject? document, JsonElement values)
        {
            if (document is null)
            {
                return;
            }

            foreach (var property in values.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Object)
                {
                    FillObject(document[property.Name]?.AsObject(), property.Value);
                    continue;
                }

                document[property.Name] = JsonNode.Parse(property.Value.GetRawText());
            }
        }
    }
}
