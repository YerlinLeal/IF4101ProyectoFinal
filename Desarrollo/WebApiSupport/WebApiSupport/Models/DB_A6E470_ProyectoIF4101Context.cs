using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiSupport.Models
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

                entity.HasIndex(e => e.Email, "UQ__Employee__A9D105341B09C387")
                    .IsUnique();

                entity.HasIndex(e => e.Dni, "UQ__Employee__C035B8DDF35C0D2B")
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
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Name");

                entity.Property(e => e.EmployeeType).HasColumnName("Employee_Type");

                entity.Property(e => e.FirstSurname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Surname");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_by");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modify_Date");

                entity.Property(e => e.Password).HasMaxLength(8000);

                entity.Property(e => e.SecondSurname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Second_Surname");

                entity.HasOne(d => d.SupervisedNavigation)
                    .WithMany(p => p.InverseSupervisedNavigation)
                    .HasForeignKey(d => d.Supervised)
                    .HasConstraintName("FK__Employee__Superv__3587F3E0");
            });

            modelBuilder.Entity<EmployeeService>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ServiceId })
                    .HasName("PK__Employee__A3C0969A15436465");

                entity.ToTable("Employee_Services");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_by");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modify_Date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeServices)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee___Emplo__40F9A68C");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.EmployeeServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee___Servi__41EDCAC5");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.ReportNumber)
                    .HasName("PK__Issue__715DB66455B92E32");

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

                entity.HasOne(d => d.EmployeeAssignedNavigation)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.EmployeeAssigned)
                    .HasConstraintName("FK__Issue__Employee___4A8310C6");

                entity.HasOne(d => d.ServiceNavigation)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.Service)
                    .HasConstraintName("FK__Issue__Service__489AC854");
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

                entity.HasOne(d => d.ReportNumberNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.ReportNumber)
                    .HasConstraintName("FK__Notes__Report_Nu__4D5F7D71");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_by");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modify_Date");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
