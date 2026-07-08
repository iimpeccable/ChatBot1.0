using System;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChatBot1._0GUI
{
    class UIHelper
    {
        public static void PlayGreeting()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string assetsPath = Path.Combine(baseDir, "Assets");

                string properGreeting = Path.Combine(assetsPath, "propergreeting.wav");
                string greeting = Path.Combine(assetsPath, "greeting.wav");

                if (File.Exists(properGreeting))
                {
                    SoundPlayer player2 = new SoundPlayer(properGreeting);
                    player2.Load();
                    player2.PlaySync();
                }

                if (File.Exists(greeting))
                {
                    SoundPlayer player1 = new SoundPlayer(greeting);
                    player1.Load();
                    player1.PlaySync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[Error playing greeting] {ex.Message}",
                    "Audio Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public static void AddMessage(StackPanel chatPanel, string text, string role)
        {
            var tb = new TextBlock
            {
                Text = text,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 5, 0, 5),
                FontFamily = new FontFamily("Segoe UI"),
                FontSize = 14
            };

            switch (role.ToLower())
            {
                case "user":
                    tb.Foreground = Brushes.LightBlue;
                    break;
                case "bot":
                    tb.Foreground = Brushes.LightGreen;
                    break;
                case "error":
                    tb.Foreground = Brushes.Tomato;
                    break;
                case "tip":
                    tb.Foreground = Brushes.Gold;
                    break;
                case "score":
                    tb.Foreground = Brushes.Cyan;
                    tb.FontWeight = FontWeights.Bold;
                    break;
                case "log":
                    tb.Foreground = Brushes.Orange;
                    tb.FontStyle = FontStyles.Italic;
                    break;
                case "reminder":
                    tb.Foreground = Brushes.MediumPurple;
                    tb.FontWeight = FontWeights.SemiBold;
                    break;
                case "task":
                    tb.Foreground = Brushes.LightSalmon;
                    tb.FontWeight = FontWeights.SemiBold;
                    break;
                default:
                    tb.Foreground = Brushes.White;
                    break;
            }

            chatPanel.Children.Add(tb);
        }

        public static void ShowMenu(StackPanel chatPanel)
        {
            AddMessage(chatPanel, "=== Invictus Menu ===", "bot");
            AddMessage(chatPanel, "- Ask about password safety", "bot");
            AddMessage(chatPanel, "- Ask about phishing", "bot");
            AddMessage(chatPanel, "- Ask about privacy", "bot");
            AddMessage(chatPanel, "- Ask about malware", "bot");
            AddMessage(chatPanel, "- Type 'quiz' to start the Cybersecurity Mini-Game", "bot");
            AddMessage(chatPanel, "- Type 'tip' to get a tip on the current topic", "bot");
            AddMessage(chatPanel, "- Type 'log' to view your activity log", "bot");
            AddMessage(chatPanel, "- Type 'reminder' to add or view reminders", "bot");
            AddMessage(chatPanel, "- Type 'task' to add or view tasks", "bot");
            AddMessage(chatPanel, "- Type 'exit' to close Invictus", "bot");
        }

        public static async Task ShowTypingAnimatedAsync(StackPanel chatPanel)
        {
            var tb = new TextBlock
            {
                Foreground = Brushes.Gray,
                FontStyle = FontStyles.Italic,
                Margin = new Thickness(0, 5, 0, 5)
            };

            chatPanel.Children.Add(tb);

            for (int i = 0; i < 3; i++)
            {
                tb.Text = "Invictus is typing" + new string('.', i + 1);
                await Task.Delay(500);
            }

            chatPanel.Children.Remove(tb);
        }

        /// Quiz score summary
        public static void ShowScore(StackPanel chatPanel, int score, int total)
        {
            string feedback = score >= 8
                ? $"Great job! You’re a cybersecurity pro! Final Score: {score}/{total}"
                : $"Keep learning to stay safe online! Final Score: {score}/{total}";

            AddMessage(chatPanel, feedback, "score");
        }

        /// Activity log
        public static void ShowActivityLog(StackPanel chatPanel, string log)
        {
            AddMessage(chatPanel, "=== Recent Activity Log ===", "log");
            AddMessage(chatPanel, log, "log");
        }
        public static void ShowStructuredLog(StackPanel chatPanel, List<string> entries, string title, string role)
        {
            AddMessage(chatPanel, $"=== {title} ===", role);
            if (entries.Count == 0)
            {
                AddMessage(chatPanel, "No entries found.", role);
                return;
            }

            foreach (var entry in entries)
            {
                AddMessage(chatPanel, entry, role);
            }
        }


        /// Reminders
        public static void ShowReminders(StackPanel chatPanel, string reminders)
        {
            AddMessage(chatPanel, "=== Your Reminders ===", "reminder");
            AddMessage(chatPanel, reminders, "reminder");
        }

        /// Tasks
        public static void ShowTasks(StackPanel chatPanel, string tasks)
        {
            AddMessage(chatPanel, "=== Your Tasks ===", "task");
            AddMessage(chatPanel, tasks, "task");
        }
    }
}
