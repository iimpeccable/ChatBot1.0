namespace ChatBot1._0GUI
{
    class SentimentAnalyzer
    {
        public static string Detect(string input)
        {
            input = input.ToLower();
            if (input.Contains("worried") || input.Contains("scared"))
                return "Negative";
            if (input.Contains("curious") || input.Contains("interested"))
                return "Curious";
            if (input.Contains("happy") || input.Contains("confident"))
                return "Positive";
            return "Neutral";
        }
    }
}
