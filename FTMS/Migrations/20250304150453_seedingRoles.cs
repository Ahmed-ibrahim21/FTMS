using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class seedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a1fd89c-7b59-43cb-83d1-a8c2fd076ecb", null, "Admin", "ADMIN" },
                    { "91e7fdac-1d43-4b3d-9138-a50f3e42fff3", null, "User", "USER" },
                    { "c3eaa6b6-07ff-4b25-a7b9-0b1ac27b5823", null, "Trainer", "TRAINER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePic", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cad19e16-1ae8-4e8f-a38a-885efd44f7a2", 0, "6894e06c-c629-463f-bdda-46aef1551601", "User", "admin@example.com", true, "System", "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEIZvYF4XzE5INMld64xZfExPONDxDwuZ8agKbumfpXS1Z3smVbrtNilENpFUiAxgfg==", null, false, new byte[0], "4de56519-c7f5-48ae-9526-df34250ca5a7", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5a1fd89c-7b59-43cb-83d1-a8c2fd076ecb", "cad19e16-1ae8-4e8f-a38a-885efd44f7a2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91e7fdac-1d43-4b3d-9138-a50f3e42fff3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3eaa6b6-07ff-4b25-a7b9-0b1ac27b5823");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a1fd89c-7b59-43cb-83d1-a8c2fd076ecb", "cad19e16-1ae8-4e8f-a38a-885efd44f7a2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a1fd89c-7b59-43cb-83d1-a8c2fd076ecb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cad19e16-1ae8-4e8f-a38a-885efd44f7a2");
        }
    }
}
