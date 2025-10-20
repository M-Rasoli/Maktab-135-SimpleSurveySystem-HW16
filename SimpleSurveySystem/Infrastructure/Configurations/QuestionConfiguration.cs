using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleSurveySystem.Entities;

namespace SimpleSurveySystem.Infrastructure.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.Id);
            
            builder.Property(q => q.QuestionTitle).IsRequired().HasMaxLength(400);
            
            builder.HasMany(q => q.Options).WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId).OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(q => q.Votes).WithOne(v => v.Question)
                .HasForeignKey(v => v.QuestionId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(q => q.Survey).WithMany(s => s.Questions)
                .HasForeignKey(s => s.SurveyId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Question>()
            {
                new Question()
                {
                    Id = 1, QuestionTitle = "How many hours do you use your phone per day?",SurveyId = 1
                    ,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)
                },
                new Question()
                {
                    Id = 2, QuestionTitle = "How many hours do you use your PC per day? ",SurveyId = 1
                    ,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)
                },
                new Question()
                {
                    Id = 3, QuestionTitle = "What genre is your favorite book usually from?",SurveyId = 2
                    ,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)
                },
                new Question()
                {
                    Id = 4, QuestionTitle = "Which of the following books have you read?",SurveyId = 2
                    ,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)
                },
                new Question()
                {
                    Id = 5, QuestionTitle = "How often do you recommend others to read books?",SurveyId = 2
                    ,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)
                },
                new Question()
                {
                    Id = 6, QuestionTitle = "What genre is your favorite movie usually from?",SurveyId = 3
                    ,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)
                },
                new Question()
                {
                    Id = 7, QuestionTitle = "How many hours a day do you usually spend watching movies?",SurveyId = 3
                    ,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)
                },
                new Question()
                {
                    Id = 8, QuestionTitle = "Which of the following directors' works have you seen?",SurveyId = 3
                    ,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)
                },
            });

        }
    }
}
