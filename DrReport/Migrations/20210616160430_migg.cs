using Microsoft.EntityFrameworkCore.Migrations;

namespace DrReport.Migrations
{
    public partial class migg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_Doctor_DoctorId",
                table: "Clinic");

            migrationBuilder.DropIndex(
                name: "IX_Clinic_DoctorId",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Clinic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Clinic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_DoctorId",
                table: "Clinic",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_Doctor_DoctorId",
                table: "Clinic",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
