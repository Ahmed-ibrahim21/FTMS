using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class editpkpostmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "posts",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8eaf9538-d176-471f-95ab-932277d4aa17", "AQAAAAIAAYagAAAAEMQsbH/SyKRsFzPwE7OopT22OVXuL7Pg58geelIRKs1tVeD1EIeTGolOS0v3CRtS6w==", "cd731c77-6c59-4521-972f-9e01da279a9a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "posts",
                newName: "PostId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbbd64cc-ce4a-4be8-931f-6e3bb6f6e7c3", "AQAAAAIAAYagAAAAEMZboZXjVHU5g2+0aXrv4PnTX79MgGQV1SM2LVtzZ6azpnBwefPxzJwajkTkfj748A==", "431d8704-dfee-43d9-9fa6-88c32b023204" });
        }
    }
}
