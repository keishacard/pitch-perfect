using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pitch_perfect.Migrations
{
    public partial class fixnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAccepted",
                table: "Pitch",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "Accepted",
                table: "Pitch",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAccepted",
                table: "Pitch",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Accepted",
                table: "Pitch",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
