using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Initializers
{
    public static class EmployeeInitializer
    {
        public const long SUPERADMIN_USER_ID = 10;

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = SUPERADMIN_USER_ID,
                    Email = "superadmin@simbirsoft.com",
                    FirstName = "admin",
                    LastName = "super",
                    Status = EmployeeStatus.ACTIVE,
                    Login = "superadmin",
                });
        }

    }
}
