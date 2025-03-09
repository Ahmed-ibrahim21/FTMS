using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class AddIsApproved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "IsApproved", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cdc9377-3d54-4822-b6d5-12ff84a75959", true, "AQAAAAIAAYagAAAAEDpe7gw1BdajofYzrnENi0k24KKvURscnPDdxcP2C+C+/DucaBB0/QT4up1FxJ7SSg==", "c665ec0d-3052-4a34-baeb-28e0c25b09a8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25760112-a435-4ef5-b77c-d9f60ded058e", "AQAAAAIAAYagAAAAEEH2n9E0UPjRuJJtwcEVvryUI9ih8n3aIMQIJ1xN7WP7zqCYeb1jWYd+uER0z05lGg==", "0ade6ec4-ad07-4d49-a1d9-4011a7292567" });
        }
    }
}
