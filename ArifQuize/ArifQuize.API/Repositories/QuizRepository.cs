using System;
using System.Collections.Generic;

namespace ArifQuize.API.Repositories
{
    public class QuizRepository
    {
        private readonly List<Quiz> _quizzes;

        public QuizRepository()
        {
            // In-memory storage for simplicity
            _quizzes = new List<Quiz>();
        }

        public List<Quiz> GetAllQuizzes()
        {
            return _quizzes;
        }

        public Quiz GetQuizById(string quizId)
        {
            return _quizzes.Find(quiz => quiz.Id == quizId);
        }

        public void CreateQuiz(Quiz quiz)
        {
            // Assuming Id is auto-generated or provided by the client
            quiz.Id = Guid.NewGuid().ToString();
            _quizzes.Add(quiz);
        }

        // Implement other CRUD methods as needed
    }
}
