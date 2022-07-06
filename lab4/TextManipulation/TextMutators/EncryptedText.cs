using lab4.TextManipulation.TextSources;

namespace lab4.TextManipulation.TextMutators;

public class EncryptedText : TextMutator
{
    public EncryptedText(TextSource source, bool encrypt) 
        : base(Transform(source.Value, encrypt))
    {
        
    }

    private static string Transform(string text, bool encrypt)
    {
        if (encrypt)
        {
            var textBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textBytes);
        }
        var base64Bytes = Convert.FromBase64String(text);
        return System.Text.Encoding.UTF8.GetString(base64Bytes);
    }
}

public static class EncryptionExtension
{
    public static EncryptedText Encrypt(this TextSource src)
    {
        return new EncryptedText(src, true);
    }
    
    public static EncryptedText Decrypt(this TextSource src)
    {
        return new EncryptedText(src, false);
    }
}