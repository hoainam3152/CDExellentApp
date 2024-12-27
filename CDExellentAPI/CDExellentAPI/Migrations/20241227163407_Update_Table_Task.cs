using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExellentAPI.Migrations
{
    public partial class Update_Table_Task : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepoterId",
                table: "Task");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepoterId",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
