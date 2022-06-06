using MappingProfile = CVGenerator.Core.Mapping.MappingProfile;
using CVGenerator.Core.RequestHelper;
using CVGenerator.Core.Services;
using CVGenerator.Core.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CVGenerator.Core.Services.Interfaces;
using CVGenerator.Core.Repositories.Interfaces;
using CVGenerator.Core.Repositories;
using CVGenerator.Core.Repositories.Interfaces.Rules;
using CVGenerator.Core.Repositories.Rules;
using CVGenerator.Core;
using CVGenerator.Core.Operations;
using CVGenerator.Core.Operations.Cv.Generate;
using Microsoft.EntityFrameworkCore;
using CVGenerator.Core.Extensions;
using Hangfire;
using Hangfire.PostgreSql;
using Hangfire.Common;
using CVGenerator.Core.Synchronizer;
using CVGenerator.Core.Synchronizer.Interfaces;
using CVGenerator.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace CVGenerator.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(MappingProfile).Assembly,
                typeof(Configuration.MappingProfile).Assembly);

            var connectionString = Configuration.GetConnectionString("CvGeneratorDb");

            services.AddDbContext<GeneratorContext>(opt => opt
                .UseNpgsql(
                    connectionString,
                    sqlOpt => sqlOpt.CommandTimeout(60)
                )
            );

            services.AddHangfire(x => x
            .UseRecommendedSerializerSettings()
            .UsePostgreSqlStorage(Configuration.GetConnectionString("HangfireConnection")));

            services.AddHangfireServer();

            services.AddScoped<CurrentUser>();

            services.Configure<LdapOptions>(Configuration.GetSection("LdapOptions"));
            services.Configure<SuperAdminUser>(Configuration.GetSection("SuperAdminUser"));
            services.Configure<MeSecurity>(Configuration.GetSection("MeSecurity"));
            services.Configure<MeUri>(Configuration.GetSection("MeUri"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = new PathString("/Auth/Login");
                        options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
                        options.LogoutPath = new PathString("/");
                    });

            #region Repositories

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ICvRepository, CvRepository>();
            services.AddTransient<ICvSettingsRepository, CvSettingsRepository>();
            services.AddTransient<ICertificateRepository, CertificateRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IHardSkillRepository, HardSkillRepository>();
            services.AddTransient<IEducationRepository, EducationRepository>();
            services.AddTransient<IEmployeeProfessionalAbilityRepository, EmployeeAbilityRepository>();
            services.AddTransient<IEmployeeDepartmentRepository, EmployeeDepartmentRepository>();
            services.AddTransient<IEmployeeEducationRepository, EmployeeEducationRepository>();
            services.AddTransient<IEmployeeHardSkillRepository, EmployeeHardSkillRepository>();
            services.AddTransient<IEmployeeCertificateRepository, EmployeeCertificateRepository>();
            services.AddTransient<IEmployeeLanguageRepository, EmployeeLanguageRepository>();
            services.AddTransient<IEmployeeProjectRepository, EmployeeProjectRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<IProfessionalAbilityRepository, ProfessionalAbilityRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IProjectRoleRepository, ProjectRoleRepository>();
            services.AddTransient<IProjectHardSkillRepository, ProjectHardSkillRepository>();
            services.AddTransient<ITemporaryReferenceRepository, TemporaryReferenceRepository>();

            services.AddTransient<IProjectRuleRepository, ProjectRuleRepository>();
            services.AddTransient<ILanguageRuleRepository, LanguageRuleRepository>();
            services.AddTransient<IEducationRuleRepository, EducationRuleRepository>();
            services.AddTransient<IHardSkillRuleRepository, HardSkillRuleRepository>();
            services.AddTransient<ICertificateRuleRepository, CertificateRuleRepository>();
            services.AddTransient<IProfessionalAbilityRuleRepository, ProfessionalAbilityRuleRepository>();

            services.AddTransient<IGeneratorRepository, GeneratorRepository>();
            services.AddScoped<ISynchronizeFactory, SynchronizeFactory>();

            #endregion

            services.AddScoped<ICvOperations, CvOperations>();
            services.AddScoped<CvRulesBuilder>();

            services.AddScoped<HttpClientBuilder>();
            services.AddScoped<IRequestHelper, RequestHelper>();
            services.AddSingleton<MeAuthService>();

            services.AddControllersWithViews();
            services.AddLogging();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHangfireDashboard();

            RecurringJob.AddOrUpdate<ActualizeCookieJob>("ActualizeCookieJob", x => x.RunAsync(), Cron.Daily());
            RecurringJob.AddOrUpdate<SynchronizeDepartmentJob>("SyncronizeDepartmentsJob", x => x.RunAsync(), Cron.Daily());
            RecurringJob.AddOrUpdate<SynchronizeEmployeeJob>("SynchronizeEmployeeJob", x => x.RunAsync(), Cron.Daily());
            RecurringJob.AddOrUpdate<SynchronizeProjectJob>("SynchronizeProjectJob", x => x.RunAsync(), Cron.Daily());
            RecurringJob.AddOrUpdate<SynchronizeCertificatesJob>("SynchronizeCertificatesJob", x => x.RunAsync(), Cron.Daily());
            RecurringJob.AddOrUpdate<SynchronizeHardSkillsJob>("SynchronizeHardSkillsJob", x => x.RunAsync(), Cron.Daily());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
