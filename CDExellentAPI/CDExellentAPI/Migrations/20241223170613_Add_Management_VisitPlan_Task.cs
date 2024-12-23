using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExellentAPI.Migrations
{
    public partial class Add_Management_VisitPlan_Task : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AreaId",
                table: "Distributor",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistributorID",
                table: "Distributor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlanStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypeDate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VisitPlan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeDateId = table.Column<int>(type: "int", nullable: false),
                    DistributorId = table.Column<int>(type: "int", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PlanUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitPlan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VisitPlan_Distributor_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitPlan_PlanStatus_PlanStatusId",
                        column: x => x.PlanStatusId,
                        principalTable: "PlanStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitPlan_TypeDate_TypeDateId",
                        column: x => x.TypeDateId,
                        principalTable: "TypeDate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitPlan_User_PlanUserId",
                        column: x => x.PlanUserId,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    VisitPlanId = table.Column<int>(type: "int", nullable: false),
                    GuestUserId = table.Column<int>(type: "int", nullable: false),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => new { x.VisitPlanId, x.GuestUserId });
                    table.ForeignKey(
                        name: "FK_Guest_User_GuestUserId",
                        column: x => x.GuestUserId,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guest_VisitPlan_VisitPlanId",
                        column: x => x.VisitPlanId,
                        principalTable: "VisitPlan",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AssigneeId = table.Column<int>(type: "int", nullable: false),
                    ReporterId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReporterFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AssigneeFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TaskStatusId = table.Column<int>(type: "int", nullable: false),
                    StarRate = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VisitPlanId = table.Column<int>(type: "int", nullable: false),
                    RepoterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Task_TaskStatus_TaskStatusId",
                        column: x => x.TaskStatusId,
                        principalTable: "TaskStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_User_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Task_User_PlanUserId",
                        column: x => x.PlanUserId,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Task_User_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Task_VisitPlan_VisitPlanId",
                        column: x => x.VisitPlanId,
                        principalTable: "VisitPlan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Distributor_DistributorID",
                table: "Distributor",
                column: "DistributorID");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_GuestUserId",
                table: "Guest",
                column: "GuestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_AssigneeId",
                table: "Task",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_PlanUserId",
                table: "Task",
                column: "PlanUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ReporterId",
                table: "Task",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskStatusId",
                table: "Task",
                column: "TaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_VisitPlanId",
                table: "Task",
                column: "VisitPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitPlan_DistributorId",
                table: "VisitPlan",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitPlan_PlanStatusId",
                table: "VisitPlan",
                column: "PlanStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitPlan_PlanUserId",
                table: "VisitPlan",
                column: "PlanUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitPlan_TypeDateId",
                table: "VisitPlan",
                column: "TypeDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Distributor_Distributor_DistributorID",
                table: "Distributor",
                column: "DistributorID",
                principalTable: "Distributor",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributor_Distributor_DistributorID",
                table: "Distributor");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropTable(
                name: "VisitPlan");

            migrationBuilder.DropTable(
                name: "PlanStatus");

            migrationBuilder.DropTable(
                name: "TypeDate");

            migrationBuilder.DropIndex(
                name: "IX_Distributor_DistributorID",
                table: "Distributor");

            migrationBuilder.DropColumn(
                name: "DistributorID",
                table: "Distributor");

            migrationBuilder.AlterColumn<string>(
                name: "AreaId",
                table: "Distributor",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
