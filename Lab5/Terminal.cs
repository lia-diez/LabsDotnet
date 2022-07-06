using System.Diagnostics;

namespace Lab4;

public class Terminal
{
    public Handler? HandlerChainHead { get; set; }
    public float Value { get; set; }
    public List<Money> PaymentHistory { get; set; }

    public Terminal()
    {
        PaymentHistory = new List<Money>();
    }
    
    public void AddMoney(Money money)
    {
        PaymentHistory.Add(money);
        HandlerChainHead?.Handle(this, money);
    }

    public string GetHistory()
    {
        var history = PaymentHistory
            .GroupBy(a => (a.Value, a.Symbol))
            .Select(b =>
                $"{b.Key.Value}" +
                $"{b.Key.Symbol} : " +
                $"{b.Count()}");
        return string.Join("\n", history);
    }
    
}