using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class updatingChatSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bf9722b-0692-402b-9dee-64481978bbc5", "AQAAAAIAAYagAAAAEOmIe0Eym03Ss/N1iHjQCNk5Vmoo1r0JD4eY8LyZAW29KHEPy65ZgyPy4y0ozXgjLg==", "a5d8fbd9-15f7-4e8f-94c7-cdcadb7bfb35" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c77f0c4b-be38-4552-916a-860aa3dfa383", "AQAAAAIAAYagAAAAEK8l5tOfuVUchVIh8XfZJF0xD/xp9dCjLiM7b8SbEwdwmmeLGbqs1ymYsmPy3l/2Fg==", "5ce04449-e6ea-4ba7-a180-c04d838f88e1" });
        }
    }
}
