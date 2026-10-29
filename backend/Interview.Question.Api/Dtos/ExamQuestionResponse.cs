namespace Interview.Question.Api.Dtos;

public class ExamQuestionResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<ChoiceResponse> Choices { get; set; } = new();
}

public class ChoiceResponse
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
}