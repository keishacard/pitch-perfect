using Microsoft.EntityFrameworkCore.Migrations;

namespace pitch_perfect.Migrations
{
    public partial class acceptedBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Accepted",
                table: "Pitch",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Accepted",
                table: "Pitch",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
