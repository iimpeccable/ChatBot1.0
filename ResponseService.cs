namespace ChatBot1._0GUI
{
    class ResponseService
    {
        private readonly UserProfile _user;

        public ResponseService(UserProfile user) => _user = user;

        public (string response, Quiz? quiz) ProcessInput(string input)
        {
            string normalized = input.ToLower().Trim();
            string sentiment = SentimentAnalyzer.Detect(normalized);
            _user.UpdateSentiment(sentiment);

            var result = Scenarios.HandleInput(normalized, _user.Name);
            _user.RememberTopic(result.info);

            string response = result.info;
            if (_user.PastTopics.Count > 0)
                response += $"\nEarlier you asked about {_user.RecallAllTopics()}.";

            return (response, result.quiz);
        }
    }
}
