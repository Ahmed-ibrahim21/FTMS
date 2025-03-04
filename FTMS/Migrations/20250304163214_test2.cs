using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c5d3a4a-b1ac-4528-97f6-4af4ab0b8d06", "AQAAAAIAAYagAAAAELN60nYF5DBmmw/AE8caucwmUPUAnF+A00/iIxjDKHbc2WsTgQ6JWCDbgmyXJYl/NA==", "f7109fe9-e6ab-425f-81a7-369d631126bb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23ed600a-4b73-4f81-a048-40fc99c4f6aa", "AQAAAAIAAYagAAAAEMK0Nci/a66ru5GH/KLHf+DdC+Kxbeeu71AGPvwJFfs1A62aE83BalZMUhE5gj1qyw==", "674b42e3-d9b0-470a-b326-b46f8efced60" });
        }
    }
}
