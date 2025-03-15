using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class addingNameAtributeToChats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50768052-8adc-4bb4-84cd-044930c3b929", "AQAAAAIAAYagAAAAEMbxJ/hiwf9efpNJDOiWSxd44sVHeNB5qI9mbGWwEGdAwN6qdRXUMh72o7qMqYB+GA==", "c6f4c1c7-0fec-4150-b0c3-81c06b60b88e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Chats");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37bdb242-ad57-48a5-bf16-05767f306f5b", "AQAAAAIAAYagAAAAEAdr3fVAs02pM99e6qPHZ/XebGOVmj0NjpMoPekVj7LdtOGGkSqbpA2JO516IYj8+Q==", "0c93c757-5a92-49a3-9f02-98f73bedac48" });
        }
    }
}
