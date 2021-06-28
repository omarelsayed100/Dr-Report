using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DrReport.Models
{
    public partial class MedicalDBContext : DbContext
    {
        public MedicalDBContext()
        {
        }

        public MedicalDBContext(DbContextOptions<MedicalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CandidateDoctor> CandidateDoctors { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<DiagnosisResult> DiagnosisResults { get; set; }
        public virtual DbSet<DiagnosisTest> DiagnosisTests { get; set; }
        public virtual DbSet<DiagnosisTestRange> DiagnosisTestRanges { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<DiseaseExistDresult> DiseaseExistDresults { get; set; }
        public virtual DbSet<DiseaseRelateDtest> DiseaseRelateDtests { get; set; }
        public virtual DbSet<DiseaseRelateGdtest> DiseaseRelateGdtests { get; set; }
        public virtual DbSet<DiseaseSymptom> DiseaseSymptoms { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorCrudCdoctor> DoctorCrudCdoctors { get; set; }
        public virtual DbSet<DtestDresult> DtestDresults { get; set; }
        public virtual DbSet<GdtestDresult> GdtestDresults { get; set; }
        public virtual DbSet<GdtestRelateDtest> GdtestRelateDtests { get; set; }
        public virtual DbSet<GeneralDiagnosisTest> GeneralDiagnosisTests { get; set; }
        public virtual DbSet<Give> Gives { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Reserve> Reserves { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6I90SI9; Database = MedicalDB ; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(e => new { e.CdoctorId, e.DresultId });

                entity.ToTable("Candidate");

                entity.Property(e => e.CdoctorId).HasColumnName("Cdoctor_ID");

                entity.Property(e => e.DresultId).HasColumnName("Dresult_ID");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.PatientId).HasColumnName("Patient_ID");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cdoctor)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.CdoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidate_Candidate Doctor");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Candidate_Doctor");

                entity.HasOne(d => d.Dresult)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.DresultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidate_Diagnosis Result");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Candidate_Patient");
            });

            modelBuilder.Entity<CandidateDoctor>(entity =>
            {
                entity.ToTable("Candidate Doctor");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN");

                entity.Property(e => e.Specialize)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.ToTable("Clinic");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApClosetime)
                    .HasColumnType("date")
                    .HasColumnName("AP_Closetime");

                entity.Property(e => e.ApOpentime)
                    .HasColumnType("date")
                    .HasColumnName("AP_Opentime");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Clinics)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Clinic_Doctor");
            });

            modelBuilder.Entity<DiagnosisResult>(entity =>
            {
                entity.ToTable("Diagnosis Result");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AutoDresult)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Auto_Dresult");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.DoctorNote)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Doctor_Note");

                entity.Property(e => e.StatDresult).HasColumnName("Stat_Dresult");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DiagnosisResults)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Diagnosis Result_Doctor");
            });

            modelBuilder.Entity<DiagnosisTest>(entity =>
            {
                entity.ToTable("Diagnosis Test");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DiagnosisTests)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Diagnosis Test_Doctor");
            });

            modelBuilder.Entity<DiagnosisTestRange>(entity =>
            {
                entity.HasKey(e => new { e.DtestId, e.PatientType });

                entity.ToTable("Diagnosis Test Range");

                entity.Property(e => e.DtestId).HasColumnName("Dtest_ID");

                entity.Property(e => e.PatientType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Patient_Type");

                entity.Property(e => e.EndRange).HasColumnName("End_Range");

                entity.Property(e => e.StartRange).HasColumnName("Start_Range");

                entity.HasOne(d => d.Dtest)
                    .WithMany(p => p.DiagnosisTestRanges)
                    .HasForeignKey(d => d.DtestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diagnosis Test Range_Diagnosis Test");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.ToTable("Disease");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precaution)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DiseaseExistDresult>(entity =>
            {
                entity.HasKey(e => new { e.DiseaseId, e.DresultId });

                entity.ToTable("Disease_Exist_Dresult");

                entity.Property(e => e.DiseaseId).HasColumnName("Disease_ID");

                entity.Property(e => e.DresultId).HasColumnName("Dresult_ID");

                entity.HasOne(d => d.Disease)
                    .WithMany(p => p.DiseaseExistDresults)
                    .HasForeignKey(d => d.DiseaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Disease_Exist_Dresult_Disease");

                entity.HasOne(d => d.Dresult)
                    .WithMany(p => p.DiseaseExistDresults)
                    .HasForeignKey(d => d.DresultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Disease_Exist_Dresult_Diagnosis Result");
            });

            modelBuilder.Entity<DiseaseRelateDtest>(entity =>
            {
                entity.HasKey(e => new { e.DiseaseId, e.DtestId });

                entity.ToTable("Disease_relate_Dtest");

                entity.Property(e => e.DiseaseId).HasColumnName("Disease_ID");

                entity.Property(e => e.DtestId).HasColumnName("Dtest_ID");

                entity.HasOne(d => d.Disease)
                    .WithMany(p => p.DiseaseRelateDtests)
                    .HasForeignKey(d => d.DiseaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Disease_relate_Dtest_Disease");
            });

            modelBuilder.Entity<DiseaseRelateGdtest>(entity =>
            {
                entity.HasKey(e => new { e.DiseaseId, e.GdtestId });

                entity.ToTable("Disease_relate_GDtest");

                entity.Property(e => e.DiseaseId).HasColumnName("Disease_ID");

                entity.Property(e => e.GdtestId).HasColumnName("GDtest_ID");

                entity.HasOne(d => d.Disease)
                    .WithMany(p => p.DiseaseRelateGdtests)
                    .HasForeignKey(d => d.DiseaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Disease_relate_GDtest_Disease");

                entity.HasOne(d => d.Gdtest)
                    .WithMany(p => p.DiseaseRelateGdtests)
                    .HasForeignKey(d => d.GdtestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Disease_relate_GDtest_General Diagnosis Test");
            });

            modelBuilder.Entity<DiseaseSymptom>(entity =>
            {
                entity.ToTable("Disease Symptoms");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DiseaseId).HasColumnName("Disease_ID");

                entity.Property(e => e.Symptom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Disease)
                    .WithMany(p => p.DiseaseSymptoms)
                    .HasForeignKey(d => d.DiseaseId)
                    .HasConstraintName("FK_Disease Symptoms_Disease1");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MedicalLicenseId).HasColumnName("MedicalLicense_ID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_Users");
            });

            modelBuilder.Entity<DoctorCrudCdoctor>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.CdoctorId });

                entity.ToTable("Doctor_CRUD_Cdoctor");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.CdoctorId).HasColumnName("Cdoctor_ID");

                entity.HasOne(d => d.Cdoctor)
                    .WithMany(p => p.DoctorCrudCdoctors)
                    .HasForeignKey(d => d.CdoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_CRUD_Cdoctor_Candidate Doctor");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorCrudCdoctors)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_CRUD_Cdoctor_Doctor");
            });

            modelBuilder.Entity<DtestDresult>(entity =>
            {
                entity.HasKey(e => new { e.DresultId, e.DtestId });

                entity.ToTable("Dtest_Dresult");

                entity.Property(e => e.DresultId).HasColumnName("Dresult_ID");

                entity.Property(e => e.DtestId).HasColumnName("Dtest_ID");

                entity.Property(e => e.ResultValue).HasColumnName("Result_Value");

                entity.HasOne(d => d.Dresult)
                    .WithMany(p => p.DtestDresults)
                    .HasForeignKey(d => d.DresultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dtest_Dresult_Diagnosis Result");

                entity.HasOne(d => d.Dtest)
                    .WithMany(p => p.DtestDresults)
                    .HasForeignKey(d => d.DtestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dtest_Dresult_Diagnosis Test");
            });

            modelBuilder.Entity<GdtestDresult>(entity =>
            {
                entity.HasKey(e => new { e.DresultId, e.GdtestId });

                entity.ToTable("GDtest_Dresult");

                entity.Property(e => e.DresultId).HasColumnName("Dresult_ID");

                entity.Property(e => e.GdtestId).HasColumnName("GDtest_ID");

                entity.HasOne(d => d.Dresult)
                    .WithMany(p => p.GdtestDresults)
                    .HasForeignKey(d => d.DresultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GDtest_Dresult_Diagnosis Result");

                entity.HasOne(d => d.Gdtest)
                    .WithMany(p => p.GdtestDresults)
                    .HasForeignKey(d => d.GdtestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GDtest_Dresult_General Diagnosis Test");
            });

            modelBuilder.Entity<GdtestRelateDtest>(entity =>
            {
                entity.HasKey(e => new { e.GdtestId, e.DtestId });

                entity.ToTable("GDtest_relate_Dtest");

                entity.Property(e => e.GdtestId).HasColumnName("GDtest_ID");

                entity.Property(e => e.DtestId).HasColumnName("Dtest_ID");

                entity.HasOne(d => d.Dtest)
                    .WithMany(p => p.GdtestRelateDtests)
                    .HasForeignKey(d => d.DtestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GDtest_relate_Dtest_Diagnosis Test");

                entity.HasOne(d => d.Gdtest)
                    .WithMany(p => p.GdtestRelateDtests)
                    .HasForeignKey(d => d.GdtestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GDtest_relate_Dtest_General Diagnosis Test");
            });

            modelBuilder.Entity<GeneralDiagnosisTest>(entity =>
            {
                entity.ToTable("General Diagnosis Test");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.GeneralDiagnosisTests)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_General Diagnosis Test_Doctor");
            });

            modelBuilder.Entity<Give>(entity =>
            {
                entity.HasKey(e => new { e.DresultId, e.SendDate });

                entity.ToTable("Give");

                entity.Property(e => e.DresultId).HasColumnName("Dresult_ID");

                entity.Property(e => e.SendDate)
                    .HasColumnType("date")
                    .HasColumnName("Send_Date");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.PatientId).HasColumnName("Patient_ID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Gives)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Give_Doctor");

                entity.HasOne(d => d.Dresult)
                    .WithMany(p => p.Gives)
                    .HasForeignKey(d => d.DresultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Give_Diagnosis Result");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Gives)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Give_Patient");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Users");
            });

            modelBuilder.Entity<Reserve>(entity =>
            {
                entity.ToTable("Reserve");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClinicId).HasColumnName("Clinic_ID");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.DtestName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Dtest_Name");

                entity.Property(e => e.PatientId).HasColumnName("Patient_ID");

                entity.Property(e => e.PotentialDisease)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Potential_Disease");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Request_Date");

                entity.Property(e => e.ReservationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Reservation_Date");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Reserves)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserve_Clinic");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Reserves)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserve_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Reserves)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserve_Patient");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserTypes");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserTypeID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
