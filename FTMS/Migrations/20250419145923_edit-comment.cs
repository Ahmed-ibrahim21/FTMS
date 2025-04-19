using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class editcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbbd64cc-ce4a-4be8-931f-6e3bb6f6e7c3", "AQAAAAIAAYagAAAAEMZboZXjVHU5g2+0aXrv4PnTX79MgGQV1SM2LVtzZ6azpnBwefPxzJwajkTkfj748A==", "431d8704-dfee-43d9-9fa6-88c32b023204" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_posts_PostId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2da8eec-ce55-4b18-aab8-2c444e2bc093", "AQAAAAIAAYagAAAAEHgv/c28krrbK65eJkLsH0mQfjDwFSEzcDXcRttvhJfahI/FqJKSj3TZrkmWfqXBOQ==", "a823559a-278f-4b78-84f1-77192bb489a3" });
        }
    }
}
