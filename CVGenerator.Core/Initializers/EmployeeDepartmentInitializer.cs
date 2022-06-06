using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Initializers
{
    public static class EmployeeDepartmentInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDepartment>().HasData(
                new EmployeeDepartment
                {
                    Id = 1,
                    DepartmentId = DepartmentInitializer.AdministratorId,
                    EmployeeId = EmployeeInitializer.SUPERADMIN_USER_ID
                });
        }
    }
}
