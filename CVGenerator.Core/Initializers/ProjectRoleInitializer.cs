using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Initializers
{
    public static class ProjectRoleInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectRole>().HasData(
                new ProjectRole
                {
                    Id = 1,
                    ShortName = "Tech Leader",
                    Name = "Tech Leader"
                },
                new ProjectRole
                {
                    Id = 2,
                    ShortName = "Team Leader",
                    Name = "Team Leader"
                },
                new ProjectRole
                {
                    Id = 3,
                    ShortName = "PM",
                    Name = "Project Manager"
                },
                new ProjectRole
                {
                    Id = 4,
                    ShortName = "DevOps",
                    Name = "DevOps"
                },
                new ProjectRole
                {
                    Id = 5,
                    ShortName = "HR",
                    Name = "Human Resource"
                },
                new ProjectRole
                {
                    Id = 6,
                    ShortName = "SDET",
                    Name = "Software Development Engineer in Test"
                },
                new ProjectRole
                {
                    Id = 7,
                    ShortName = "Backend",
                    Name = "Backend developer"
                },
                new ProjectRole
                {
                    Id = 8,
                    ShortName = "Frontend",
                    Name = "Frontend developer"
                },
                new ProjectRole
                {
                    Id = 9,
                    ShortName = "Mobile",
                    Name = "Mobile developer"
                },
                new ProjectRole
                {
                    Id = 10,
                    ShortName = "QA",
                    Name = "Quality Assurance"
                },
                new ProjectRole
                {
                    Id = 11,
                    ShortName = "UI",
                    Name = "User Interface Designer"
                },
                new ProjectRole
                {
                    Id = 12,
                    ShortName = "UX",
                    Name = "User Experience Designer"
                });
        }
    }
}
