using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MajorKeyTruckingMVCProject.Migrations
{
    public partial class Addedbrokerandexpensetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrokerId",
                table: "Loads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brokers",
                columns: table => new
                {
                    BrokerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrokerCompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrokerPhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BrokerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brokers", x => x.BrokerId);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpenseCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    TrailerId = table.Column<int>(type: "int", nullable: false),
                    TruckId = table.Column<int>(type: "int", nullable: false),
                    LoadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expenses_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Loads_LoadId",
                        column: x => x.LoadId,
                        principalTable: "Loads",
                        principalColumn: "LoadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_Trailers_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailers",
                        principalColumn: "TrailerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "TruckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loads_BrokerId",
                table: "Loads",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_DriverId",
                table: "Expenses",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_LoadId",
                table: "Expenses",
                column: "LoadId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TrailerId",
                table: "Expenses",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TruckId",
                table: "Expenses",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Brokers_BrokerId",
                table: "Loads",
                column: "BrokerId",
                principalTable: "Brokers",
                principalColumn: "BrokerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Brokers_BrokerId",
                table: "Loads");

            migrationBuilder.DropTable(
                name: "Brokers");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Loads_BrokerId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "BrokerId",
                table: "Loads");
        }
    }
}
