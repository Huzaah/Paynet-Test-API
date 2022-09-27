using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Paynet_Test_API
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SchoolSubject> SchoolSubjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherToSubjectLink> TeacherToSubjectLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=School;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<SchoolSubject>(entity =>
            {
                entity.HasKey(e => e.SubjectId)
                    .HasName("PK__SchoolSu__ACF9A7607FF541E7");

                entity.ToTable("SchoolSubject");

                entity.Property(e => e.SubjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("subjectId");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("subjectName");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId)
                    .ValueGeneratedNever()
                    .HasColumnName("teacherId");

                entity.Property(e => e.TeacherLname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("teacherLName");

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("teacherName");
            });

            modelBuilder.Entity<TeacherToSubjectLink>(entity =>
            {
                entity.HasKey(e => e.LinkId)
                    .HasName("PK__TeacherT__200C70DF349029C4");

                entity.ToTable("TeacherToSubjectLink");

                entity.Property(e => e.LinkId)
                    .ValueGeneratedNever()
                    .HasColumnName("linkId");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeacherToSubjectLinks)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__TeacherTo__subje__2D27B809");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherToSubjectLinks)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__TeacherTo__teach__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
