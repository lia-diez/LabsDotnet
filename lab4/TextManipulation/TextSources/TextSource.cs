namespace lab4.TextManipulation.TextSources;

public abstract class TextSource
{
    public string Value { get; protected set; }

    public TextSource(string value)
    {
        Value = value;
    }
    
    public TextSource SaveToFile(string path)
    {
        using (StreamWriter streamWriter = new StreamWriter(File.Open(path, FileMode.Append)))
        {
           streamWriter.WriteLine(Value);
        }
        return this;
    }

    public override string ToString()
    {
        return Value;
    }
}