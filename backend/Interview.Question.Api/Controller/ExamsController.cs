using Interview.Question.Api.Dtos;
using Interview.Question.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Question.Api.Controller;

[ApiController]
[Route("api/exams")]
public class ExamsController : ControllerBase
{
    private readonly IExamService _examService;

    public ExamsController(IExamService examService)
    {
        _examService = examService;
    }

    [HttpGet]
    public async Task<IActionResult> GetExams()
    {
        var exams = await _examService.GetExamQuestionsAsync();
        return Ok(exams);
    }

    [HttpPost]
    public async Task<IActionResult> CreateExam([FromBody] SubbmissionRequest examDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdExam = await _examService.SubmitExamAsync(examDto);
        return CreatedAtAction(nameof(GetExams), new { id = createdExam.Id }, createdExam);
    }

}