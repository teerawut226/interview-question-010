namespace Interview.Question.Api.Models;

public class Choice
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public int ExamQuestionId { get; set; }
    public ExamQuestion? ExamQuestion { get; set; } = null!;
}