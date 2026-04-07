using System;
using System.Threading;
using System.Media;


class UIHelper
{
    public static void PlayGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("Assets/greeting.wav");
            player.Load();
            player.PlaySync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Error playing greeting] {ex.Message}");
        }
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
    }
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
