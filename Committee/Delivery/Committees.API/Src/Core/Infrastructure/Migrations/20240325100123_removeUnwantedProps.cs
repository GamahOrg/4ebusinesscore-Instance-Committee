using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeUnwantedProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Committees");

            migrationBuilder.AddColumn<DateTime>(
                name: "CommitteeDate",
                table: "Committees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommitteeDate",
                table: "Committees");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Committees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Committees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
