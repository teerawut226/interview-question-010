using Interview.Question.Api.Models;
using Interview.Question.Api.Dtos;

namespace Interview.Question.Api.Services;

public interface IExamService
{
    Task<List<ExamQuestionResponse>> GetExamQuestionsAsync();
    Task<ExamResult> SubmitExamAsync(SubbmissionRequest request);
}