using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAcceptanceMessageProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcceptanceMessage",
                table: "InternalMemberProceedings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcceptanceMessage",
                table: "ExternalMemberProceeding",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptanceMessage",
                table: "InternalMemberProceedings");

            migrationBuilder.DropColumn(
                name: "AcceptanceMessage",
                table: "ExternalMemberProceeding");
        }
    }
}
