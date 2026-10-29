using Interview.Question.Api.Data;
using Interview.Question.Api.Dtos;
using Interview.Question.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview.Question.Api.Services;

public class ExamService : IExamService
{
    private readonly AppDbContext _dbContext;

    public ExamService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ExamQuestionResponse>> GetExamQuestionsAsync()
    {
        var questions = await _dbContext.ExamQuestions
            .Include(q => q.Choices)
            .ToListAsync();

        return questions.Select(q => new ExamQuestionResponse
        {
            Id = q.Id,
            Title = q.Title,
            Choices = q.Choices.Select(c => new ChoiceResponse
            {
                Id = c.Id,
                Text = c.Text
            }).ToList()
        }).ToList();
    }

    public async Task<ExamResult> SubmitExamAsync(SubbmissionRequest request)
    {
        var totalScore = 0;
        var score = 0;

        foreach (var answer in request.Answers)
        {
            var choice = await _dbContext.Choices.FindAsync(answer.ChoiceId);
            if (choice != null && choice.IsCorrect)
            {
                score++;
            }
            totalScore++;
        }

        var examResult = new ExamResult
        {
            FullName = request.Fullname,
            Score = score,
            TotalScore = totalScore,
            SubmittedAt = DateTime.UtcNow
        };

        _dbContext.ExamResults.Add(examResult);
        await _dbContext.SaveChangesAsync();

        return examResult;
    }
}