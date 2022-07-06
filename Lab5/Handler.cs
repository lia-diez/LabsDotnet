namespace Lab4;

public abstract class Handler
{
    public abstract void Handle(Terminal terminal, Money money);
    public Handler? Next { get; set; }
}

public class BanknoteHandler : Handler
{
    public override void Handle(Terminal terminal, Money money)
    {
        if (money is Banknote)
        {
            terminal.Value += money.Value;
        }
        else if (Next != null)
        {
            Next.Handle(terminal, money);
        }
    }
}

public class CoinHandler : Handler
{
    public override void Handle(Terminal terminal, Money money)
    {
        if (money is Coin)
        {
            terminal.Value += money.Value / 100f;
        }
        else if (Next != null)
        {
            Next.Handle(terminal, money);
        }
    }
}
