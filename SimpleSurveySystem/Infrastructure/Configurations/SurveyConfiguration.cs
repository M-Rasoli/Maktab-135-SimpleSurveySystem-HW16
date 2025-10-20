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
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.HasKey(s => s.Id);
            
            builder.Property(s => s.Title).IsRequired().HasMaxLength(150);
            
            builder.HasMany(s => s.UserSurveys).WithOne(us => us.Survey)
                .HasForeignKey(us => us.SurveyId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Questions).WithOne(q => q.Survey)
                .HasForeignKey(q => q.SurveyId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Votes).WithOne(v => v.Survey)
                .HasForeignKey(v => v.SurveyId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Survey>()
            {
                new Survey()
                {
                    Id = 1, Title = "Using Technology",
                    CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local)
                },
                new Survey()
                {
                    Id = 2, Title = "Favorite book",
                    CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local)
                },
                new Survey()
                {
                    Id = 3, Title = "Favorite Movie",
                    CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local)
                },
            });

        }
    }
}
