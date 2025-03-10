using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class addStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UserGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddbb1e64-dbea-4275-9811-88f9575f4eb7", "AQAAAAIAAYagAAAAEFeYpfCsQcEhsTE1sawOA6IWF9s0uDktK3E7/zqnANMS7T2gL2KwCDRnD94qemlsuQ==", "671ce4d6-325a-4ebc-8c01-a67a8f89212a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserGroups");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80326001-10c2-496b-8dae-ad895824b3eb", "AQAAAAIAAYagAAAAEDuwlXbUQwNR9sI63NnLo42MjhAauzWenzrPOLrGbhrnslWPLm3s97I93uXMfPmc4g==", "14bddbae-0581-4787-918f-9a294a55a001" });
        }
    }
}
