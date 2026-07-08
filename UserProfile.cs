using System;
using System.Collections.Generic;

namespace ChatBot1._0GUI
{
    class UserProfile
    {
        public string Name { get; private set; }
        public List<string> PastTopics { get; private set; }
        public string LastSentiment { get; private set; }

        /// Quiz tracking
        public int Score { get; private set; }
        public int TotalQuestions { get; private set; }

        /// Activity log
        public List<string> ActivityLog { get; private set; }

        /// New for Step 3/4
        public List<string> Reminders { get; private set; }
        public List<string> Tasks { get; private set; }

        public UserProfile(string name)
        {
            Name = name ?? "Guest";
            PastTopics = new List<string>();
            LastSentiment = "Neutral";
            Score = 0;
            TotalQuestions = 0;
            ActivityLog = new List<string>();
            Reminders = new List<string>();
            Tasks = new List<string>();
        }

        /// Topic memory
        public void RememberTopic(string topic)
        {
            if (!PastTopics.Contains(topic))
                PastTopics.Add(topic);
        }

        public void UpdateSentiment(string sentiment) => LastSentiment = sentiment;

        public string RecallAllTopics() =>
            PastTopics.Count == 0 ? "No topics yet." : string.Join(", ", PastTopics);

        /// Quiz tracking
        public void RecordQuizResult(bool correct, string question)
        {
            TotalQuestions++;
            if (correct) Score++;
            AddLog($"Quiz attempted: \"{question}\" → {(correct ? "Correct" : "Incorrect")}");
        }

        /// Activity log
        public void AddLog(string action)
        {
            string entry = $"{DateTime.Now:HH:mm} - {action}";
            ActivityLog.Add(entry);

            if (ActivityLog.Count > 10)
                ActivityLog.RemoveAt(0);
        }

        public string ShowActivityLog()
        {
            if (ActivityLog.Count == 0)
                return "No recent activity recorded.";
            return string.Join("\n", ActivityLog);
        }

        /// Reminders
        public void AddReminder(string reminder)
        {
            Reminders.Add(reminder);
            AddLog($"Reminder added: {reminder}");
        }

        public string ShowReminders()
        {
            if (Reminders.Count == 0)
                return "No reminders set.";
            return string.Join("\n", Reminders);
        }

        /// Tasks
        public void AddTask(string task)
        {
            Tasks.Add(task);
            AddLog($"Task added: {task}");
        }

        public string ShowTasks()
        {
            if (Tasks.Count == 0)
                return "No tasks recorded.";
            return string.Join("\n", Tasks);
        }
    }
}
