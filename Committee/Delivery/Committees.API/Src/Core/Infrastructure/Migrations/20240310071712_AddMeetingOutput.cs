using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMeetingOutput : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingOutput");

            migrationBuilder.CreateTable(
                name: "MeetingOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutputId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingOutputs_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MeetingOutputs_Outputs_OutputId",
                        column: x => x.OutputId,
                        principalTable: "Outputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingOutputs_MeetingId",
                table: "MeetingOutputs",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingOutputs_OutputId",
                table: "MeetingOutputs",
                column: "OutputId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingOutputs");

            migrationBuilder.CreateTable(
                name: "MeetingOutput",
                columns: table => new
                {
                    MeetingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutputsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingOutput", x => new { x.MeetingsId, x.OutputsId });
                    table.ForeignKey(
                        name: "FK_MeetingOutput_Meetings_MeetingsId",
                        column: x => x.MeetingsId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingOutput_Outputs_OutputsId",
                        column: x => x.OutputsId,
                        principalTable: "Outputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingOutput_OutputsId",
                table: "MeetingOutput",
                column: "OutputsId");
        }
    }
}
