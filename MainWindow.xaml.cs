using System.Windows;

namespace ChatBot1._0GUI
{
    public partial class MainWindow : Window
    {
        private readonly ChatbotService _chatbot;
        private readonly UserProfile _user;
        private Quiz? currentQuiz;
        private string currentTopic = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            UIHelper.PlayGreeting();
            UIHelper.AddMessage(ChatHistoryPanel, "Welcome to Invictus!", "bot");

            string? nameInput = Microsoft.VisualBasic.Interaction.InputBox(
                "What’s your name?", "Enter Name", "Guest");

            if (string.IsNullOrWhiteSpace(nameInput))
                nameInput = "Guest";

            _user = new UserProfile(nameInput);

            /// Pass connection string for MySQL persistence
            string connectionString = "server=localhost;user=root;password=#Mpendulo220700;database=invictusdb;";
            _chatbot = new ChatbotService(_user, connectionString);

            UIHelper.ShowMenu(ChatHistoryPanel);
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(input))
            {
                UIHelper.AddMessage(ChatHistoryPanel, "[Error] Invalid input. Please type a valid question.", "error");
                return;
            }

            UIHelper.AddMessage(ChatHistoryPanel, $"{_user.Name}: {input}", "user");

            string command = SentimentAnalyzer.DetectCommand(input);

            switch (command)
            {
                case "exit":
                    UIHelper.AddMessage(ChatHistoryPanel, $"Invictus: Goodbye {_user.Name}! Stay safe online.", "bot");
                    Application.Current.Shutdown();
                    return;

                case "log":
                    string log = _user.ShowActivityLog();
                    UIHelper.ShowActivityLog(ChatHistoryPanel, log);
                    UserInput.Clear();
                    return;

                case "tip":
                    if (!string.IsNullOrEmpty(currentTopic))
                    {
                        string tip = Scenarios.GetTip(currentTopic);
                        UIHelper.AddMessage(ChatHistoryPanel, $"Invictus Tip for {_user.Name}: {tip}", "tip");
                        _user.AddLog($"Tip requested on {currentTopic}");
                    }
                    else
                    {
                        UIHelper.AddMessage(ChatHistoryPanel, "No active topic for tips.", "error");
                    }
                    UserInput.Clear();
                    return;

                case "quiz":
                    var quizResult = Scenarios.HandleInput("quiz", _user.Name);
                    currentQuiz = quizResult.quiz;
                    if (currentQuiz != null)
                    {
                        _user.AddLog("Mini-game quiz started");
                        UIHelper.AddMessage(ChatHistoryPanel, $"Quiz: {currentQuiz.Question}", "bot");
                        for (int i = 0; i < currentQuiz.Options.Count; i++)
                        {
                            UIHelper.AddMessage(ChatHistoryPanel, $"{i + 1}) {currentQuiz.Options[i]}", "bot");
                        }
                        UIHelper.AddMessage(ChatHistoryPanel, "Type the option number to answer.", "bot");
                    }
                    UserInput.Clear();
                    return;

                case "showreminders":
                    var remindersResult = _chatbot.ProcessInput("showreminders");
                    UIHelper.ShowReminders(ChatHistoryPanel, remindersResult.response);
                    UserInput.Clear();
                    return;

                case "showtasks":
                    var tasksResult = _chatbot.ProcessInput("showtasks");
                    UIHelper.ShowTasks(ChatHistoryPanel, tasksResult.response);
                    UserInput.Clear();
                    return;
            }

            /// Quiz answer handling
            if (currentQuiz != null && int.TryParse(input, out int choice))
            {
                bool correct = (choice - 1 == currentQuiz.CorrectIndex);
                _user.RecordQuizResult(correct, currentQuiz.Question);

                if (correct)
                {
                    UIHelper.AddMessage(ChatHistoryPanel, $"Invictus: Correct, {_user.Name}!", "bot");
                    UIHelper.AddMessage(ChatHistoryPanel, $"Explanation: {currentQuiz.Explanation}", "tip");
                    currentQuiz = null;

                    if (_user.TotalQuestions >= 10)
                        UIHelper.ShowScore(ChatHistoryPanel, _user.Score, _user.TotalQuestions);

                    UIHelper.ShowMenu(ChatHistoryPanel);
                }
                else
                {
                    UIHelper.AddMessage(ChatHistoryPanel, $"Invictus: Incorrect, {_user.Name}. Try again.", "error");
                    UIHelper.AddMessage(ChatHistoryPanel, $"Hint: {currentQuiz.Explanation}", "tip");
                }
                UserInput.Clear();
                return;
            }

            /// Typing animation
            await UIHelper.ShowTypingAnimatedAsync(ChatHistoryPanel);

            /// Normal response
            var result = _chatbot.ProcessInput(input);
            UIHelper.AddMessage(ChatHistoryPanel, $"Invictus to {_user.Name}: {result.response}", "bot");

            if (result.quiz != null)
            {
                currentQuiz = result.quiz;
                currentTopic = result.response.Contains("Password") ? "password" :
                               result.response.Contains("Phishing") ? "phishing" :
                               result.response.Contains("Privacy") ? "privacy" :
                               result.response.Contains("Malware") ? "malware" : string.Empty;

                _user.AddLog($"Quiz started on {currentTopic}");

                UIHelper.AddMessage(ChatHistoryPanel, $"Quiz: {currentQuiz.Question}", "bot");
                for (int i = 0; i < currentQuiz.Options.Count; i++)
                {
                    UIHelper.AddMessage(ChatHistoryPanel, $"{i + 1}) {currentQuiz.Options[i]}", "bot");
                }
                UIHelper.AddMessage(ChatHistoryPanel, "Type the option number to answer.", "bot");
            }

            UserInput.Clear();
        }
    }
}
