
public static class Desire
{
    public static int NumberOfWishes { get; set; } = 0;
    public static string[] Wishes { get; } = new string[3];
    public static bool[] GrandmotherStatus { get; } = new bool[3];
}

public class Gold
{
    public delegate void MyEventHandler();
    public static event MyEventHandler MyEvent;

    public void MakeWish(string wish)
    {
        if (Desire.NumberOfWishes < 3)
        {
            Desire.Wishes[Desire.NumberOfWishes] = wish;
            Desire.NumberOfWishes++;
            Console.WriteLine($"Золота рибка: побажання \"{wish}\" буде здiйснено.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Золота рибка: це побажання не буде виконано");
            Console.ResetColor();
            MyEvent?.Invoke();
        }
    }
}

public class Grandfather
{
    public void HandleEvent()
    {
        Console.WriteLine("Дiд: дiд злякався. Побажання не виконано");
    }

    public void PassWishToGoldfish(string wish)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Дiд: побажання передано золотiй рибкi \"{wish}\"");
        Console.ResetColor();
        Gold goldfish = new Gold();
        goldfish.MakeWish(wish);
    }
}

public class Grandmother
{
    public void HandleEvent()
    {
        Console.WriteLine("Бабка залишилася з розбитим коритом");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Gold goldfish = new Gold();
        Grandfather grandfather = new Grandfather();
        Grandmother grandmother = new Grandmother();


        Gold.MyEvent += grandmother.HandleEvent;
        Gold.MyEvent += grandfather.HandleEvent;

        grandfather.PassWishToGoldfish("нове корито"); 
        grandfather.PassWishToGoldfish("весь океан");
        grandfather.PassWishToGoldfish("новий автомобiль");
        grandfather.PassWishToGoldfish("новий телефон"); 

        Console.ReadKey();
    }
}