using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExellentAPI.Migrations
{
    public partial class Update_Table_Survey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Survey_Survey_SurveyID",
                table: "Survey");

            migrationBuilder.DropIndex(
                name: "IX_Survey_SurveyID",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "SurveyID",
                table: "Survey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SurveyID",
                table: "Survey",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Survey_SurveyID",
                table: "Survey",
                column: "SurveyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Survey_Survey_SurveyID",
                table: "Survey",
                column: "SurveyID",
                principalTable: "Survey",
                principalColumn: "ID");
        }
    }
}
