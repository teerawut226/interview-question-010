using Interview.Question.Api.Models;

namespace Interview.Question.Api.Data;

public class MockSeeder
{
    public static void SeedData(AppDbContext context)
    {
        if (!context.ExamQuestions.Any())
        {
            var questions = new List<ExamQuestion>
            {
                new ExamQuestion
                {
                    Title = "ข้อใดต่างจากข้ออื่น",
                    Choices = new List<Choice>
                    {
                        new Choice { Text = "3", IsCorrect = false },
                        new Choice { Text = "5", IsCorrect = false },
                        new Choice { Text = "9", IsCorrect = true },
                        new Choice { Text = "11", IsCorrect = false }
                    }
                },
                new ExamQuestion
                {
                    Title = "X + 2 = 4 จงหาค่า X",
                    Choices = new List<Choice>
                    {
                        new Choice { Text = "1", IsCorrect = false },
                        new Choice { Text = "2", IsCorrect = true },
                        new Choice { Text = "3", IsCorrect = false },
                        new Choice { Text = "4", IsCorrect = false }
                    }
                }
            };

            context.ExamQuestions.AddRange(questions);
            context.SaveChanges();
        }
    }
}