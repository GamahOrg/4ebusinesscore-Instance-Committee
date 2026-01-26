using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addExternalMemberMeetings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalMemberMeeting");

            migrationBuilder.AddColumn<Guid>(
                name: "ExternalMemberId",
                table: "Meetings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExternalMemberMeetings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalMemberMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalMemberMeetings_ExternalMembers_ExternalMemberId",
                        column: x => x.ExternalMemberId,
                        principalTable: "ExternalMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalMemberMeetings_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ExternalMemberId",
                table: "Meetings",
                column: "ExternalMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalMemberMeetings_ExternalMemberId",
                table: "ExternalMemberMeetings",
                column: "ExternalMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalMemberMeetings_MeetingId",
                table: "ExternalMemberMeetings",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_ExternalMembers_ExternalMemberId",
                table: "Meetings",
                column: "ExternalMemberId",
                principalTable: "ExternalMembers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_ExternalMembers_ExternalMemberId",
                table: "Meetings");

            migrationBuilder.DropTable(
                name: "ExternalMemberMeetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_ExternalMemberId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "ExternalMemberId",
                table: "Meetings");

            migrationBuilder.CreateTable(
                name: "ExternalMemberMeeting",
                columns: table => new
                {
                    ExternalMembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalMemberMeeting", x => new { x.ExternalMembersId, x.MeetingsId });
                    table.ForeignKey(
                        name: "FK_ExternalMemberMeeting_ExternalMembers_ExternalMembersId",
                        column: x => x.ExternalMembersId,
                        principalTable: "ExternalMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalMemberMeeting_Meetings_MeetingsId",
                        column: x => x.MeetingsId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalMemberMeeting_MeetingsId",
                table: "ExternalMemberMeeting",
                column: "MeetingsId");
        }
    }
}
