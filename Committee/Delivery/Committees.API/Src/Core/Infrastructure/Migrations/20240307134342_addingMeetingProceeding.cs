using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingMeetingProceeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingProceeding");

            migrationBuilder.CreateTable(
                name: "MeetingProceedings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProceedingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingProceedings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingProceedings_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MeetingProceedings_Proceedings_ProceedingId",
                        column: x => x.ProceedingId,
                        principalTable: "Proceedings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingProceedings_MeetingId",
                table: "MeetingProceedings",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingProceedings_ProceedingId",
                table: "MeetingProceedings",
                column: "ProceedingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingProceedings");

            migrationBuilder.CreateTable(
                name: "MeetingProceeding",
                columns: table => new
                {
                    MeetingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProceedingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingProceeding", x => new { x.MeetingsId, x.ProceedingsId });
                    table.ForeignKey(
                        name: "FK_MeetingProceeding_Meetings_MeetingsId",
                        column: x => x.MeetingsId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingProceeding_Proceedings_ProceedingsId",
                        column: x => x.ProceedingsId,
                        principalTable: "Proceedings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingProceeding_ProceedingsId",
                table: "MeetingProceeding",
                column: "ProceedingsId");
        }
    }
}
