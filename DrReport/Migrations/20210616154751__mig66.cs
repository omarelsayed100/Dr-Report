using Microsoft.EntityFrameworkCore.Migrations;

namespace DrReport.Migrations
{
    public partial class _mig66 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Clinic",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_Clinic_ID",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Clinic_ID",
                table: "Doctor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clinic_ID",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Clinic_ID",
                table: "Doctor",
                column: "Clinic_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Clinic",
                table: "Doctor",
                column: "Clinic_ID",
                principalTable: "Clinic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
