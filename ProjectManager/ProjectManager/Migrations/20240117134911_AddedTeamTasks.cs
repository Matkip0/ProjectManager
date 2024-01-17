using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Migrations
{
    /// <inheritdoc />
    public partial class AddedTeamTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentTodoTodoID",
                table: "Worker",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkerID",
                table: "Todo",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentTaskTaskId",
                table: "Team",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Task",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Worker_CurrentTodoTodoID",
                table: "Worker",
                column: "CurrentTodoTodoID");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_WorkerID",
                table: "Todo",
                column: "WorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CurrentTaskTaskId",
                table: "Team",
                column: "CurrentTaskTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TeamID",
                table: "Task",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Team_TeamID",
                table: "Task",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Task_CurrentTaskTaskId",
                table: "Team",
                column: "CurrentTaskTaskId",
                principalTable: "Task",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Worker_WorkerID",
                table: "Todo",
                column: "WorkerID",
                principalTable: "Worker",
                principalColumn: "WorkerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Todo_CurrentTodoTodoID",
                table: "Worker",
                column: "CurrentTodoTodoID",
                principalTable: "Todo",
                principalColumn: "TodoID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Team_TeamID",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Task_CurrentTaskTaskId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Worker_WorkerID",
                table: "Todo");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Todo_CurrentTodoTodoID",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Worker_CurrentTodoTodoID",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Todo_WorkerID",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Team_CurrentTaskTaskId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Task_TeamID",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "CurrentTodoTodoID",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "WorkerID",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "CurrentTaskTaskId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Task");
        }
    }
}
