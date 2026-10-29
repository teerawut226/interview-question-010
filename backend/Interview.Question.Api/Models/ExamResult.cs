namespace Interview.Question.Api.Models;

public class ExamResult
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int Score { get; set; }
    public int TotalScore { get; set; }
    public DateTime SubmittedAt { get; set; }
}