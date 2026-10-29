namespace Interview.Question.Api.Models;

public class ExamQuestion
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Choice> Choices { get; set; } = new();
}