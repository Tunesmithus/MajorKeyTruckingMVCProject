using Microsoft.EntityFrameworkCore.Migrations;

namespace MajorKeyTruckingMVCProject.Migrations
{
    public partial class seededbrokertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brokers",
                columns: new[] { "BrokerId", "BrokerCompanyName", "BrokerEmail", "BrokerPhoneNumber" },
                values: new object[] { 1, "Landstar", "info@landstar.com", "5042330456" });

            migrationBuilder.InsertData(
                table: "Brokers",
                columns: new[] { "BrokerId", "BrokerCompanyName", "BrokerEmail", "BrokerPhoneNumber" },
                values: new object[] { 2, "JB Hung", "info@JBHunt.com", "5042330456" });

            migrationBuilder.InsertData(
                table: "Brokers",
                columns: new[] { "BrokerId", "BrokerCompanyName", "BrokerEmail", "BrokerPhoneNumber" },
                values: new object[] { 3, "R2 Logistics", "info@R2Logistics.com", "5042330456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brokers",
                keyColumn: "BrokerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brokers",
                keyColumn: "BrokerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brokers",
                keyColumn: "BrokerId",
                keyValue: 3);
        }
    }
}
