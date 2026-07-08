using System.Collections.Generic;

namespace ChatBot1._0GUI
{
    class Quiz
    {
        public string Question { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new List<string>();
        public int CorrectIndex { get; set; }

        /// Explanations after answers
        public string Explanation { get; set; } = string.Empty;
    }
}
