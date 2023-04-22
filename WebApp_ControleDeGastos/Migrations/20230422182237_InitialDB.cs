using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_ControleDeGastos.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberCard = table.Column<int>(type: "INT", nullable: false),
                    type = table.Column<byte>(type: "TINYINT", nullable: false),
                    Balance = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    Limite = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    InvoiceAmount = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Flag = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    UserId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "VARCHAR(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(60)", nullable: true),
                    type = table.Column<byte>(type: "TINYINT", nullable: false),
                    NumberInstallments = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    NumberCard = table.Column<int>(type: "INT", nullable: false),
                    Date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CategoryName = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    UserId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.ExpenseId);
                });

            migrationBuilder.CreateTable(
                name: "Revenue",
                columns: table => new
                {
                    RevenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    UserId = table.Column<long>(type: "BIGINT", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenue", x => x.RevenueId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Avatar = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Revenue");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
