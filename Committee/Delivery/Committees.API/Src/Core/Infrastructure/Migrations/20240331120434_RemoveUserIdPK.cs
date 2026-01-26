using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserIdPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeInternalMembers_InternalMembers_InternalMemberId",
                table: "CommitteeInternalMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalMemberMeetings_InternalMembers_InternalMemberId",
                table: "InternalMemberMeetings");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalMemberProceedings_InternalMembers_InternalMemberId",
                table: "InternalMemberProceedings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternalMembers",
                table: "InternalMembers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternalMembers",
                table: "InternalMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeInternalMembers_InternalMembers_InternalMemberId",
                table: "CommitteeInternalMembers",
                column: "InternalMemberId",
                principalTable: "InternalMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalMemberMeetings_InternalMembers_InternalMemberId",
                table: "InternalMemberMeetings",
                column: "InternalMemberId",
                principalTable: "InternalMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalMemberProceedings_InternalMembers_InternalMemberId",
                table: "InternalMemberProceedings",
                column: "InternalMemberId",
                principalTable: "InternalMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeInternalMembers_InternalMembers_InternalMemberId",
                table: "CommitteeInternalMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalMemberMeetings_InternalMembers_InternalMemberId",
                table: "InternalMemberMeetings");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalMemberProceedings_InternalMembers_InternalMemberId",
                table: "InternalMemberProceedings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternalMembers",
                table: "InternalMembers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternalMembers",
                table: "InternalMembers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeInternalMembers_InternalMembers_InternalMemberId",
                table: "CommitteeInternalMembers",
                column: "InternalMemberId",
                principalTable: "InternalMembers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalMemberMeetings_InternalMembers_InternalMemberId",
                table: "InternalMemberMeetings",
                column: "InternalMemberId",
                principalTable: "InternalMembers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalMemberProceedings_InternalMembers_InternalMemberId",
                table: "InternalMemberProceedings",
                column: "InternalMemberId",
                principalTable: "InternalMembers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
