namespace ChatBot1._0GUI
{
    class ChatbotService
    {
        private readonly ResponseService _responseService;
        private readonly UserProfile _user;
        private readonly TaskAssistant _taskAssistant;

        public ChatbotService(UserProfile user, string connectionString)
        {
            _user = user;
            _responseService = new ResponseService(user);
            _taskAssistant = new TaskAssistant(connectionString);
        }

        public (string response, Quiz? quiz) ProcessInput(string input)
        {
            string command = SentimentAnalyzer.DetectCommand(input);

            switch (command)
            {
                case "reminder":
                    _user.AddReminder(input);
                    _taskAssistant.AddReminder(input);
                    return ($"Reminder saved: \"{input}\"", null);

                case "task":
                    _user.AddTask(input);
                    _taskAssistant.AddTask(input);
                    return ($"Task added: \"{input}\"", null);

                case "log":
                    return (_user.ShowActivityLog(), null);

                case "tip":
                    return ("Tip requested.", null);

                case "quiz":
                    return ("Starting quiz...", null);

                case "exit":
                    return ($"Goodbye {_user.Name}! Stay safe online.", null);

                case "showreminders":
                    var reminders = _taskAssistant.GetReminders();
                    return (reminders.Count == 0 ? "No reminders found." : string.Join("\n", reminders), null);

                case "showtasks":
                    var tasks = _taskAssistant.GetTasks();
                    return (tasks.Count == 0 ? "No tasks found." : string.Join("\n", tasks), null);
                case "clearreminders":
                    _user.Reminders.Clear();
                    /// Clear DB
                    return ("All reminders cleared.", null);

                case "cleartasks":
                    _user.Tasks.Clear();
                    /// Clear DB
                    return ("All tasks cleared.", null);

                case "deletereminder":
                    /// Remove specific reminder
                    if (_user.Reminders.Count > 0)
                    {
                        string removed = _user.Reminders[0];
                        _user.Reminders.RemoveAt(0);
                        return ($"Reminder deleted: {removed}", null);
                    }
                    return ("No reminders to delete.", null);

                case "deletetask":
                    if (_user.Tasks.Count > 0)
                    {
                        string removed = _user.Tasks[0];
                        _user.Tasks.RemoveAt(0);
                        return ($"Task deleted: {removed}", null);
                    }
                    return ("No tasks to delete.", null);


                default:
                    return _responseService.ProcessInput(input);
            }
        }
    }
}
