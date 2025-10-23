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
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasKey(v => new { v.SurveyId, v.UserId ,v.QuestionId , v.OptionId});

            builder.HasOne(v => v.Survey).WithMany(s => s.Votes)
                .HasForeignKey(v => v.SurveyId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(v => v.User).WithMany(v => v.Votes)
                .HasForeignKey(v => v.UserId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(v => v.Question).WithMany(q => q.Votes)
                .HasForeignKey(v => v.QuestionId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(v => v.Option).WithMany(o => o.Votes)
                .HasForeignKey(v => v.OptionId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
