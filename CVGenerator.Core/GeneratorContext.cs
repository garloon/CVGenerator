using System.Reflection;
using CVGenerator.Core.Data.EntityConfigurations;
using CVGenerator.Core.Initializers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core
{
	public class GeneratorContext : DbContext
    {
        public GeneratorContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(TemporaryReferenceConfiguration)));

            // ƒобавление в таблицы начальных записей
            LanguageInitializer.Seed(modelBuilder);
            ProjectRoleInitializer.Seed(modelBuilder);

            DepartmentInitializer.Seed(modelBuilder);
            EmployeeInitializer.Seed(modelBuilder);
            EmployeeDepartmentInitializer.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
