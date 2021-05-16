using Microsoft.EntityFrameworkCore.Migrations;

namespace DrReport.Migrations
{
    public partial class mm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patient",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patient",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1);
        }
    }
}
