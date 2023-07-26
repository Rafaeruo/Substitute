using System.Text;

namespace Substitute.Console.Files;

public static class FileHandler
{
    public static FileStream Open(string path)
    {
        return File.Open(path, FileMode.Open, FileAccess.ReadWrite);
    }

    internal static void Save(FileStream file, string result)
    {
        file.Position = 0;
        file.Write(Encoding.UTF8.GetBytes(result));
    }
}
