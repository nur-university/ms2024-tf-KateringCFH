using Microsoft.EntityFrameworkCore.Migrations;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

#nullable disable

namespace ServicioCatering.Infrastructure.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CateringContracts",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                NutritionPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CateringContracts", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "NutritionPlans",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Objectives = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_NutritionPlans", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "CateringContracts");
        migrationBuilder.DropTable(name: "NutritionPlans");
    }
}
