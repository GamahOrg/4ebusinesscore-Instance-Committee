using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExternalMembersMeetings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_ExternalMembers_ExternalMemberId",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_ExternalMemberId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "ExternalMemberId",
                table: "Meetings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExternalMemberId",
                table: "Meetings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ExternalMemberId",
                table: "Meetings",
                column: "ExternalMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_ExternalMembers_ExternalMemberId",
                table: "Meetings",
                column: "ExternalMemberId",
                principalTable: "ExternalMembers",
                principalColumn: "Id");
        }
    }
}
