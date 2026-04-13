using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Cybersecurity Awareness Bot";

        Console.ForegroundColor = ConsoleColor.Magenta;

        ChatBot bot = new ChatBot();
        bot.Start();
    }
}