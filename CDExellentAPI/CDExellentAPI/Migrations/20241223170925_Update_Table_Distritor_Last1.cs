using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExellentAPI.Migrations
{
    public partial class Update_Table_Distritor_Last1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributor_Distributor_DistributorID",
                table: "Distributor");

            migrationBuilder.DropIndex(
                name: "IX_Distributor_DistributorID",
                table: "Distributor");

            migrationBuilder.DropColumn(
                name: "DistributorID",
                table: "Distributor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistributorID",
                table: "Distributor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Distributor_DistributorID",
                table: "Distributor",
                column: "DistributorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Distributor_Distributor_DistributorID",
                table: "Distributor",
                column: "DistributorID",
                principalTable: "Distributor",
                principalColumn: "ID");
        }
    }
}
