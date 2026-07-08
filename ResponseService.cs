namespace ChatBot1._0GUI
{
    class ResponseService
    {
        private readonly UserProfile _user;

        public ResponseService(UserProfile user) => _user = user;

        public (string response, Quiz? quiz) ProcessInput(string input)
        {
            string normalized = input.ToLower().Trim();

            /// Detect sentiment and update user profile
            string sentiment = SentimentAnalyzer.Detect(normalized);
            _user.UpdateSentiment(sentiment);

            /// Handle topic/quiz logic
            var result = Scenarios.HandleInput(normalized, _user.Name);
            _user.RememberTopic(result.info);

            string response = result.info;

            /// Sentiment-driven phrasing
            if (_user.LastSentiment == "Positive")
                response = "Great energy! " + response;
            else if (_user.LastSentiment == "Negative")
                response = "Don’t worry, you’re learning! " + response;
            else
                response = "Invictus " + response;

            /// Add recall of past topics
            if (_user.PastTopics.Count > 0)
                response += $"\nEarlier you asked about {_user.RecallAllTopics()}.";

            return (response, result.quiz);
        }
    }
}
