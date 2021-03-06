// <auto-generated />
using System;
using DrReport.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DrReport.Migrations
{
    [DbContext(typeof(MedicalDBContext))]
    partial class MedicalDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DrReport.Models.Candidate", b =>
                {
                    b.Property<int>("CdoctorId")
                        .HasColumnType("int")
                        .HasColumnName("Cdoctor_ID");

                    b.Property<int>("DresultId")
                        .HasColumnType("int")
                        .HasColumnName("Dresult_ID");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("Doctor_ID");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("Patient_ID");

                    b.Property<string>("Purpose")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CdoctorId", "DresultId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("DresultId");

                    b.HasIndex("PatientId");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("DrReport.Models.CandidateDoctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Pn")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PN");

                    b.Property<string>("Specialize")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Candidate Doctor");
                });

            modelBuilder.Entity("DrReport.Models.Clinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ApClosetime")
                        .HasColumnType("date")
                        .HasColumnName("AP_Closetime");

                    b.Property<DateTime?>("ApOpentime")
                        .HasColumnType("date")
                        .HasColumnName("AP_Opentime");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("Doctor_ID");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Mail")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telephone")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Clinic");
                });

            modelBuilder.Entity("DrReport.Models.DiagnosisResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AutoDresult")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Auto_Dresult");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("Doctor_ID");

                    b.Property<string>("DoctorNote")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Doctor_Note");

                    b.Property<double?>("StatDresult")
                        .HasColumnType("float")
                        .HasColumnName("Stat_Dresult");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Diagnosis Result");
                });

            modelBuilder.Entity("DrReport.Models.DiagnosisTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("Doctor_ID");

                    b.Property<int?>("GdtestId")
                        .HasColumnType("int")
                        .HasColumnName("GDtest_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Unit")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Diagnosis Test");
                });

            modelBuilder.Entity("DrReport.Models.DiagnosisTestRange", b =>
                {
                    b.Property<int>("DtestId")
                        .HasColumnType("int")
                        .HasColumnName("Dtest_ID");

                    b.Property<string>("PatientType")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Patient_Type");

                    b.Property<double?>("EndRange")
                        .HasColumnType("float")
                        .HasColumnName("End_Range");

                    b.Property<double?>("StartRange")
                        .HasColumnType("float")
                        .HasColumnName("Start_Range");

                    b.HasKey("DtestId", "PatientType");

                    b.ToTable("Diagnosis Test Range");
                });

            modelBuilder.Entity("DrReport.Models.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Precaution")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Disease");
                });

            modelBuilder.Entity("DrReport.Models.DiseaseExistDresult", b =>
                {
                    b.Property<int>("DiseaseId")
                        .HasColumnType("int")
                        .HasColumnName("Disease_ID");

                    b.Property<int>("DresultId")
                        .HasColumnType("int")
                        .HasColumnName("Dresult_ID");

                    b.HasKey("DiseaseId", "DresultId");

                    b.HasIndex("DresultId");

                    b.ToTable("Disease_Exist_Dresult");
                });

            modelBuilder.Entity("DrReport.Models.DiseaseRelateDtest", b =>
                {
                    b.Property<int>("DiseaseId")
                        .HasColumnType("int")
                        .HasColumnName("Disease_ID");

                    b.Property<int>("DtestId")
                        .HasColumnType("int")
                        .HasColumnName("Dtest_ID");

                    b.HasKey("DiseaseId", "DtestId");

                    b.HasIndex("DtestId");

                    b.ToTable("Disease_relate_Dtest");
                });

            modelBuilder.Entity("DrReport.Models.DiseaseRelateGdtest", b =>
                {
                    b.Property<int>("DiseaseId")
                        .HasColumnType("int")
                        .HasColumnName("Disease_ID");

                    b.Property<int>("GdtestId")
                        .HasColumnType("int")
                        .HasColumnName("GDtest_ID");

                    b.HasKey("DiseaseId", "GdtestId");

                    b.HasIndex("GdtestId");

                    b.ToTable("Disease_relate_GDtest");
                });

            modelBuilder.Entity("DrReport.Models.DiseaseSymptom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DiseaseId")
                        .HasColumnType("int")
                        .HasColumnName("Disease_ID");

                    b.Property<string>("Symptom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.ToTable("Disease Symptoms");
                });

            modelBuilder.Entity("DrReport.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MedicalLicenseId")
                        .HasColumnType("int")
                        .HasColumnName("MedicalLicense_ID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("DrReport.Models.DoctorCrudCdoctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("Doctor_ID");

                    b.Property<int>("CdoctorId")
                        .HasColumnType("int")
                        .HasColumnName("Cdoctor_ID");

                    b.HasKey("DoctorId", "CdoctorId");

                    b.HasIndex("CdoctorId");

                    b.ToTable("Doctor_CRUD_Cdoctor");
                });

            modelBuilder.Entity("DrReport.Models.DtestDresult", b =>
                {
                    b.Property<int>("DresultId")
                        .HasColumnType("int")
                        .HasColumnName("Dresult_ID");

                    b.Property<int>("DtestId")
                        .HasColumnType("int")
                        .HasColumnName("Dtest_ID");

                    b.Property<double?>("ResultValue")
                        .HasColumnType("float")
                        .HasColumnName("Result_Value");

                    b.HasKey("DresultId", "DtestId");

                    b.HasIndex("DtestId");

                    b.ToTable("Dtest_Dresult");
                });

            modelBuilder.Entity("DrReport.Models.GdtestDresult", b =>
                {
                    b.Property<int>("DresultId")
                        .HasColumnType("int")
                        .HasColumnName("Dresult_ID");

                    b.Property<int>("GdtestId")
                        .HasColumnType("int")
                        .HasColumnName("GDtest_ID");

                    b.HasKey("DresultId", "GdtestId");

                    b.HasIndex("GdtestId");

                    b.ToTable("GDtest_Dresult");
                });

            modelBuilder.Entity("DrReport.Models.GeneralDiagnosisTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("Doctor_ID");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("General Diagnosis Test");
                });

            modelBuilder.Entity("DrReport.Models.Give", b =>
                {
                    b.Property<int>("DresultId")
                        .HasColumnType("int")
                        .HasColumnName("Dresult_ID");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("date")
                        .HasColumnName("Send_Date");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("Doctor_ID");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("Patient_ID");

                    b.HasKey("DresultId", "SendDate");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Give");
                });

            modelBuilder.Entity("DrReport.Models.Greserve", b =>
                {
                    b.Property<int>("ClinicId")
                        .HasColumnType("int")
                        .HasColumnName("Clinic_ID");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("date")
                        .HasColumnName("Reservation_Date");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("date")
                        .HasColumnName("Request_Date");

                    b.Property<int?>("GdtestId")
                        .HasColumnType("int")
                        .HasColumnName("GDtest_ID");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("Patient_ID");

                    b.HasKey("ClinicId", "ReservationDate", "RequestDate");

                    b.HasIndex("GdtestId");

                    b.HasIndex("PatientId");

                    b.ToTable("GReserve");
                });

            modelBuilder.Entity("DrReport.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasDefaultValueSql("('')");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("DrReport.Models.Reserve", b =>
                {
                    b.Property<int>("ClinicId")
                        .HasColumnType("int")
                        .HasColumnName("Clinic_ID");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("date")
                        .HasColumnName("Reservation_Date");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("date")
                        .HasColumnName("Request_Date");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("Doctor_ID");

                    b.Property<int?>("DtestId")
                        .HasColumnType("int")
                        .HasColumnName("Dtest_ID");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("Patient_ID");

                    b.HasKey("ClinicId", "ReservationDate", "RequestDate");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Reserve");
                });

            modelBuilder.Entity("DrReport.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Pn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PN");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("UserTypeID");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DrReport.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("UserTypeID");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("DrReport.Models.Candidate", b =>
                {
                    b.HasOne("DrReport.Models.CandidateDoctor", "Cdoctor")
                        .WithMany("Candidates")
                        .HasForeignKey("CdoctorId")
                        .HasConstraintName("FK_Candidate_Candidate Doctor")
                        .IsRequired();

                    b.HasOne("DrReport.Models.Doctor", "Doctor")
                        .WithMany("Candidates")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_Candidate_Doctor");

                    b.HasOne("DrReport.Models.DiagnosisResult", "Dresult")
                        .WithMany("Candidates")
                        .HasForeignKey("DresultId")
                        .HasConstraintName("FK_Candidate_Diagnosis Result")
                        .IsRequired();

                    b.HasOne("DrReport.Models.Patient", "Patient")
                        .WithMany("Candidates")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK_Candidate_Patient");

                    b.Navigation("Cdoctor");

                    b.Navigation("Doctor");

                    b.Navigation("Dresult");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DrReport.Models.Clinic", b =>
                {
                    b.HasOne("DrReport.Models.Doctor", "Doctor")
                        .WithMany("Clinics")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_Clinic_Doctor");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DrReport.Models.DiagnosisResult", b =>
                {
                    b.HasOne("DrReport.Models.Doctor", "Doctor")
                        .WithMany("DiagnosisResults")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_Diagnosis Result_Doctor");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DrReport.Models.DiagnosisTest", b =>
                {
                    b.HasOne("DrReport.Models.Doctor", "Doctor")
                        .WithMany("DiagnosisTests")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_Diagnosis Test_Doctor");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DrReport.Models.DiagnosisTestRange", b =>
                {
                    b.HasOne("DrReport.Models.DiagnosisTest", "Dtest")
                        .WithMany("DiagnosisTestRanges")
                        .HasForeignKey("DtestId")
                        .HasConstraintName("FK_Diagnosis Test Range_Diagnosis Test")
                        .IsRequired();

                    b.Navigation("Dtest");
                });

            modelBuilder.Entity("DrReport.Models.DiseaseExistDresult", b =>
                {
                    b.HasOne("DrReport.Models.Disease", "Disease")
                        .WithMany("DiseaseExistDresults")
                        .HasForeignKey("DiseaseId")
                        .HasConstraintName("FK_Disease_Exist_Dresult_Disease")
                        .IsRequired();

                    b.HasOne("DrReport.Models.DiagnosisResult", "Dresult")
                        .WithMany("DiseaseExistDresults")
                        .HasForeignKey("DresultId")
                        .HasConstraintName("FK_Disease_Exist_Dresult_Diagnosis Result")
                        .IsRequired();

                    b.Navigation("Disease");

                    b.Navigation("Dresult");
                });

            modelBuilder.Entity("DrReport.Models.DiseaseRelateDtest", b =>
                {
                    b.HasOne("DrReport.Models.Disease", "Disease")
                        .WithMany("DiseaseRelateDtests")
                        .HasForeignKey("DiseaseId")
                        .HasConstraintName("FK_Disease_relate_Dtest_Disease")
                        .IsRequired();

                    b.HasOne("DrReport.Models.DiagnosisTest", "Dtest")
                        .WithMany("DiseaseRelateDtests")
                        .HasForeignKey("DtestId")
                        .HasConstraintName("FK_Disease_relate_Dtest_Diagnosis Test")
                        .IsRequired();

                    b.Navigation("Disease");

                    b.Navigation("Dtest");
                });

            modelBuilder.Entity("DrReport.Models.DiseaseRelateGdtest", b =>
                {
                    b.HasOne("DrReport.Models.Disease", "Disease")
                        .WithMany("DiseaseRelateGdtests")
                        .HasForeignKey("DiseaseId")
                        .HasConstraintName("FK_Disease_relate_GDtest_Disease")
                        .IsRequired();

                    b.HasOne("DrReport.Models.GeneralDiagnosisTest", "Gdtest")
                        .WithMany("DiseaseRelateGdtests")
                        .HasForeignKey("GdtestId")
                        .HasConstraintName("FK_Disease_relate_GDtest_General Diagnosis Test")
                        .IsRequired();

                    b.Navigation("Disease");

                    b.Navigation("Gdtest");
                });

            modelBuilder.Entity("DrReport.Models.DiseaseSymptom", b =>
                {
                    b.HasOne("DrReport.Models.Disease", "Disease")
                        .WithMany("DiseaseSymptoms")
                        .HasForeignKey("DiseaseId")
                        .HasConstraintName("FK_Disease Symptoms_Disease1");

                    b.Navigation("Disease");
                });

            modelBuilder.Entity("DrReport.Models.Doctor", b =>
                {
                    b.HasOne("DrReport.Models.User", "User")
                        .WithMany("Doctors")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Doctor_Users")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DrReport.Models.DoctorCrudCdoctor", b =>
                {
                    b.HasOne("DrReport.Models.CandidateDoctor", "Cdoctor")
                        .WithMany("DoctorCrudCdoctors")
                        .HasForeignKey("CdoctorId")
                        .HasConstraintName("FK_Doctor_CRUD_Cdoctor_Candidate Doctor")
                        .IsRequired();

                    b.HasOne("DrReport.Models.Doctor", "Doctor")
                        .WithMany("DoctorCrudCdoctors")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_Doctor_CRUD_Cdoctor_Doctor")
                        .IsRequired();

                    b.Navigation("Cdoctor");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DrReport.Models.DtestDresult", b =>
                {
                    b.HasOne("DrReport.Models.DiagnosisResult", "Dresult")
                        .WithMany("DtestDresults")
                        .HasForeignKey("DresultId")
                        .HasConstraintName("FK_Dtest_Dresult_Diagnosis Result")
                        .IsRequired();

                    b.HasOne("DrReport.Models.DiagnosisTest", "Dtest")
                        .WithMany("DtestDresults")
                        .HasForeignKey("DtestId")
                        .HasConstraintName("FK_Dtest_Dresult_Diagnosis Test")
                        .IsRequired();

                    b.Navigation("Dresult");

                    b.Navigation("Dtest");
                });

            modelBuilder.Entity("DrReport.Models.GdtestDresult", b =>
                {
                    b.HasOne("DrReport.Models.DiagnosisResult", "Dresult")
                        .WithMany("GdtestDresults")
                        .HasForeignKey("DresultId")
                        .HasConstraintName("FK_GDtest_Dresult_Diagnosis Result")
                        .IsRequired();

                    b.HasOne("DrReport.Models.GeneralDiagnosisTest", "Gdtest")
                        .WithMany("GdtestDresults")
                        .HasForeignKey("GdtestId")
                        .HasConstraintName("FK_GDtest_Dresult_General Diagnosis Test")
                        .IsRequired();

                    b.Navigation("Dresult");

                    b.Navigation("Gdtest");
                });

            modelBuilder.Entity("DrReport.Models.GeneralDiagnosisTest", b =>
                {
                    b.HasOne("DrReport.Models.Doctor", "Doctor")
                        .WithMany("GeneralDiagnosisTests")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_General Diagnosis Test_Doctor");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DrReport.Models.Give", b =>
                {
                    b.HasOne("DrReport.Models.Doctor", "Doctor")
                        .WithMany("Gives")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_Give_Doctor");

                    b.HasOne("DrReport.Models.DiagnosisResult", "Dresult")
                        .WithMany("Gives")
                        .HasForeignKey("DresultId")
                        .HasConstraintName("FK_Give_Diagnosis Result")
                        .IsRequired();

                    b.HasOne("DrReport.Models.Patient", "Patient")
                        .WithMany("Gives")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK_Give_Patient");

                    b.Navigation("Doctor");

                    b.Navigation("Dresult");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DrReport.Models.Greserve", b =>
                {
                    b.HasOne("DrReport.Models.Clinic", "Clinic")
                        .WithMany("Greserves")
                        .HasForeignKey("ClinicId")
                        .HasConstraintName("FK_GReserve_Clinic")
                        .IsRequired();

                    b.HasOne("DrReport.Models.GeneralDiagnosisTest", "Gdtest")
                        .WithMany("Greserves")
                        .HasForeignKey("GdtestId")
                        .HasConstraintName("FK_GReserve_General Diagnosis Test");

                    b.HasOne("DrReport.Models.Patient", "Patient")
                        .WithMany("Greserves")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK_GReserve_Patient");

                    b.Navigation("Clinic");

                    b.Navigation("Gdtest");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DrReport.Models.Patient", b =>
                {
                    b.HasOne("DrReport.Models.User", "User")
                        .WithMany("Patients")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Patient_Users")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DrReport.Models.Reserve", b =>
                {
                    b.HasOne("DrReport.Models.Clinic", "Clinic")
                        .WithMany("Reserves")
                        .HasForeignKey("ClinicId")
                        .HasConstraintName("FK_Reserve_Clinic")
                        .IsRequired();

                    b.HasOne("DrReport.Models.Doctor", "Doctor")
                        .WithMany("Reserves")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_Reserve_Doctor")
                        .IsRequired();

                    b.HasOne("DrReport.Models.Patient", "Patient")
                        .WithMany("Reserves")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK_Reserve_Patient");

                    b.Navigation("Clinic");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DrReport.Models.User", b =>
                {
                    b.HasOne("DrReport.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .HasConstraintName("FK_Users_UserTypes")
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("DrReport.Models.CandidateDoctor", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("DoctorCrudCdoctors");
                });

            modelBuilder.Entity("DrReport.Models.Clinic", b =>
                {
                    b.Navigation("Greserves");

                    b.Navigation("Reserves");
                });

            modelBuilder.Entity("DrReport.Models.DiagnosisResult", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("DiseaseExistDresults");

                    b.Navigation("DtestDresults");

                    b.Navigation("GdtestDresults");

                    b.Navigation("Gives");
                });

            modelBuilder.Entity("DrReport.Models.DiagnosisTest", b =>
                {
                    b.Navigation("DiagnosisTestRanges");

                    b.Navigation("DiseaseRelateDtests");

                    b.Navigation("DtestDresults");
                });

            modelBuilder.Entity("DrReport.Models.Disease", b =>
                {
                    b.Navigation("DiseaseExistDresults");

                    b.Navigation("DiseaseRelateDtests");

                    b.Navigation("DiseaseRelateGdtests");

                    b.Navigation("DiseaseSymptoms");
                });

            modelBuilder.Entity("DrReport.Models.Doctor", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("Clinics");

                    b.Navigation("DiagnosisResults");

                    b.Navigation("DiagnosisTests");

                    b.Navigation("DoctorCrudCdoctors");

                    b.Navigation("GeneralDiagnosisTests");

                    b.Navigation("Gives");

                    b.Navigation("Reserves");
                });

            modelBuilder.Entity("DrReport.Models.GeneralDiagnosisTest", b =>
                {
                    b.Navigation("DiseaseRelateGdtests");

                    b.Navigation("GdtestDresults");

                    b.Navigation("Greserves");
                });

            modelBuilder.Entity("DrReport.Models.Patient", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("Gives");

                    b.Navigation("Greserves");

                    b.Navigation("Reserves");
                });

            modelBuilder.Entity("DrReport.Models.User", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("DrReport.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
