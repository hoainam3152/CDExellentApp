using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExellentAPI.Migrations
{
    public partial class Add_Manage_SurveyRequest_Notification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SurveyID",
                table: "Survey",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notification_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyRequest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SurveyRequest_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receives",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    IsSeen = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receives", x => new { x.NotificationId, x.ReceiverId });
                    table.ForeignKey(
                        name: "FK_Receives_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receives_User_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SurveyAssignee",
                columns: table => new
                {
                    SurveyRequestId = table.Column<int>(type: "int", nullable: false),
                    AssigneeId = table.Column<int>(type: "int", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAssignee", x => new { x.SurveyRequestId, x.AssigneeId });
                    table.ForeignKey(
                        name: "FK_SurveyAssignee_SurveyRequest_SurveyRequestId",
                        column: x => x.SurveyRequestId,
                        principalTable: "SurveyRequest",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyAssignee_User_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Survey_SurveyID",
                table: "Survey",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CreatorId",
                table: "Notification",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Receives_ReceiverId",
                table: "Receives",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAssignee_AssigneeId",
                table: "SurveyAssignee",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyRequest_SurveyId",
                table: "SurveyRequest",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Survey_Survey_SurveyID",
                table: "Survey",
                column: "SurveyID",
                principalTable: "Survey",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Survey_Survey_SurveyID",
                table: "Survey");

            migrationBuilder.DropTable(
                name: "Receives");

            migrationBuilder.DropTable(
                name: "SurveyAssignee");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "SurveyRequest");

            migrationBuilder.DropIndex(
                name: "IX_Survey_SurveyID",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "SurveyID",
                table: "Survey");
        }
    }
}
