using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.web.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subscribed",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Club",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Club",
                table: "Students");

            migrationBuilder.AddColumn<bool>(
                name: "Subscribed",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
