using System.Collections.Generic;
using QuizSystemFrontend.Services; 

namespace QuizSystemFrontend.Models // Adjust the namespace if necessary
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public Question() // Constructor to initialize Answers
        {
            Answers = new List<Answer>();
        }
    }

    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}