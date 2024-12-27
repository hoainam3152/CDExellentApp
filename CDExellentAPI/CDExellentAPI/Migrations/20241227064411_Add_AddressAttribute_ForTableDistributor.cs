using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExellentAPI.Migrations
{
    public partial class Add_AddressAttribute_ForTableDistributor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Distributor",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Distributor");
        }
    }
}
