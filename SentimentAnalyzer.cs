using System;

namespace ChatBot1._0GUI
{
    static class SentimentAnalyzer
    {
        public static string Detect(string input)
        {
            input = input.ToLower();

            /// Simple sentiment detection
            if (input.Contains("happy") || input.Contains("fun") || input.Contains("great") || input.Contains("love"))
                return "Positive";
            if (input.Contains("sad") || input.Contains("angry") || input.Contains("frustrated") || input.Contains("hate"))
                return "Negative";

            return "Neutral";
        }

        public static string DetectCommand(string input)
        {
            input = input.ToLower();

            /// Basic NLP keyword detection
            if (input.Contains("remind") || input.Contains("reminder"))
                return "reminder";
            if (input.Contains("task") || input.Contains("add") || input.Contains("todo"))
                return "task";
            if (input.Contains("quiz") || input.Contains("question"))
                return "quiz";
            if (input.Contains("tip"))
                return "tip";
            if (input.Contains("exit") || input.Contains("quit"))
                return "exit";

            return "unknown";
        }
    }
}
