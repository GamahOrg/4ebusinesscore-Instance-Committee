using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class meetingPermissionID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalMembers_Permissions_PermissionId",
                table: "ExternalMembers");

            migrationBuilder.AlterColumn<Guid>(
                name: "PermissionId",
                table: "ExternalMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalMembers_Permissions_PermissionId",
                table: "ExternalMembers",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalMembers_Permissions_PermissionId",
                table: "ExternalMembers");

            migrationBuilder.AlterColumn<Guid>(
                name: "PermissionId",
                table: "ExternalMembers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalMembers_Permissions_PermissionId",
                table: "ExternalMembers",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id");
        }
    }
}
