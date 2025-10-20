using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleSurveySystem.Entities;
using SimpleSurveySystem.Enums;

namespace SimpleSurveySystem.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.Property(u => u.Username).IsRequired().HasMaxLength(150);
            
            builder.Property(u => u.Password).IsRequired().HasMaxLength(150);

            builder.Property(u => u.Role).HasConversion<string>();
            
            builder.HasMany(u => u.UserSurveys).WithOne(us => us.User)
                .HasForeignKey(us => us.UserId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.Votes).WithOne(v => v.User)
                .HasForeignKey(v => v.UserId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<User>()
            {
                new User(){Id = 1,Username = "mmd", Password = "123",Role = RoleEnum.Admin,
                    CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new User(){Id = 2,Username = "ali", Password = "123",Role = RoleEnum.NormalUSer,
                    CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new User(){Id = 3,Username = "mahdi", Password = "123",Role = RoleEnum.NormalUSer,
                    CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new User(){Id = 4,Username = "porya", Password = "123",Role = RoleEnum.NormalUSer,
                    CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)},
                new User(){Id = 5,Username = "hasan", Password = "123",Role = RoleEnum.NormalUSer,
                    CreatedAt = new DateTime(2024,12,12,12,12,12,DateTimeKind.Local)}
            });
        }
    }
}
