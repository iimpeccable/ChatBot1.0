using System;

class Scenarios
{
    public static void HandleInput(string input, string name)
    {
        string question = input.ToLower().Trim();

        if (question.Contains("how are you"))
            Console.WriteLine("I’m just code, but I’m running smoothly!\n");
        else if (question.Contains("purpose"))
            Console.WriteLine("My purpose is to teach you about cybersecurity awareness.\n");
        else if (question.Contains("ask"))
            Console.WriteLine("You can ask me about phishing, password safety, social media privacy, and malware.\n");
        else if (question.Contains("password"))
            ShowPasswordModule();
        else if (question.Contains("phishing"))
            ShowPhishingModule();
        else if (question.Contains("privacy") || question.Contains("social media"))
            ShowPrivacyModule();
        else if (question.Contains("malware") || question.Contains("virus"))
            ShowMalwareModule();
        else if (question.Contains("exit"))
        {
            Console.WriteLine($"\nGoodbye {name}! Stay safe online.");
            Environment.Exit(0);
        }
        else
            UIHelper.ShowError("I didn’t quite understand that. Could you rephrase?\n");
    }

    private static void ShowPasswordModule()
    {
        Console.WriteLine("\nPassword Safety");
        Console.WriteLine("Strong passwords are your first line of defense.");
        Console.WriteLine("A good password is long, unique, and hard to guess.");
        Console.WriteLine("Tip: Use a password manager to keep track of them securely.\n");

        Console.WriteLine("Q: Which password is strongest?");
        Console.WriteLine("1) 123456");
        Console.WriteLine("2) MyName2026");
        Console.WriteLine("3) T!m3$Tr0ng#Pass!");
        string answer = Console.ReadLine();
        Console.WriteLine(answer == "3" ? "Correct!\n" : "Try again.\n");
    }

    private static void ShowPhishingModule()
    {
        Console.WriteLine("\nPhishing Scams");
        Console.WriteLine("Phishing is digital trickery.");
        Console.WriteLine("Scammers send fake emails or messages to steal your info.");
        Console.WriteLine("If something feels off — like urgent requests or strange links — don’t click.\n");

        Console.WriteLine("Q: What should you do if you get a suspicious email?");
        Console.WriteLine("1) Click the link quickly");
        Console.WriteLine("2) Delete it or report it");
        Console.WriteLine("3) Reply with your details");
        string answer = Console.ReadLine();
        Console.WriteLine(answer == "2" ? "Correct!\n" : "Try again.\n");
    }

    private static void ShowPrivacyModule()
    {
        Console.WriteLine("\nSocial Media Privacy");
        Console.WriteLine("What you share online can be seen by more people than you think.");
        Console.WriteLine("Adjust your privacy settings and avoid sharing personal details.\n");

        Console.WriteLine("Q: What’s a safe practice on social media?");
        Console.WriteLine("1) Share your home address");
        Console.WriteLine("2) Post your location in real-time");
        Console.WriteLine("3) Limit personal info and adjust privacy settings");
        string answer = Console.ReadLine();
        Console.WriteLine(answer == "3" ? "Correct!\n" : "Try again.\n");
    }

    private static void ShowMalwareModule()
    {
        Console.WriteLine("\nMalware & Viruses");
        Console.WriteLine("Malware is software designed to harm your device or steal data.");
        Console.WriteLine("It can come from suspicious downloads or fake apps.");
        Console.WriteLine("Use antivirus software and keep your system updated.\n");

        Console.WriteLine("Q: How can you protect against malware?");
        Console.WriteLine("1) Download files from unknown sites");
        Console.WriteLine("2) Use antivirus software and updates");
        Console.WriteLine("3) Ignore software updates");
        string answer = Console.ReadLine();
        Console.WriteLine(answer == "2" ? "Correct!\n" : "Try again.\n");
    }
}