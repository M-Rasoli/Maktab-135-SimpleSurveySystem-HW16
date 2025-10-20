using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleSurveySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleSurveySystem.Infrastructure.Configurations
{
    public class OptionsConfiguration : IEntityTypeConfiguration<Options>
    {
        public void Configure(EntityTypeBuilder<Options> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.OptionNumber).IsRequired().HasMaxLength(5);

            builder.Property(o => o.Text).IsRequired().HasMaxLength(200);

            builder.HasMany(o => o.Votes).WithOne(v => v.Options)
                .HasForeignKey(v => v.OptionId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Question).WithMany(q => q.Options)
                .HasForeignKey(o => o.QuestionId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Options>()
            {
                //1 How many hours do you use your phone per day?
                new Options(){Id = 1, OptionNumber = 1 , Text = "Less than 2 hours." , QuestionId = 1,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 2, OptionNumber = 2 , Text = "Less than 4 hours." , QuestionId = 1,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 3, OptionNumber = 3 , Text = "More than 4 hours." , QuestionId = 1,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 4, OptionNumber = 4 , Text = "More than 8 hours." , QuestionId = 1,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},

                //2 How many hours do you use your PC per day ?
                new Options(){Id = 5, OptionNumber = 1 , Text = "Less than 2 hours." , QuestionId = 2,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 6, OptionNumber = 2 , Text = "Less than 4 hours." , QuestionId = 2,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 7, OptionNumber = 3 , Text = "More than 4 hours." , QuestionId = 2,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 8, OptionNumber = 4 , Text = "More than 8 hours." , QuestionId = 2,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},

                //3 What genre is your favorite book usually from?
                new Options(){Id = 9, OptionNumber = 1 , Text = "Mystery" , QuestionId = 3,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 10, OptionNumber = 2 , Text = "Historical" , QuestionId = 3,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 11, OptionNumber = 3 , Text = "Poetry" , QuestionId = 3,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 12, OptionNumber = 4 , Text = "Fantasy" , QuestionId = 3,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},

                //4 Which of the following books have you read?
                new Options(){Id = 13, OptionNumber = 1 , Text = "The Silent Patient by Alex Michaelides" , QuestionId = 4,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 14, OptionNumber = 2 , Text = "A Game of Thrones by George R. R. Martin" , QuestionId = 4,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 15, OptionNumber = 3 , Text = "Odyssey by Homer" , QuestionId = 4,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 16, OptionNumber = 4 , Text = "None" , QuestionId = 4,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},

                //5 How often do you recommend others to read books?
                new Options(){Id = 17, OptionNumber = 1 , Text = "Never" , QuestionId = 5,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 18, OptionNumber = 2 , Text = "Often" , QuestionId = 5,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 19, OptionNumber = 3 , Text = "Always" , QuestionId = 5,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 20, OptionNumber = 4 , Text = "Fantasy" , QuestionId = 5,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},

                //6 What genre is your favorite movie usually from?
                new Options(){Id = 21, OptionNumber = 1 , Text = "Action" , QuestionId = 6,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 22, OptionNumber = 2 , Text = "Drama" , QuestionId = 6,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 23, OptionNumber = 3 , Text = "Crime fiction" , QuestionId = 6,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 24, OptionNumber = 4 , Text = "Comedy " , QuestionId = 6,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},

                //7 How many hours a day do you usually spend watching movies?
                new Options(){Id = 25, OptionNumber = 1 , Text = "Less than 2 hours." , QuestionId = 7,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 26, OptionNumber = 2 , Text = "Less than 4 hours." , QuestionId = 7,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 27, OptionNumber = 3 , Text = "More than 4 hours." , QuestionId = 7,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 28, OptionNumber = 4 , Text = "More than 8 hours. " , QuestionId = 7,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},

                //8 Which of the following directors' works have you seen?
                new Options(){Id = 29, OptionNumber = 1 , Text = "Christopher Edward Nolan" , QuestionId = 8,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 30, OptionNumber = 2 , Text = "Stanley Kubrick" , QuestionId = 8,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 31, OptionNumber = 3 , Text = "Martin Charles Scorsese" , QuestionId = 8,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new Options(){Id = 32, OptionNumber = 4 , Text = "David Andrew Leo Fincher" , QuestionId = 8,CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},

            });
        }
    }
}
