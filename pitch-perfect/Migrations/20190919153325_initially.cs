using Microsoft.EntityFrameworkCore.Migrations;

namespace pitch_perfect.Migrations
{
    public partial class initially : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmittedTo",
                table: "Pitch");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubmittedTo",
                table: "Pitch",
                maxLength: 55,
                nullable: false,
                defaultValue: "");
        }
    }
}
