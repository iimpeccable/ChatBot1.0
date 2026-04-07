using System;
using System.Threading;

class UIHelper
{
    public static void PlayGreeting()
    {
        Console.WriteLine("[Greeting sound would play here]");
    }

    public static void ShowLogo()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("============================================================");
        Console.WriteLine(@"
██╗███╗   ██╗██╗   ██╗██╗ ██████╗████████╗██╗   ██╗███████╗
██║████╗  ██║██║   ██║██║██╔════╝╚══██╔══╝██║   ██║██╔════╝
██║██╔██╗ ██║██║   ██║██║██║        ██║   ██║   ██║███████╗
██║██║╚██╗██║╚██╗ ██╔╝██║██║        ██║   ██║   ██ ╚════██║
██║██║ ╚████║ ╚████╔╝ ██║╚██████╗   ██║   ╚██████╝ ███████║
╚═╝╚═╝  ╚═══╝  ╚═══╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚══════╝
                          AI
");
    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void TypeEffect(string text, int delay = 20)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }
}
