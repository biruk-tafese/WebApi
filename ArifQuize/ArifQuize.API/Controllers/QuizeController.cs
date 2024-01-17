using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ArifQuize.API.Repositories;

namespace ArifQuize.API.Controllers
{
    [ApiController]
    [Route("api/quizzes")]
    public class QuizController : ControllerBase
    {
        private readonly QuizRepository _quizRepository;

        public QuizController(QuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        [HttpGet]
        public ActionResult<List<Quiz>> GetAllQuizzes()
        {
            var quizzes = _quizRepository.GetAllQuizzes();
            return Ok(quizzes);
        }

        [HttpGet("{quizId}")]
        public ActionResult<Quiz> GetQuizById(string quizId)
        {
            var quiz = _quizRepository.GetQuizById(quizId);
            if (quiz == null)
                return NotFound();

            return Ok(quiz);
        }

        [HttpPost]
        public ActionResult CreateQuiz([FromBody] Quiz quiz)
        {
            _quizRepository.CreateQuiz(quiz);
            return CreatedAtAction(nameof(GetQuizById), new { quizId = quiz.Id }, quiz);
        }

        // Implement other CRUD actions as needed
    }
}
