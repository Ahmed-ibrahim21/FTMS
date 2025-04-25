using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class editFriendRequestModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SentDate",
                table: "FriendRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50dddfed-7a43-4518-a1c7-55485910a8da", "AQAAAAIAAYagAAAAEEPYoMlftv0VYA0P4rUQynInVwN1gmOv7DX9o+0t8vogpVzOERwOo73wuWZBcdeRBw==", "b568d290-b817-498d-b2fd-93baac34e684" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SentDate",
                table: "FriendRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8eaf9538-d176-471f-95ab-932277d4aa17", "AQAAAAIAAYagAAAAEMQsbH/SyKRsFzPwE7OopT22OVXuL7Pg58geelIRKs1tVeD1EIeTGolOS0v3CRtS6w==", "cd731c77-6c59-4521-972f-9e01da279a9a" });
        }
    }
}
