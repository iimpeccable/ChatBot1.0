using System;

class ChatBot
{
    public string UserName { get; set; } = string.Empty;

    public void Start()
    {
        UIHelper.PlayGreeting();
        UIHelper.ShowLogo();

        Console.Write("What’s your name? ");
        UserName = Console.ReadLine()?.Trim() ?? "Guest";

        UIHelper.TypeEffect($"\nWelcome, {UserName}! Let’s learn about online safety.\n");
        UIHelper.TypeEffect("You can ask me things like:");
        UIHelper.TypeEffect("- How are you?");
        UIHelper.TypeEffect("- What’s your purpose?");
        UIHelper.TypeEffect("- What can I ask you about?");
        UIHelper.TypeEffect("- Tell me about password safety");
        UIHelper.TypeEffect("- What is phishing?");
        UIHelper.TypeEffect("- What is malware?");
        UIHelper.TypeEffect("Type 'exit' to close the chatbot.\n");

        RunConversation();
    }

    private void RunConversation()
    {
        bool running = true;
        while (running)
        {
            Console.Write($"{UserName}: ");
            string input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                UIHelper.ShowError("I didn’t catch that. Please type something.\n");
                continue;
            }

            Scenarios.HandleInput(input, UserName);

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                running = false;
                UIHelper.TypeEffect($"Goodbye {UserName}! Stay safe online.");
            }
        }
    }
}