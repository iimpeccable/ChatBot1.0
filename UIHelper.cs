using System;
using System.Threading;
using System.Media;

class UIHelper
{
    public static void PlayGreeting()
    {
        try
        {
            /// Play greeting sound
           

            SoundPlayer player2 = new SoundPlayer("Assets/propergreeting.wav");
            player2.Load();
            player2.PlaySync();
            SoundPlayer player1 = new SoundPlayer("Assets/greeting.wav");
            player1.Load();
            player1.PlaySync();

            Console.ForegroundColor = ConsoleColor.Magenta;
            
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error playing greeting] {ex.Message}");
            Console.ForegroundColor = ConsoleColor.Magenta;

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
╚═╝╚═╝  ╚═══╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚══════╝
                          Awareness Bot
");
        Console.WriteLine("============================================================");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
    }

    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
    }

    public static void TypeEffect(string text, int delay = 20)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.ResetColor();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
    }

    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nYou can ask me things like:");
        Console.WriteLine("- How are you?");
        Console.WriteLine("- What’s your purpose?");
        Console.WriteLine("- What can I ask you about?");
        Console.WriteLine("- Tell me about password safety");
        Console.WriteLine("- What is phishing?");
        Console.WriteLine("- What is malware?");
        Console.WriteLine("Type 'exit' to close the chatbot.\n");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
    }
}
