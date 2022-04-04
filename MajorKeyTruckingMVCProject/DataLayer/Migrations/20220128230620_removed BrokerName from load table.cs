using Microsoft.EntityFrameworkCore.Migrations;

namespace MajorKeyTruckingMVCProject.Migrations
{
    public partial class removedBrokerNamefromloadtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrokerName",
                table: "Loads");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrokerName",
                table: "Loads",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
