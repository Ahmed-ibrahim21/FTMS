using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e3a7af8-7d2b-448f-93a3-5492da3e799c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5847f0f-de18-4a4c-89c7-542ca1c14262");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e292861f-1daa-4bed-be74-ac22ccac0ff7", "4530a689-ac13-4eff-a645-1d66429c0829" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e292861f-1daa-4bed-be74-ac22ccac0ff7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4530a689-ac13-4eff-a645-1d66429c0829");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31C0AC99-29F4-4A55-AF0F-07402617FC47", null, "User", "USER" },
                    { "C1DA0795-351E-45E3-8C4F-74DA1438BB50", null, "Trainer", "TRAINER" },
                    { "DDC16163-28DC-4325-BECE-56A2B5BBE8E0", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePic", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0BE7B103-1D31-420F-853C-EE3BC9236FB4", 0, "23ed600a-4b73-4f81-a048-40fc99c4f6aa", "User", "admin@gmail.com", true, "System", "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMK0Nci/a66ru5GH/KLHf+DdC+Kxbeeu71AGPvwJFfs1A62aE83BalZMUhE5gj1qyw==", null, false, new byte[0], "674b42e3-d9b0-470a-b326-b46f8efced60", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "DDC16163-28DC-4325-BECE-56A2B5BBE8E0", "0BE7B103-1D31-420F-853C-EE3BC9236FB4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31C0AC99-29F4-4A55-AF0F-07402617FC47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C1DA0795-351E-45E3-8C4F-74DA1438BB50");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "DDC16163-28DC-4325-BECE-56A2B5BBE8E0", "0BE7B103-1D31-420F-853C-EE3BC9236FB4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "DDC16163-28DC-4325-BECE-56A2B5BBE8E0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e3a7af8-7d2b-448f-93a3-5492da3e799c", null, "User", "USER" },
                    { "c5847f0f-de18-4a4c-89c7-542ca1c14262", null, "Trainer", "TRAINER" },
                    { "e292861f-1daa-4bed-be74-ac22ccac0ff7", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePic", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4530a689-ac13-4eff-a645-1d66429c0829", 0, "39cf60bf-9898-4c0e-a167-e3dcb621c3d8", "User", "admin@gmail.com", true, "System", "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEAe/dXADPH/X3xiIp7jyRTAzEfFP6wMHWWdwAAbTJP0yjmQd4BnXF4OgJywKFPBtdQ==", null, false, new byte[0], "6e47fb9f-7021-4a03-9beb-d2136764b8ea", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e292861f-1daa-4bed-be74-ac22ccac0ff7", "4530a689-ac13-4eff-a645-1d66429c0829" });
        }
    }
}
