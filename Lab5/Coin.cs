namespace Lab4;

public class Coin : Money
{
    public Coin(int value) : base(value)
    {
    }

    public override string Symbol => "¢";
}