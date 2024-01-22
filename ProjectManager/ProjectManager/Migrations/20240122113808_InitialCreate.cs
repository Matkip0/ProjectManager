using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TeamID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentTaskTaskId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Team_Task_CurrentTaskTaskId",
                        column: x => x.CurrentTaskTaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId");
                });

            migrationBuilder.CreateTable(
                name: "TeamWorker",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamWorker", x => new { x.TeamID, x.WorkerID });
                    table.ForeignKey(
                        name: "FK_TeamWorker_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    TodoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    TaskId = table.Column<int>(type: "INTEGER", nullable: true),
                    WorkerID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.TodoID);
                    table.ForeignKey(
                        name: "FK_Todo_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId");
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    WorkerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentTodoTodoID = table.Column<int>(type: "INTEGER", nullable: true),
                    TodoID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.WorkerID);
                    table.ForeignKey(
                        name: "FK_Worker_Todo_CurrentTodoTodoID",
                        column: x => x.CurrentTodoTodoID,
                        principalTable: "Todo",
                        principalColumn: "TodoID");
                    table.ForeignKey(
                        name: "FK_Worker_Todo_TodoID",
                        column: x => x.TodoID,
                        principalTable: "Todo",
                        principalColumn: "TodoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_TeamID",
                table: "Task",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CurrentTaskTaskId",
                table: "Team",
                column: "CurrentTaskTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamWorker_WorkerID",
                table: "TeamWorker",
                column: "WorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_TaskId",
                table: "Todo",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_WorkerID",
                table: "Todo",
                column: "WorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_CurrentTodoTodoID",
                table: "Worker",
                column: "CurrentTodoTodoID");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_TodoID",
                table: "Worker",
                column: "TodoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Team_TeamID",
                table: "Task",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorker_Worker_WorkerID",
                table: "TeamWorker",
                column: "WorkerID",
                principalTable: "Worker",
                principalColumn: "WorkerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Worker_WorkerID",
                table: "Todo",
                column: "WorkerID",
                principalTable: "Worker",
                principalColumn: "WorkerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Team_TeamID",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Task_TaskId",
                table: "Todo");

            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Worker_WorkerID",
                table: "Todo");

            migrationBuilder.DropTable(
                name: "TeamWorker");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Todo");
        }
    }
}
