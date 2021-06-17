using Microsoft.EntityFrameworkCore.Migrations;

namespace DrReport.Migrations
{
    public partial class migfssf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ClinicId",
                table: "Doctor",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Clinic_ClinicId",
                table: "Doctor",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Clinic_ClinicId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_ClinicId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Doctor");
        }
    }
}
