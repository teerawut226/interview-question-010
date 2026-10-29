using Interview.Question.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview.Question.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ExamQuestion> ExamQuestions => Set<ExamQuestion>();
    public DbSet<Choice> Choices => Set<Choice>();
    public DbSet<ExamResult> ExamResults => Set<ExamResult>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ExamQuestion>()
            .HasMany(q => q.Choices)
            .WithOne(c => c.ExamQuestion)
            .HasForeignKey(c => c.ExamQuestionId);
        base.OnModelCreating(modelBuilder);
            
    }
}