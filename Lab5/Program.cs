using Lab4;

var terminal = new Terminal();
var coinAcceptor = new CoinHandler();
var banknoteAcceptor = new BanknoteHandler();

terminal.HandlerChainHead = banknoteAcceptor;
banknoteAcceptor.Next = coinAcceptor;

var coin = new Coin(25);
var coin2 = new Coin(50);
var banknote = new Banknote(10);
var banknote2 = new Banknote(10);

terminal.AddMoney(coin);
terminal.AddMoney(coin2);
terminal.AddMoney(banknote);
terminal.AddMoney(banknote);
terminal.AddMoney(banknote2);

Console.WriteLine("Terminal value:");
Console.WriteLine(terminal.Value);

Console.WriteLine("\nTerminal history:");
Console.WriteLine(terminal.GetHistory());