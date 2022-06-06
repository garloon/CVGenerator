using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CVGenerator.Core.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "certificates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "varchar(400)", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cv_settings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cv_settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    IsApplicationDepartment = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsForCv = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ExternalId = table.Column<string>(type: "varchar(150)", nullable: true),
                    IsLocation = table.Column<bool>(type: "boolean", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "educations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniversityName = table.Column<string>(type: "varchar(150)", nullable: false),
                    SpecialtyName = table.Column<string>(type: "varchar(150)", nullable: true),
                    TypeSpecialty = table.Column<int>(type: "integer", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "varchar(150)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(150)", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(150)", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Login = table.Column<string>(type: "varchar(60)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    ExternalId = table.Column<long>(type: "bigint", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hard_skills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "varchar(200)", nullable: true),
                    Title = table.Column<string>(type: "varchar(200)", nullable: false),
                    Type = table.Column<string>(type: "varchar(200)", nullable: true),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hard_skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "professional_abilities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    PositionId = table.Column<long>(type: "bigint", nullable: false),
                    Required = table.Column<bool>(type: "boolean", nullable: false),
                    SectionId = table.Column<long>(type: "bigint", nullable: false),
                    ExternalId = table.Column<long>(type: "bigint", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professional_abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "project_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShortName = table.Column<string>(type: "varchar(15)", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    IsPersonal = table.Column<bool>(type: "boolean", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Description = table.Column<string>(type: "varchar(3000)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    IsPersonal = table.Column<bool>(type: "boolean", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "certificate_rules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CertificateId = table.Column<long>(type: "bigint", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L),
                    CvSettingsId = table.Column<long>(type: "bigint", nullable: false),
                    IsShow = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificate_rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_certificate_rules_certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_certificate_rules_cv_settings_CvSettingsId",
                        column: x => x.CvSettingsId,
                        principalTable: "cv_settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professional_ability_rules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L),
                    CvSettingsId = table.Column<long>(type: "bigint", nullable: false),
                    IsShow = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professional_ability_rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_professional_ability_rules_cv_settings_CvSettingsId",
                        column: x => x.CvSettingsId,
                        principalTable: "cv_settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "education_rules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EducationId = table.Column<long>(type: "bigint", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L),
                    CvSettingsId = table.Column<long>(type: "bigint", nullable: false),
                    IsShow = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_education_rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_education_rules_cv_settings_CvSettingsId",
                        column: x => x.CvSettingsId,
                        principalTable: "cv_settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_education_rules_educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(350)", nullable: false),
                    DepartmentName = table.Column<string>(type: "varchar(150)", nullable: false),
                    CvSettingsId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cv_cv_settings_CvSettingsId",
                        column: x => x.CvSettingsId,
                        principalTable: "cv_settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cv_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_certificates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    CertificateId = table.Column<long>(type: "bigint", nullable: false),
                    ExternalId = table.Column<long>(type: "bigint", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_certificates_certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_certificates_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_departments_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_departments_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_educations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EducationId = table.Column<long>(type: "bigint", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_educations_educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_educations_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_hard_skills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AbilityLevel = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    HardSkillId = table.Column<long>(type: "bigint", nullable: false),
                    ExternalId = table.Column<long>(type: "bigint", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_hard_skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_hard_skills_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_hard_skills_hard_skills_HardSkillId",
                        column: x => x.HardSkillId,
                        principalTable: "hard_skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hard_skill_rules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HardSkillId = table.Column<long>(type: "bigint", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L),
                    CvSettingsId = table.Column<long>(type: "bigint", nullable: false),
                    IsShow = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hard_skill_rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hard_skill_rules_cv_settings_CvSettingsId",
                        column: x => x.CvSettingsId,
                        principalTable: "cv_settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hard_skill_rules_hard_skills_HardSkillId",
                        column: x => x.HardSkillId,
                        principalTable: "hard_skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageLevel = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_languages_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_languages_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "language_rules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageLevel = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L),
                    CvSettingsId = table.Column<long>(type: "bigint", nullable: false),
                    IsShow = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language_rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_language_rules_cv_settings_CvSettingsId",
                        column: x => x.CvSettingsId,
                        principalTable: "cv_settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_language_rules_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_abilities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    ProfessionalAbilityId = table.Column<long>(type: "bigint", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_abilities_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_abilities_professional_abilities_ProfessionalAbili~",
                        column: x => x.ProfessionalAbilityId,
                        principalTable: "professional_abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "project_rules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShowName = table.Column<string>(type: "varchar(200)", nullable: false),
                    MyTasks = table.Column<string>(type: "varchar(3000)", nullable: false),
                    DescriptionProject = table.Column<string>(type: "varchar(3000)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ProjectRoleId = table.Column<int>(type: "integer", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L),
                    CvSettingsId = table.Column<long>(type: "bigint", nullable: false),
                    IsShow = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_project_rules_cv_settings_CvSettingsId",
                        column: x => x.CvSettingsId,
                        principalTable: "cv_settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_project_rules_project_roles_ProjectRoleId",
                        column: x => x.ProjectRoleId,
                        principalTable: "project_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShowName = table.Column<string>(type: "varchar(200)", nullable: true),
                    DescriptionProject = table.Column<string>(type: "varchar(3000)", nullable: true),
                    MyTasks = table.Column<string>(type: "varchar(3000)", nullable: true),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectRoleId = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_projects_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_projects_project_roles_ProjectRoleId",
                        column: x => x.ProjectRoleId,
                        principalTable: "project_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employee_projects_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "project_hard_skills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    HardSkillId = table.Column<long>(type: "bigint", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_hard_skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_project_hard_skills_hard_skills_HardSkillId",
                        column: x => x.HardSkillId,
                        principalTable: "hard_skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_project_hard_skills_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "temporaries_references",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpirationTimeout = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CvId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberDownloads = table.Column<long>(type: "bigint", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temporaries_references", x => x.Id);
                    table.ForeignKey(
                        name: "FK_temporaries_references_cv_CvId",
                        column: x => x.CvId,
                        principalTable: "cv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "Created", "Deleted", "ExternalId", "IsApplicationDepartment", "IsLocation", "Name", "Role", "Updated" },
                values: new object[,]
                {
                    { 10L, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(7425), null, null, true, false, "Administrators", 4, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(7797) },
                    { 11L, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(9411), null, null, true, false, "Supervisors", 3, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(9413) },
                    { 12L, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(9417), null, null, true, false, "Accounts", 2, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(9417) }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "Created", "Deleted", "Email", "ExternalId", "FirstName", "LastName", "Login", "MiddleName", "Status", "Updated" },
                values: new object[] { 10L, new DateTime(2022, 5, 20, 9, 8, 41, 833, DateTimeKind.Utc).AddTicks(4398), null, "superadmin@simbirsoft.com", null, "admin", "super", "superadmin", null, 1, new DateTime(2022, 5, 20, 9, 8, 41, 833, DateTimeKind.Utc).AddTicks(4404) });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "Id", "Created", "Deleted", "Name", "Updated" },
                values: new object[,]
                {
                    { 8, new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6138), null, "Китайский", new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6139) },
                    { 7, new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6136), null, "Арабский", new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6137) },
                    { 6, new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6133), null, "Турецкий", new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6134) },
                    { 5, new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6131), null, "Португальский", new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6132) },
                    { 9, new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6141), null, "Японский", new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6142) },
                    { 3, new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6125), null, "Немецкий", new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6126) },
                    { 2, new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6117), null, "Французский", new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6121) },
                    { 1, new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(3554), null, "Английский", new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(4423) },
                    { 4, new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6128), null, "Испанский", new DateTime(2022, 5, 20, 9, 8, 41, 830, DateTimeKind.Utc).AddTicks(6129) }
                });

            migrationBuilder.InsertData(
                table: "project_roles",
                columns: new[] { "Id", "Created", "Deleted", "IsPersonal", "Name", "ShortName", "Updated" },
                values: new object[,]
                {
                    { 11, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3736), null, false, "User Interface Designer", "UI", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3736) },
                    { 1, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(2622), null, false, "Tech Leader", "Tech Leader", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(2633) },
                    { 2, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3713), null, false, "Team Leader", "Team Leader", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3716) },
                    { 3, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3719), null, false, "Project Manager", "PM", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3720) },
                    { 4, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3721), null, false, "DevOps", "DevOps", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3722) },
                    { 5, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3723), null, false, "Human Resource", "HR", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3724) },
                    { 6, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3726), null, false, "Software Development Engineer in Test", "SDET", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3726) },
                    { 7, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3728), null, false, "Backend developer", "Backend", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3728) },
                    { 8, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3730), null, false, "Frontend developer", "Frontend", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3730) },
                    { 9, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3732), null, false, "Mobile developer", "Mobile", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3732) },
                    { 10, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3734), null, false, "Quality Assurance", "QA", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3734) },
                    { 12, new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3738), null, false, "User Experience Designer", "UX", new DateTime(2022, 5, 20, 9, 8, 41, 832, DateTimeKind.Utc).AddTicks(3738) }
                });

            migrationBuilder.InsertData(
                table: "employee_departments",
                columns: new[] { "Id", "Created", "Deleted", "DepartmentId", "EmployeeId", "Updated" },
                values: new object[] { 1L, new DateTime(2022, 5, 20, 9, 8, 41, 834, DateTimeKind.Utc).AddTicks(1304), null, 10L, 10L, new DateTime(2022, 5, 20, 9, 8, 41, 834, DateTimeKind.Utc).AddTicks(1308) });

            migrationBuilder.CreateIndex(
                name: "IX_certificate_rules_CertificateId",
                table: "certificate_rules",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_certificate_rules_CvSettingsId",
                table: "certificate_rules",
                column: "CvSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_cv_CvSettingsId",
                table: "cv",
                column: "CvSettingsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cv_EmployeeId",
                table: "cv",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_education_rules_CvSettingsId",
                table: "education_rules",
                column: "CvSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_education_rules_EducationId",
                table: "education_rules",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_abilities_EmployeeId",
                table: "employee_abilities",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_abilities_ProfessionalAbilityId",
                table: "employee_abilities",
                column: "ProfessionalAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_certificates_CertificateId",
                table: "employee_certificates",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_certificates_EmployeeId",
                table: "employee_certificates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_departments_DepartmentId",
                table: "employee_departments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_departments_EmployeeId",
                table: "employee_departments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_educations_EducationId",
                table: "employee_educations",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_educations_EmployeeId",
                table: "employee_educations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_hard_skills_EmployeeId",
                table: "employee_hard_skills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_hard_skills_HardSkillId",
                table: "employee_hard_skills",
                column: "HardSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_languages_EmployeeId",
                table: "employee_languages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_languages_LanguageId",
                table: "employee_languages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_projects_EmployeeId",
                table: "employee_projects",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_projects_ProjectId",
                table: "employee_projects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_projects_ProjectRoleId",
                table: "employee_projects",
                column: "ProjectRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_hard_skill_rules_CvSettingsId",
                table: "hard_skill_rules",
                column: "CvSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_hard_skill_rules_HardSkillId",
                table: "hard_skill_rules",
                column: "HardSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_language_rules_CvSettingsId",
                table: "language_rules",
                column: "CvSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_language_rules_LanguageId",
                table: "language_rules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_professional_ability_rules_CvSettingsId",
                table: "professional_ability_rules",
                column: "CvSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_project_hard_skills_HardSkillId",
                table: "project_hard_skills",
                column: "HardSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_project_hard_skills_ProjectId",
                table: "project_hard_skills",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_project_rules_CvSettingsId",
                table: "project_rules",
                column: "CvSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_project_rules_ProjectRoleId",
                table: "project_rules",
                column: "ProjectRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_temporaries_references_CvId",
                table: "temporaries_references",
                column: "CvId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "certificate_rules");

            migrationBuilder.DropTable(
                name: "education_rules");

            migrationBuilder.DropTable(
                name: "employee_abilities");

            migrationBuilder.DropTable(
                name: "employee_certificates");

            migrationBuilder.DropTable(
                name: "employee_departments");

            migrationBuilder.DropTable(
                name: "employee_educations");

            migrationBuilder.DropTable(
                name: "employee_hard_skills");

            migrationBuilder.DropTable(
                name: "employee_languages");

            migrationBuilder.DropTable(
                name: "employee_projects");

            migrationBuilder.DropTable(
                name: "hard_skill_rules");

            migrationBuilder.DropTable(
                name: "language_rules");

            migrationBuilder.DropTable(
                name: "professional_ability_rules");

            migrationBuilder.DropTable(
                name: "project_hard_skills");

            migrationBuilder.DropTable(
                name: "project_rules");

            migrationBuilder.DropTable(
                name: "temporaries_references");

            migrationBuilder.DropTable(
                name: "professional_abilities");

            migrationBuilder.DropTable(
                name: "certificates");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "educations");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "hard_skills");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "project_roles");

            migrationBuilder.DropTable(
                name: "cv");

            migrationBuilder.DropTable(
                name: "cv_settings");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
