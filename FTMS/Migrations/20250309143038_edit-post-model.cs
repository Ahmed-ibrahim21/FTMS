using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class editpostmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "posts");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "posts",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "Video",
                table: "posts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcd89365-4c31-40ae-a424-a262544e99d3", "AQAAAAIAAYagAAAAEPTUXR4DplLu2dPb9XVvKUEnvaFmx76nCcZrhTHdmCLM+UyX/o9AL1zK3dXuwja7Ng==", "15fd71b6-d679-453a-8226-6caf22ef420d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Video",
                table: "posts");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "posts",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84e46992-a39f-4cc3-9137-4e6ca760d814", "AQAAAAIAAYagAAAAEEu29yrfm+NUlJQskSwZn1AiiVGjcQ6sCmRjghH5raYYaVID5nvUhn4FtsCpVz0XVQ==", "4f016874-a117-491c-951f-7e15d0841af2" });
        }
    }
}
