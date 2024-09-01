using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LunchStack.Api.Migrations
{
    /// <inheritdoc />
    public partial class Workgroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkgroup_Users_UserId",
                table: "UserWorkgroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkgroup_Workgroup_WorkgroupId",
                table: "UserWorkgroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Workgroup_Users_UserId",
                table: "Workgroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workgroup",
                table: "Workgroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWorkgroup",
                table: "UserWorkgroup");

            migrationBuilder.RenameTable(
                name: "Workgroup",
                newName: "Workgroups");

            migrationBuilder.RenameTable(
                name: "UserWorkgroup",
                newName: "UserWorkgroups");

            migrationBuilder.RenameIndex(
                name: "IX_Workgroup_UserId",
                table: "Workgroups",
                newName: "IX_Workgroups_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWorkgroup_WorkgroupId",
                table: "UserWorkgroups",
                newName: "IX_UserWorkgroups_WorkgroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWorkgroup_UserId",
                table: "UserWorkgroups",
                newName: "IX_UserWorkgroups_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workgroups",
                table: "Workgroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWorkgroups",
                table: "UserWorkgroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkgroups_Users_UserId",
                table: "UserWorkgroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkgroups_Workgroups_WorkgroupId",
                table: "UserWorkgroups",
                column: "WorkgroupId",
                principalTable: "Workgroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workgroups_Users_UserId",
                table: "Workgroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkgroups_Users_UserId",
                table: "UserWorkgroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkgroups_Workgroups_WorkgroupId",
                table: "UserWorkgroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Workgroups_Users_UserId",
                table: "Workgroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workgroups",
                table: "Workgroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWorkgroups",
                table: "UserWorkgroups");

            migrationBuilder.RenameTable(
                name: "Workgroups",
                newName: "Workgroup");

            migrationBuilder.RenameTable(
                name: "UserWorkgroups",
                newName: "UserWorkgroup");

            migrationBuilder.RenameIndex(
                name: "IX_Workgroups_UserId",
                table: "Workgroup",
                newName: "IX_Workgroup_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWorkgroups_WorkgroupId",
                table: "UserWorkgroup",
                newName: "IX_UserWorkgroup_WorkgroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWorkgroups_UserId",
                table: "UserWorkgroup",
                newName: "IX_UserWorkgroup_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workgroup",
                table: "Workgroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWorkgroup",
                table: "UserWorkgroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkgroup_Users_UserId",
                table: "UserWorkgroup",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkgroup_Workgroup_WorkgroupId",
                table: "UserWorkgroup",
                column: "WorkgroupId",
                principalTable: "Workgroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workgroup_Users_UserId",
                table: "Workgroup",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
