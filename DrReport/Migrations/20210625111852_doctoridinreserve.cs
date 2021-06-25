using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrReport.Migrations
{
    public partial class doctoridinreserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disease Symptoms_Disease",
                table: "Disease Symptoms");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Clinic_ClinicId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_ClinicId",
                table: "Doctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disease Symptoms",
                table: "Disease Symptoms");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Diagnosis Test");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patient",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: false,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Disease_ID",
                table: "Disease Symptoms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Disease Symptoms",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Precaution",
                table: "Disease",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Clinic",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AP_Opentime",
                table: "Clinic",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AP_Closetime",
                table: "Clinic",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "Doctor_ID",
                table: "Clinic",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disease Symptoms",
                table: "Disease Symptoms",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Disease Symptoms_Disease_ID",
                table: "Disease Symptoms",
                column: "Disease_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_Doctor_ID",
                table: "Clinic",
                column: "Doctor_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_Doctor",
                table: "Clinic",
                column: "Doctor_ID",
                principalTable: "Doctor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disease Symptoms_Disease1",
                table: "Disease Symptoms",
                column: "Disease_ID",
                principalTable: "Disease",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_Doctor",
                table: "Clinic");

            migrationBuilder.DropForeignKey(
                name: "FK_Disease Symptoms_Disease1",
                table: "Disease Symptoms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disease Symptoms",
                table: "Disease Symptoms");

            migrationBuilder.DropIndex(
                name: "IX_Disease Symptoms_Disease_ID",
                table: "Disease Symptoms");

            migrationBuilder.DropIndex(
                name: "IX_Clinic_Doctor_ID",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Disease Symptoms");

            migrationBuilder.DropColumn(
                name: "Precaution",
                table: "Disease");

            migrationBuilder.DropColumn(
                name: "Doctor_ID",
                table: "Clinic");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patient",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1,
                oldDefaultValueSql: "('')");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Disease_ID",
                table: "Disease Symptoms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Diagnosis Test",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Clinic",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AP_Opentime",
                table: "Clinic",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AP_Closetime",
                table: "Clinic",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disease Symptoms",
                table: "Disease Symptoms",
                columns: new[] { "Disease_ID", "Symptom" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ClinicId",
                table: "Doctor",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disease Symptoms_Disease",
                table: "Disease Symptoms",
                column: "Disease_ID",
                principalTable: "Disease",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Clinic_ClinicId",
                table: "Doctor",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
