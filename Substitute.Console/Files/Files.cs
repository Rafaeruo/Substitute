using System.Text;

namespace Substitute.Console.Files;

public static class FileHandler
{
    public static FileStream Open(string path)
    {
        return File.Open(path, FileMode.Open, FileAccess.ReadWrite);
    }

    public static async Task Save(FileStream file, string result)
    {
        file.Seek(0, SeekOrigin.Begin);

        var newFileContent = Encoding.UTF8.GetBytes(result);
        await file.WriteAsync(newFileContent);
        file.SetLength(newFileContent.Length);
    }
}
