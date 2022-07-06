using lab4.TextManipulation.TextSources;

namespace lab4.TextManipulation.TextMutators;

public abstract class TextMutator : TextSource
{
    public TextMutator(string mutated) : base(mutated)
    {
    }
    
}