using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addProceedingAcceptanceProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProceedingAcceptance",
                table: "InternalMemberProceedings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProceedingAcceptance",
                table: "ExternalMemberProceeding",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProceedingAcceptance",
                table: "InternalMemberProceedings");

            migrationBuilder.DropColumn(
                name: "ProceedingAcceptance",
                table: "ExternalMemberProceeding");
        }
    }
}
