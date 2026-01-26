using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Committees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OutputNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OutputNumber",
                table: "Outputs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutputNumber",
                table: "Outputs");
        }
    }
}
