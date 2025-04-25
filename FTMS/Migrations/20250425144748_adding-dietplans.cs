using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTMS.Migrations
{
    /// <inheritdoc />
    public partial class addingdietplans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietPlans_AspNetUsers_UserId",
                table: "DietPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDiets_DietPlans_DietPlanPlanId",
                table: "UserDiets");

            migrationBuilder.RenameColumn(
                name: "DietPlanPlanId",
                table: "UserDiets",
                newName: "DietPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDiets_DietPlanPlanId",
                table: "UserDiets",
                newName: "IX_UserDiets_DietPlanId");

            migrationBuilder.RenameColumn(
                name: "DietName",
                table: "DietPlans",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "DietPlans",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DietPlans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DietPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TrainerId",
                table: "DietPlans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "dietMeals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dietPlanId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dietMeals", x => x.id);
                    table.ForeignKey(
                        name: "FK_dietMeals_DietPlans_dietPlanId",
                        column: x => x.dietPlanId,
                        principalTable: "DietPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    DietMealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ingredients_dietMeals_DietMealId",
                        column: x => x.DietMealId,
                        principalTable: "dietMeals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be0338c5-aafa-4932-8a2a-25efbbfac581", "AQAAAAIAAYagAAAAEBk11Zp7zOINgEJSCjbVpOWTVWvJK/CVyJeD3uxVbUzfldjZ3k9Sc8oVOm/IZl361Q==", "cbce4691-5161-4861-8c9e-f266fa22419e" });

            migrationBuilder.CreateIndex(
                name: "IX_DietPlans_TrainerId",
                table: "DietPlans",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_dietMeals_dietPlanId",
                table: "dietMeals",
                column: "dietPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DietMealId",
                table: "Ingredients",
                column: "DietMealId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietPlans_AspNetUsers_TrainerId",
                table: "DietPlans",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DietPlans_AspNetUsers_UserId",
                table: "DietPlans",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiets_DietPlans_DietPlanId",
                table: "UserDiets",
                column: "DietPlanId",
                principalTable: "DietPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietPlans_AspNetUsers_TrainerId",
                table: "DietPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_DietPlans_AspNetUsers_UserId",
                table: "DietPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDiets_DietPlans_DietPlanId",
                table: "UserDiets");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "dietMeals");

            migrationBuilder.DropIndex(
                name: "IX_DietPlans_TrainerId",
                table: "DietPlans");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DietPlans");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "DietPlans");

            migrationBuilder.RenameColumn(
                name: "DietPlanId",
                table: "UserDiets",
                newName: "DietPlanPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDiets_DietPlanId",
                table: "UserDiets",
                newName: "IX_UserDiets_DietPlanPlanId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DietPlans",
                newName: "DietName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DietPlans",
                newName: "PlanId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DietPlans",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0BE7B103-1D31-420F-853C-EE3BC9236FB4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50dddfed-7a43-4518-a1c7-55485910a8da", "AQAAAAIAAYagAAAAEEPYoMlftv0VYA0P4rUQynInVwN1gmOv7DX9o+0t8vogpVzOERwOo73wuWZBcdeRBw==", "b568d290-b817-498d-b2fd-93baac34e684" });

            migrationBuilder.AddForeignKey(
                name: "FK_DietPlans_AspNetUsers_UserId",
                table: "DietPlans",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiets_DietPlans_DietPlanPlanId",
                table: "UserDiets",
                column: "DietPlanPlanId",
                principalTable: "DietPlans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
