using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addWorkflowIdProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupNotes",
                table: "Committees",
                newName: "Notes");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkflowId",
                table: "Committees",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkflowId",
                table: "Committees");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Committees",
                newName: "GroupNotes");
        }
    }
}
