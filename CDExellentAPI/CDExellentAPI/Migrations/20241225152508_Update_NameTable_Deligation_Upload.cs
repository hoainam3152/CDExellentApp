using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDExellentAPI.Migrations
{
    public partial class Update_NameTable_Deligation_Upload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Media_Media_MediaId",
                table: "User_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Media_User_UserId",
                table: "User_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Permission_Permission_PermissionId",
                table: "User_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Permission_User_UserId",
                table: "User_Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Permission",
                table: "User_Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Media",
                table: "User_Media");

            migrationBuilder.RenameTable(
                name: "User_Permission",
                newName: "Deligation");

            migrationBuilder.RenameTable(
                name: "User_Media",
                newName: "Upload");

            migrationBuilder.RenameIndex(
                name: "IX_User_Permission_PermissionId",
                table: "Deligation",
                newName: "IX_Deligation_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Media_MediaId",
                table: "Upload",
                newName: "IX_Upload_MediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deligation",
                table: "Deligation",
                columns: new[] { "UserId", "PermissionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Upload",
                table: "Upload",
                columns: new[] { "UserId", "MediaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Deligation_Permission_PermissionId",
                table: "Deligation",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deligation_User_UserId",
                table: "Deligation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Upload_Media_MediaId",
                table: "Upload",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Upload_User_UserId",
                table: "Upload",
                column: "UserId",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deligation_Permission_PermissionId",
                table: "Deligation");

            migrationBuilder.DropForeignKey(
                name: "FK_Deligation_User_UserId",
                table: "Deligation");

            migrationBuilder.DropForeignKey(
                name: "FK_Upload_Media_MediaId",
                table: "Upload");

            migrationBuilder.DropForeignKey(
                name: "FK_Upload_User_UserId",
                table: "Upload");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Upload",
                table: "Upload");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deligation",
                table: "Deligation");

            migrationBuilder.RenameTable(
                name: "Upload",
                newName: "User_Media");

            migrationBuilder.RenameTable(
                name: "Deligation",
                newName: "User_Permission");

            migrationBuilder.RenameIndex(
                name: "IX_Upload_MediaId",
                table: "User_Media",
                newName: "IX_User_Media_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Deligation_PermissionId",
                table: "User_Permission",
                newName: "IX_User_Permission_PermissionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Media",
                table: "User_Media",
                columns: new[] { "UserId", "MediaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Permission",
                table: "User_Permission",
                columns: new[] { "UserId", "PermissionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Media_Media_MediaId",
                table: "User_Media",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Media_User_UserId",
                table: "User_Media",
                column: "UserId",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Permission_Permission_PermissionId",
                table: "User_Permission",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Permission_User_UserId",
                table: "User_Permission",
                column: "UserId",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
