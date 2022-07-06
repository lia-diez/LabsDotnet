namespace Lab3;

public abstract class DeckFactory
{
    public abstract Deck Create();
}

public class ArrayDeckFactory : DeckFactory
{
    public override Deck Create()
    {
        return new ArrayDeck();
    }
}

public class LinkedListDeckFactory : DeckFactory
{
    public override Deck Create()
    {
        return new LinkedListDeck();
    }
}