using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class updated_Chat_Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChatId",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76a193ba-fe36-4812-bef4-b4b293990b80", "AQAAAAIAAYagAAAAEI65dEe4bcR7gxFwf9EQGJhgIknCgKrY7r737d9O6ppXyfY7Ov2OpnmPuzx/245Y7w==", "0180b0f6-f365-42bf-83f3-5e500dc48695" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Chats");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c5d3a4a-b1ac-4528-97f6-4af4ab0b8d06", "AQAAAAIAAYagAAAAELN60nYF5DBmmw/AE8caucwmUPUAnF+A00/iIxjDKHbc2WsTgQ6JWCDbgmyXJYl/NA==", "f7109fe9-e6ab-425f-81a7-369d631126bb" });
        }
    }
}
