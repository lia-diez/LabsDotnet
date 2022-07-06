namespace lab4.TextManipulation.TextSources;

public class FileTextSource : TextSource
{
    public FileTextSource(string path) : base(GetValue(path))
    {
    }

    private static string GetValue(string path)
    {
        using (var streamReader = new StreamReader(File.Open(path, FileMode.Open)))
        {
            var value = streamReader.ReadToEnd();
            return value;
        }
    }
}