using System;
using System.Collections.Generic;

namespace ChatBot1._0GUI
{
    class Scenarios
    {
        private static string currentTopic = string.Empty;
        private static readonly Random _random = new();

        public static (string info, Quiz? quiz) HandleInput(string input, string name)
        {
            string q = input.ToLower().Trim();

            if (q.Contains("password"))
                return (ShowPasswordModule(), BuildPasswordQuiz());
            else if (q.Contains("phishing"))
                return (ShowPhishingModule(), BuildPhishingQuiz());
            else if (q.Contains("privacy"))
                return (ShowPrivacyModule(), BuildPrivacyQuiz());
            else if (q.Contains("malware"))
                return (ShowMalwareModule(), BuildMalwareQuiz());
            else if (q.Contains("quiz"))
                return ("Starting Cybersecurity Mini-Game!", BuildRandomQuiz());
            else if (q.Contains("remind"))
                return ($"Reminder noted: \"{input}\"", null);
            else if (q.Contains("task"))
                return ($"Task recorded: \"{input}\"", null);
            else if (q.Contains("more") || q.Contains("another"))
                return (ContinueTopic(), null);
            else if (q.Contains("exit"))
                return ($"Goodbye {name}! Stay safe online.", null);
            else
                return ("I didn’t quite understand that. Could you rephrase?", null);
        }

        /// PASSWORD
        private static string ShowPasswordModule()
        {
            currentTopic = "password";
            var tips = new List<string>
            {
                "Strong passwords are your first line of defense.",
                "Avoid personal details like birthdays.",
                "Use a password manager securely.",
                "Mix uppercase, lowercase, numbers, and symbols.",
                "Change passwords regularly for sensitive accounts."
            };
            return $"Password Safety:\n{tips[_random.Next(tips.Count)]}";
        }
        private static Quiz BuildPasswordQuiz() => new Quiz
        {
            Question = "Which password is strongest?",
            Options = new List<string> { "123456", "MyName2026", "T!m3$Tr0ng#Pass!" },
            CorrectIndex = 2,
            Explanation = "Complex passwords with symbols, numbers, and mixed case are hardest to crack."
        };

        /// PHISHING
        private static string ShowPhishingModule()
        {
            currentTopic = "phishing";
            var tips = new List<string>
            {
                "Phishing emails often disguise themselves as trusted organisations.",
                "Be cautious of emails asking for personal info.",
                "Check sender addresses carefully.",
                "Hover over links to see the real URL.",
                "Report suspicious emails to IT/security."
            };
            return $"Phishing Scams:\n{tips[_random.Next(tips.Count)]}";
        }
        private static Quiz BuildPhishingQuiz() => new Quiz
        {
            Question = "What should you do if you get a suspicious email?",
            Options = new List<string> { "Click the link quickly", "Delete or report it", "Reply with details" },
            CorrectIndex = 1,
            Explanation = "Suspicious emails should be deleted or reported to prevent scams."
        };

        /// PRIVACY
        private static string ShowPrivacyModule()
        {
            currentTopic = "privacy";
            var tips = new List<string>
            {
                "Limit personal info and adjust privacy settings.",
                "Think twice before posting your location.",
                "Review account security settings regularly.",
                "Use two-factor authentication.",
                "Block suspicious profiles."
            };
            return $"Social Media Privacy:\n{tips[_random.Next(tips.Count)]}";
        }
        private static Quiz BuildPrivacyQuiz() => new Quiz
        {
            Question = "What’s a safe practice on social media?",
            Options = new List<string> { "Share your home address", "Post location in real-time", "Limit personal info & adjust settings" },
            CorrectIndex = 2,
            Explanation = "Limiting personal info and adjusting settings reduces risks of identity theft."
        };

        /// MALWARE
        private static string ShowMalwareModule()
        {
            currentTopic = "malware";
            var tips = new List<string>
            {
                "Use antivirus software and keep updated.",
                "Avoid downloading files from unknown sites.",
                "Be cautious of fake apps.",
                "Keep your operating system patched.",
                "Backup files regularly to protect against ransomware."
            };
            return $"Malware & Viruses:\n{tips[_random.Next(tips.Count)]}";
        }
        private static Quiz BuildMalwareQuiz() => new Quiz
        {
            Question = "How can you protect against malware?",
            Options = new List<string> { "Download from unknown sites", "Use antivirus & updates", "Ignore updates" },
            CorrectIndex = 1,
            Explanation = "Antivirus software and regular updates are key defenses against malware."
        };

        /// CONTINUE TOPIC
        private static string ContinueTopic()
        {
            return currentTopic switch
            {
                "password" => "Extra Tip: Use at least 12 characters.",
                "phishing" => "Extra Tip: Never share personal info via email.",
                "privacy" => "Extra Tip: Review friend lists often.",
                "malware" => "Extra Tip: Avoid pirated software.",
                _ => "No active topic to continue."
            };
        }

        /// Mini Game: Randomized Quiz Pool
        private static Quiz BuildRandomQuiz()
        {
            var quizPool = new List<Quiz>
            {
                new Quiz { Question = "True/False: Using '123456' is safe.", Options = new List<string>{"True","False"}, CorrectIndex = 1, Explanation="Common passwords are unsafe." },
                new Quiz { Question = "Which is a phishing sign?", Options = new List<string>{"Generic greeting","Correct spelling","Secure HTTPS"}, CorrectIndex = 0, Explanation="Phishing emails often use generic greetings." },
                new Quiz { Question = "True/False: Antivirus should be updated regularly.", Options = new List<string>{"True","False"}, CorrectIndex = 0, Explanation="Updates keep antivirus effective." },
                new Quiz { Question = "Best way to secure social media?", Options = new List<string>{"Post location","Limit info","Share passwords"}, CorrectIndex = 1, Explanation="Limiting info reduces exposure." },
                new Quiz { Question = "True/False: Two-factor authentication adds extra security.", Options = new List<string>{"True","False"}, CorrectIndex = 0, Explanation="2FA makes accounts harder to hack." },
                new Quiz { Question = "What should you do with suspicious links?", Options = new List<string>{"Click","Ignore","Hover to check"}, CorrectIndex = 2, Explanation="Hovering reveals the real URL." },
                new Quiz { Question = "True/False: Pirated software can contain malware.", Options = new List<string>{"True","False"}, CorrectIndex = 0, Explanation="Pirated software is a common malware source." },
                new Quiz { Question = "Which password is safest?", Options = new List<string>{"Password1","Qwerty","R@nd0m!Pass2026"}, CorrectIndex = 2, Explanation="Complex random passwords are safest." },
                new Quiz { Question = "True/False: Reporting phishing emails helps prevent scams.", Options = new List<string>{"True","False"}, CorrectIndex = 0, Explanation="Reporting helps protect others." },
                new Quiz { Question = "Safe browsing tip?", Options = new List<string>{"Use HTTPS","Ignore warnings","Disable antivirus"}, CorrectIndex = 0, Explanation="HTTPS ensures secure communication." }
            };

            return quizPool[_random.Next(quizPool.Count)];
        }

        public static string GetTip(string topic)
        {
            var tips = new List<string>();

            switch (topic)
            {
                case "password":
                    tips = new List<string>
                    {
                        "Strong passwords are your first line of defense.",
                        "Avoid personal details like birthdays.",
                        "Use a password manager securely.",
                        "Mix uppercase, lowercase, numbers, and symbols.",
                        "Change passwords regularly for sensitive accounts."
                    };
                    break;

                case "phishing":
                    tips = new List<string>
                    {
                        "Phishing emails often disguise themselves as trusted organisations.",
                        "Be cautious of emails asking for personal info.",
                        "Check sender addresses carefully.",
                        "Hover over links to see the real URL.",
                        "Report suspicious emails to IT/security."
                    };
                    break;

                case "privacy":
                    tips = new List<string>
                    {
                        "Limit personal info and adjust privacy settings.",
                        "Think twice before posting your location.",
                        "Review account security settings regularly.",
                        "Use two-factor authentication.",
                        "Block suspicious profiles."
                    };
                    break;

                case "malware":
                    tips = new List<string>
                    {
                        "Use antivirus software and keep updated.",
                        "Avoid downloading files from unknown sites.",
                        "Be cautious of fake apps.",
                        "Keep your operating system patched.",
                        "Backup files regularly to protect against ransomware."
                    };
                    break;
            }

            return tips.Count > 0 ? tips[_random.Next(tips.Count)] : "No tips available.";
        }
    }
}
