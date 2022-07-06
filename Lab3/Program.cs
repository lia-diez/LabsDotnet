using Lab3;

var card1 = new Card(Value.Nine, Suit.Clubs);
var card2 = new Card(Value.Ace, Suit.Diamonds);
var card3 = new Card(Value.Eight, Suit.Clubs);
var card4 = new Card(Value.King, Suit.Hearts);
var card5 = new Card(Value.Five, Suit.Spades);

Deck deck;
DeckFactory factory;

factory = new ArrayDeckFactory();
deck = factory.Create();
deck.AddCard(card1);
deck.AddCard(card2);
deck.AddCard(card3);
Console.WriteLine(deck);

factory = new LinkedListDeckFactory();
deck = factory.Create();
deck.AddCard(card4);
deck.AddCard(card5);
Console.WriteLine(deck);