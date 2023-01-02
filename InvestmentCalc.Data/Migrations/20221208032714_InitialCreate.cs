using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investment_Calc.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrentValue = table.Column<double>(type: "REAL", nullable: true),
                    Depreciation = table.Column<double>(type: "REAL", nullable: true),
                    StartValue = table.Column<double>(type: "REAL", nullable: false),
                    SalvageValue = table.Column<double>(type: "REAL", nullable: false),
                    Expiration = table.Column<double>(type: "REAL", nullable: false),
                    EnterDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerText = table.Column<string>(type: "TEXT", nullable: false),
                    SupportText = table.Column<string>(type: "TEXT", nullable: false),
                    isResolved = table.Column<bool>(type: "INTEGER", nullable: false),
                    ContactType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    CmpPerYr = table.Column<int>(type: "INTEGER", nullable: false),
                    Years = table.Column<int>(type: "INTEGER", nullable: false),
                    Interest = table.Column<double>(type: "REAL", nullable: false),
                    Principle = table.Column<double>(type: "REAL", nullable: false),
                    FutureValue = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Classification = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
