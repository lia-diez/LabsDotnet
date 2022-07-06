using lab4.TextManipulation.TextSources;

namespace lab4.TextManipulation.TextMutators;

public class TranslatedText : TextMutator
{
    public TranslatedText(TextSource source, string lang) : base(Translate(source.Value, lang))
    {
        
    }

    public static string Translate(string text, string language)
    {
        return Translator.Translate(text, language);
    }
}

public static class TranslateExtension
{
    public static TranslatedText Translate(this TextSource src, string lang)
    {
        return new TranslatedText(src, lang);
    }
}
