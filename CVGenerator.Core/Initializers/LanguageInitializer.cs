using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Initializers
{
    public static class LanguageInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    Id = 1,
                    Name = "Английский"
                },
                new Language
                {
                    Id = 2,
                    Name = "Французский"
                },
                new Language
                {
                    Id = 3,
                    Name = "Немецкий"
                },
                new Language
                {
                    Id = 4,
                    Name = "Испанский"
                },
                new Language
                {
                    Id = 5,
                    Name = "Португальский"
                },
                new Language
                {
                    Id = 6,
                    Name = "Турецкий"
                },
                new Language
                {
                    Id = 7,
                    Name = "Арабский"
                },
                new Language
                {
                    Id = 8,
                    Name = "Китайский"
                },
                new Language
                {
                    Id = 9,
                    Name = "Японский"
                }
            );
        }
    }
}
