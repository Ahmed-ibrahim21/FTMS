using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class addUserGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "UserGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25760112-a435-4ef5-b77c-d9f60ded058e", "AQAAAAIAAYagAAAAEEH2n9E0UPjRuJJtwcEVvryUI9ih8n3aIMQIJ1xN7WP7zqCYeb1jWYd+uER0z05lGg==", "0ade6ec4-ad07-4d49-a1d9-4011a7292567" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserGroups");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ceaf80a9-c704-479a-928b-3cb7bef99ab4", "AQAAAAIAAYagAAAAENH5acA5fbtXESDl72ASEhzR5AH9Al//LLAFvF1I1oiCVvz7dvN7GIuov9M/nXBauw==", "162d4318-8136-48c4-acfc-7f4702c77f25" });
        }
    }
}
