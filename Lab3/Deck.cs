namespace Lab3;

public abstract class Deck
{
    protected ICollection<Card> _cards;

    public void AddCard(Card card)
    {
        _cards.Add(card);
    }

    public override string ToString()
    {
        return string.Join(' ', _cards);
    }
}

public class ArrayDeck : Deck
{
    public override string ToString()
    {
        return "Array-based deck: " + base.ToString();
    }

    public ArrayDeck()
    {
        _cards = new List<Card>();
    }
    
}

public class LinkedListDeck : Deck
{
    
    public LinkedListDeck()
    {
        _cards = new LinkedList<Card>();
    }
    
    public override string ToString()
    {
        return "LinkedList-based deck: " + base.ToString();
    }

}