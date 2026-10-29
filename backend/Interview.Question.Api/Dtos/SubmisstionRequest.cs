namespace Interview.Question.Api.Dtos;
using System.ComponentModel.DataAnnotations;

public class SubbmissionRequest
{
    [Required]
    public string Fullname { get; set; } = string.Empty;
    public List<AnswerRequest> Answers { get; set; } = new();
}

public class AnswerRequest
{
    public int QuestionId { get; set; }
    public int ChoiceId { get; set; }
}