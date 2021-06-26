using Microsoft.EntityFrameworkCore.Migrations;

namespace DrReport.Migrations
{
    public partial class reserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserve_Diagnosis Result",
                table: "Reserve");

            migrationBuilder.DropIndex(
                name: "IX_Reserve_Dtest_ID",
                table: "Reserve");

            migrationBuilder.AddColumn<int>(
                name: "Doctor_ID",
                table: "Reserve",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_Doctor_ID",
                table: "Reserve",
                column: "Doctor_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserve_Doctor",
                table: "Reserve",
                column: "Doctor_ID",
                principalTable: "Doctor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserve_Doctor",
                table: "Reserve");

            migrationBuilder.DropIndex(
                name: "IX_Reserve_Doctor_ID",
                table: "Reserve");

            migrationBuilder.DropColumn(
                name: "Doctor_ID",
                table: "Reserve");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_Dtest_ID",
                table: "Reserve",
                column: "Dtest_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserve_Diagnosis Result",
                table: "Reserve",
                column: "Dtest_ID",
                principalTable: "Diagnosis Result",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
