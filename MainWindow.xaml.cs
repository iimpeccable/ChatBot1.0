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
            _chatbot = new ChatbotService(_user);

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

            /// Exit command
            if (input.Trim().ToLower() == "exit")
            {
                UIHelper.AddMessage(ChatHistoryPanel, $"Invictus: Goodbye {_user.Name}! Stay safe online.", "bot");
                Application.Current.Shutdown();
                return;
            }

            /// Quiz answer
            if (currentQuiz != null && int.TryParse(input, out int choice))
            {
                if (choice - 1 == currentQuiz.CorrectIndex)
                {
                    UIHelper.AddMessage(ChatHistoryPanel, $"Invictus: Correct, {_user.Name}!", "bot");
                    currentQuiz = null;
                    UIHelper.ShowMenu(ChatHistoryPanel);
                }
                else
                {
                    UIHelper.AddMessage(ChatHistoryPanel, $"Invictus: Incorrect, {_user.Name}. Try again.", "error");
                }
                UserInput.Clear();
                return;
            }

            /// Tip request
            if (input.ToLower().Contains("tip") && !string.IsNullOrEmpty(currentTopic))
            {
                string tip = Scenarios.GetTip(currentTopic);
                UIHelper.AddMessage(ChatHistoryPanel, $"Invictus Tip for {_user.Name}: {tip}", "tip");
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
