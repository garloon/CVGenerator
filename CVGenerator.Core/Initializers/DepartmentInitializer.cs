using Microsoft.EntityFrameworkCore;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Initializers
{
    public static class DepartmentInitializer
    {
        public const long AdministratorId = 10;
        public const long SupervisorId = 11;
        public const long AccountId = 12;

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = AdministratorId,
                    Name = "Administrators",
                    Role = Role.Administrator,
                    IsApplicationDepartment = true
                },
                new Department
                {
                    Id = SupervisorId,
                    Name = "Supervisors",
                    Role = Role.Supervisor,
                    IsApplicationDepartment = true
                },
                new Department
                {
                    Id = AccountId,
                    Name = "Accounts",
                    Role = Role.Account,
                    IsApplicationDepartment = true
                });
        }
    }
}
