using System.Data;
using System.Diagnostics;

namespace Lab3;

public class Card

{
    public Value Value { get; set; }
    public Suit Suit { get; set; }

    public Card(Value value, Suit suit)
    {
        Value = value;
        Suit = suit;
    }
    
    public override string ToString()
    {
        var value = Value switch
        {
            Value.Ace => "A",
            Value.Jack => "J",
            Value.Queen => "Q",
            Value.King => "K",
            _ => ((int)Value).ToString()
        };
        
        var suit = Suit switch
        {
            Suit.Clubs => "♣",
            Suit.Diamonds => "♦",
            Suit.Hearts => "♥",
            Suit.Spades => "♠"
        };

        return value + suit;
    }
}