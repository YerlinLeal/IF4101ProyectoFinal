using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPISoporte.Models
{
    public partial class DB_A6E470_ProyectoIF4101Context : DbContext
    {
        public DB_A6E470_ProyectoIF4101Context()
        {
        }

        public DB_A6E470_ProyectoIF4101Context(DbContextOptions<DB_A6E470_ProyectoIF4101Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeService> EmployeeServices { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Supervised> Superviseds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SQL5101.site4now.net;Initial Catalog=DB_A6E470_ProyectoIF4101;User ID=DB_A6E470_ProyectoIF4101_admin;Password=Monkey1099");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.Dni, "UQ__Employee__C035B8DDA7981186")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Name");

                entity.Property(e => e.EmployeeState)
                    .HasColumnName("Employee_State")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmployeeType).HasColumnName("Employee_Type");

                entity.Property(e => e.FirstSurname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Surname");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_by");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modify_Date");

                entity.Property(e => e.SecondSurname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Second_Surname");
            });

            modelBuilder.Entity<EmployeeService>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Employee_Service");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Employee___Emplo__4222D4EF");

                entity.HasOne(d => d.Service)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Employee___Servi__4316F928");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.ReportNumber)
                    .HasName("PK__Issue__715DB664B14B9064");

                entity.ToTable("Issue");

                entity.Property(e => e.ReportNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("Report_Number");

                entity.Property(e => e.Classification)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeAssigned).HasColumnName("Employee_Assigned");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_by");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modify_Date");

                entity.Property(e => e.ReportTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Report_Timestamp")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ResolutionComment)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Resolution_Comment");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.IssueCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Issue__Created_B__398D8EEE");

                entity.HasOne(d => d.EmployeeAssignedNavigation)
                    .WithMany(p => p.IssueEmployeeAssignedNavigations)
                    .HasForeignKey(d => d.EmployeeAssigned)
                    .HasConstraintName("FK__Issue__Employee___38996AB5");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.IssueModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK__Issue__Modified___3A81B327");

                entity.HasOne(d => d.ServiceNavigation)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.Service)
                    .HasConstraintName("FK__Issue__Service__36B12243");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.NoteId).HasColumnName("Note_Id");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_by");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modify_Date");

                entity.Property(e => e.NoteTimestamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("Note_Timestamp");

                entity.Property(e => e.ReportNumber).HasColumnName("Report_Number");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.NoteCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Notes__Created_B__3F466844");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.NoteModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK__Notes__Modified___403A8C7D");

                entity.HasOne(d => d.ReportNumberNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.ReportNumber)
                    .HasConstraintName("FK__Notes__Report_Nu__3D5E1FD2");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supervised>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Supervised");

                entity.Property(e => e.SupervisedId).HasColumnName("Supervised_ID");

                entity.Property(e => e.SupervisorId).HasColumnName("Supervisor_ID");

                entity.HasOne(d => d.SupervisedNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SupervisedId)
                    .HasConstraintName("FK__Supervise__Super__29572725");

                entity.HasOne(d => d.Supervisor)
                    .WithMany()
                    .HasForeignKey(d => d.SupervisorId)
                    .HasConstraintName("FK__Supervise__Super__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
