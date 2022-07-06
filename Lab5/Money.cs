namespace Lab4;

public abstract class Money
{
    public int Value { get; }
    public abstract string Symbol { get; }

    public Money(int value)
    {
        Value = value;
    }
}