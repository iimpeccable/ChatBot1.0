using System.Collections.Generic;

namespace ChatBot1._0GUI
{
    class UserProfile
    {
        public string Name { get; private set; }
        public List<string> PastTopics { get; private set; }
        public string LastSentiment { get; private set; }

        public UserProfile(string name)
        {
            Name = name ?? "Guest";
            PastTopics = new List<string>();
            LastSentiment = "Neutral";
        }

        public void RememberTopic(string topic)
        {
            if (!PastTopics.Contains(topic))
                PastTopics.Add(topic);
        }

        public void UpdateSentiment(string sentiment) => LastSentiment = sentiment;

        public string RecallAllTopics() =>
            PastTopics.Count == 0 ? "No topics yet." : string.Join(", ", PastTopics);
    }
}
