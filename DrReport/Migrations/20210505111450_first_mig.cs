using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrReport.Migrations
{
    public partial class first_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate Doctor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Specialize = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate Doctor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Telephone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Mail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AP_Opentime = table.Column<DateTime>(type: "date", nullable: false),
                    AP_Closetime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Disease",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Disease Symptoms",
                columns: table => new
                {
                    Disease_ID = table.Column<int>(type: "int", nullable: false),
                    Symptom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease Symptoms", x => new { x.Disease_ID, x.Symptom });
                    table.ForeignKey(
                        name: "FK_Disease Symptoms_Disease",
                        column: x => x.Disease_ID,
                        principalTable: "Disease",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Lname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes",
                        column: x => x.UserTypeID,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalLicense_ID = table.Column<int>(type: "int", nullable: true),
                    Clinic_ID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Doctor_Clinic",
                        column: x => x.Clinic_ID,
                        principalTable: "Clinic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patient_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis Result",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auto_Dresult = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Stat_Dresult = table.Column<double>(type: "float", nullable: true),
                    Doctor_Note = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Doctor_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis Result", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Diagnosis Result_Doctor",
                        column: x => x.Doctor_ID,
                        principalTable: "Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis Test",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Unit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GDtest_ID = table.Column<int>(type: "int", nullable: true),
                    Doctor_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis Test", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Diagnosis Test_Doctor",
                        column: x => x.Doctor_ID,
                        principalTable: "Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor_CRUD_Cdoctor",
                columns: table => new
                {
                    Doctor_ID = table.Column<int>(type: "int", nullable: false),
                    Cdoctor_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor_CRUD_Cdoctor", x => new { x.Doctor_ID, x.Cdoctor_ID });
                    table.ForeignKey(
                        name: "FK_Doctor_CRUD_Cdoctor_Candidate Doctor",
                        column: x => x.Cdoctor_ID,
                        principalTable: "Candidate Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_CRUD_Cdoctor_Doctor",
                        column: x => x.Doctor_ID,
                        principalTable: "Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "General Diagnosis Test",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Doctor_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General Diagnosis Test", x => x.ID);
                    table.ForeignKey(
                        name: "FK_General Diagnosis Test_Doctor",
                        column: x => x.Doctor_ID,
                        principalTable: "Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Cdoctor_ID = table.Column<int>(type: "int", nullable: false),
                    Dresult_ID = table.Column<int>(type: "int", nullable: false),
                    Doctor_ID = table.Column<int>(type: "int", nullable: true),
                    Patient_ID = table.Column<int>(type: "int", nullable: true),
                    Purpose = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => new { x.Cdoctor_ID, x.Dresult_ID });
                    table.ForeignKey(
                        name: "FK_Candidate_Candidate Doctor",
                        column: x => x.Cdoctor_ID,
                        principalTable: "Candidate Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidate_Diagnosis Result",
                        column: x => x.Dresult_ID,
                        principalTable: "Diagnosis Result",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidate_Doctor",
                        column: x => x.Doctor_ID,
                        principalTable: "Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidate_Patient",
                        column: x => x.Patient_ID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disease_Exist_Dresult",
                columns: table => new
                {
                    Disease_ID = table.Column<int>(type: "int", nullable: false),
                    Dresult_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease_Exist_Dresult", x => new { x.Disease_ID, x.Dresult_ID });
                    table.ForeignKey(
                        name: "FK_Disease_Exist_Dresult_Diagnosis Result",
                        column: x => x.Dresult_ID,
                        principalTable: "Diagnosis Result",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disease_Exist_Dresult_Disease",
                        column: x => x.Disease_ID,
                        principalTable: "Disease",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Give",
                columns: table => new
                {
                    Dresult_ID = table.Column<int>(type: "int", nullable: false),
                    Send_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Doctor_ID = table.Column<int>(type: "int", nullable: true),
                    Patient_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Give", x => new { x.Dresult_ID, x.Send_Date });
                    table.ForeignKey(
                        name: "FK_Give_Diagnosis Result",
                        column: x => x.Dresult_ID,
                        principalTable: "Diagnosis Result",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Give_Doctor",
                        column: x => x.Doctor_ID,
                        principalTable: "Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Give_Patient",
                        column: x => x.Patient_ID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                columns: table => new
                {
                    Clinic_ID = table.Column<int>(type: "int", nullable: false),
                    Reservation_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Request_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Patient_ID = table.Column<int>(type: "int", nullable: true),
                    Dtest_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => new { x.Clinic_ID, x.Reservation_Date, x.Request_Date });
                    table.ForeignKey(
                        name: "FK_Reserve_Clinic",
                        column: x => x.Clinic_ID,
                        principalTable: "Clinic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserve_Diagnosis Result",
                        column: x => x.Dtest_ID,
                        principalTable: "Diagnosis Result",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserve_Patient",
                        column: x => x.Patient_ID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis Test Range",
                columns: table => new
                {
                    Dtest_ID = table.Column<int>(type: "int", nullable: false),
                    Patient_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Start_Range = table.Column<double>(type: "float", nullable: true),
                    End_Range = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis Test Range", x => new { x.Dtest_ID, x.Patient_Type });
                    table.ForeignKey(
                        name: "FK_Diagnosis Test Range_Diagnosis Test",
                        column: x => x.Dtest_ID,
                        principalTable: "Diagnosis Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disease_relate_Dtest",
                columns: table => new
                {
                    Disease_ID = table.Column<int>(type: "int", nullable: false),
                    Dtest_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease_relate_Dtest", x => new { x.Disease_ID, x.Dtest_ID });
                    table.ForeignKey(
                        name: "FK_Disease_relate_Dtest_Diagnosis Test",
                        column: x => x.Dtest_ID,
                        principalTable: "Diagnosis Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disease_relate_Dtest_Disease",
                        column: x => x.Disease_ID,
                        principalTable: "Disease",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dtest_Dresult",
                columns: table => new
                {
                    Dresult_ID = table.Column<int>(type: "int", nullable: false),
                    Dtest_ID = table.Column<int>(type: "int", nullable: false),
                    Result_Value = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dtest_Dresult", x => new { x.Dresult_ID, x.Dtest_ID });
                    table.ForeignKey(
                        name: "FK_Dtest_Dresult_Diagnosis Result",
                        column: x => x.Dresult_ID,
                        principalTable: "Diagnosis Result",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dtest_Dresult_Diagnosis Test",
                        column: x => x.Dtest_ID,
                        principalTable: "Diagnosis Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disease_relate_GDtest",
                columns: table => new
                {
                    Disease_ID = table.Column<int>(type: "int", nullable: false),
                    GDtest_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease_relate_GDtest", x => new { x.Disease_ID, x.GDtest_ID });
                    table.ForeignKey(
                        name: "FK_Disease_relate_GDtest_Disease",
                        column: x => x.Disease_ID,
                        principalTable: "Disease",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disease_relate_GDtest_General Diagnosis Test",
                        column: x => x.GDtest_ID,
                        principalTable: "General Diagnosis Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GDtest_Dresult",
                columns: table => new
                {
                    Dresult_ID = table.Column<int>(type: "int", nullable: false),
                    GDtest_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GDtest_Dresult", x => new { x.Dresult_ID, x.GDtest_ID });
                    table.ForeignKey(
                        name: "FK_GDtest_Dresult_Diagnosis Result",
                        column: x => x.Dresult_ID,
                        principalTable: "Diagnosis Result",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GDtest_Dresult_General Diagnosis Test",
                        column: x => x.GDtest_ID,
                        principalTable: "General Diagnosis Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GReserve",
                columns: table => new
                {
                    Clinic_ID = table.Column<int>(type: "int", nullable: false),
                    Reservation_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Request_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Patient_ID = table.Column<int>(type: "int", nullable: true),
                    GDtest_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GReserve", x => new { x.Clinic_ID, x.Reservation_Date, x.Request_Date });
                    table.ForeignKey(
                        name: "FK_GReserve_Clinic",
                        column: x => x.Clinic_ID,
                        principalTable: "Clinic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GReserve_General Diagnosis Test",
                        column: x => x.GDtest_ID,
                        principalTable: "General Diagnosis Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GReserve_Patient",
                        column: x => x.Patient_ID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_Doctor_ID",
                table: "Candidate",
                column: "Doctor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_Dresult_ID",
                table: "Candidate",
                column: "Dresult_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_Patient_ID",
                table: "Candidate",
                column: "Patient_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis Result_Doctor_ID",
                table: "Diagnosis Result",
                column: "Doctor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis Test_Doctor_ID",
                table: "Diagnosis Test",
                column: "Doctor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Disease_Exist_Dresult_Dresult_ID",
                table: "Disease_Exist_Dresult",
                column: "Dresult_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Disease_relate_Dtest_Dtest_ID",
                table: "Disease_relate_Dtest",
                column: "Dtest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Disease_relate_GDtest_GDtest_ID",
                table: "Disease_relate_GDtest",
                column: "GDtest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Clinic_ID",
                table: "Doctor",
                column: "Clinic_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_UserID",
                table: "Doctor",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_CRUD_Cdoctor_Cdoctor_ID",
                table: "Doctor_CRUD_Cdoctor",
                column: "Cdoctor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Dtest_Dresult_Dtest_ID",
                table: "Dtest_Dresult",
                column: "Dtest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GDtest_Dresult_GDtest_ID",
                table: "GDtest_Dresult",
                column: "GDtest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_General Diagnosis Test_Doctor_ID",
                table: "General Diagnosis Test",
                column: "Doctor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Give_Doctor_ID",
                table: "Give",
                column: "Doctor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Give_Patient_ID",
                table: "Give",
                column: "Patient_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GReserve_GDtest_ID",
                table: "GReserve",
                column: "GDtest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GReserve_Patient_ID",
                table: "GReserve",
                column: "Patient_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UserID",
                table: "Patient",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_Dtest_ID",
                table: "Reserve",
                column: "Dtest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_Patient_ID",
                table: "Reserve",
                column: "Patient_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Diagnosis Test Range");

            migrationBuilder.DropTable(
                name: "Disease Symptoms");

            migrationBuilder.DropTable(
                name: "Disease_Exist_Dresult");

            migrationBuilder.DropTable(
                name: "Disease_relate_Dtest");

            migrationBuilder.DropTable(
                name: "Disease_relate_GDtest");

            migrationBuilder.DropTable(
                name: "Doctor_CRUD_Cdoctor");

            migrationBuilder.DropTable(
                name: "Dtest_Dresult");

            migrationBuilder.DropTable(
                name: "GDtest_Dresult");

            migrationBuilder.DropTable(
                name: "Give");

            migrationBuilder.DropTable(
                name: "GReserve");

            migrationBuilder.DropTable(
                name: "Reserve");

            migrationBuilder.DropTable(
                name: "Disease");

            migrationBuilder.DropTable(
                name: "Candidate Doctor");

            migrationBuilder.DropTable(
                name: "Diagnosis Test");

            migrationBuilder.DropTable(
                name: "General Diagnosis Test");

            migrationBuilder.DropTable(
                name: "Diagnosis Result");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
