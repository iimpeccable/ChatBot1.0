class ChatbotService
{
    private readonly ResponseService _responseService;

    public ChatbotService()
    {
        _responseService = new ResponseService();
    }

    public void StartChat(UserProfile user)
    {
        bool running = true;
        while (running)
        {
            Console.Write($"{user.Name}: ");
            string? userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                UIHelper.ShowError("Invalid input. Please type a valid question.");
                continue;
            }

            _responseService.ProcessInput(userInput, user.Name);

            if (userInput.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                running = false;
                UIHelper.TypeEffect($"Goodbye {user.Name}! Stay safe online.");
            }
        }
    }
}