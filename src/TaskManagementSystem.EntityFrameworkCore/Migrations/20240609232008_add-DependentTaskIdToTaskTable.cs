using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addDependentTaskIdToTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DependentTaskId",
                table: "TaskSheets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDependentOnAnotherTask",
                table: "TaskSheets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_TaskSheets_DependentTaskId",
                table: "TaskSheets",
                column: "DependentTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSheets_TaskSheets_DependentTaskId",
                table: "TaskSheets",
                column: "DependentTaskId",
                principalTable: "TaskSheets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSheets_TaskSheets_DependentTaskId",
                table: "TaskSheets");

            migrationBuilder.DropIndex(
                name: "IX_TaskSheets_DependentTaskId",
                table: "TaskSheets");

            migrationBuilder.DropColumn(
                name: "DependentTaskId",
                table: "TaskSheets");

            migrationBuilder.DropColumn(
                name: "IsDependentOnAnotherTask",
                table: "TaskSheets");
        }
    }
}
