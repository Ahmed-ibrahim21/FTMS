using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class addcreatedby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ceaf80a9-c704-479a-928b-3cb7bef99ab4", "AQAAAAIAAYagAAAAENH5acA5fbtXESDl72ASEhzR5AH9Al//LLAFvF1I1oiCVvz7dvN7GIuov9M/nXBauw==", "162d4318-8136-48c4-acfc-7f4702c77f25" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Groups");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f524328-0295-43ed-b91e-8ab0d15cd92f", "AQAAAAIAAYagAAAAELdKsIfpDRP/nsl7YAf6Fn3xmIZsO2fGwge198gINffQ2w2StKHzeFjOlJLFAh+C1A==", "e4e68939-f835-4844-8b6d-0eefafd63e5b" });
        }
    }
}
