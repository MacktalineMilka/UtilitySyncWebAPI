using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtilityDataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountsMeterReadings",
                columns: table => new
                {
                    UserAccountMeterReadingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    MeterReadingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeterReadValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountsMeterReadings", x => x.UserAccountMeterReadingID);
                    table.ForeignKey(
                        name: "FK_UserAccountsMeterReadings_UserAccounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "UserAccounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountsMeterReadings_AccountID",
                table: "UserAccountsMeterReadings",
                column: "AccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccountsMeterReadings");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
