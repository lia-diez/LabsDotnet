namespace Lab4;

public class Banknote : Money
{
    public Banknote(int value) : base(value)
    {
    }

    public override string Symbol => "$";
}