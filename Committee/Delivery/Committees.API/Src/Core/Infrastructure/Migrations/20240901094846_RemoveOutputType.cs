using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOutputType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outputs_OutputTypes_OutputTypeId",
                table: "Outputs");

            migrationBuilder.DropIndex(
                name: "IX_Outputs_OutputTypeId",
                table: "Outputs");

            migrationBuilder.DropColumn(
                name: "OutputTypeId",
                table: "Outputs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OutputTypeId",
                table: "Outputs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Outputs_OutputTypeId",
                table: "Outputs",
                column: "OutputTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Outputs_OutputTypes_OutputTypeId",
                table: "Outputs",
                column: "OutputTypeId",
                principalTable: "OutputTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
