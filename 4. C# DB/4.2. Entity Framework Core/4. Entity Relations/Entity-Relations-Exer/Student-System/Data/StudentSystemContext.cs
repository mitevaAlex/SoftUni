using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-NQ0DDAV\\SQLEXPRESS;Database=StudentSystem;Trusted_Connection=True;");
            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(k => new { k.StudentId, k.CourseId });

                entity.HasOne(sc => sc.Student)
                      .WithMany(sc => sc.CourseEnrollments)
                      .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                      .WithMany(sc => sc.StudentsEnrolled)
                      .HasForeignKey(sc => sc.CourseId);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(x => x.Name)
                      .IsUnicode(true);

                entity.Property(x => x.PhoneNumber)
                      .IsUnicode(false);

                entity.HasMany(x => x.HomeworkSubmissions)
                      .WithOne(x => x.Student)
                      .HasForeignKey(x => x.StudentId);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(x => x.Name)
                      .IsUnicode(true);

                entity.Property(x => x.Description)
                      .IsUnicode(true);

                entity.HasMany(x => x.Resources)
                      .WithOne(x => x.Course)
                      .HasForeignKey(x => x.CourseId);

                entity.HasMany(x => x.HomeworkSubmissions)
                      .WithOne(x => x.Course)
                      .HasForeignKey(x => x.CourseId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(x => x.Name)
                      .IsUnicode(true);

                entity.Property(x => x.Url)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(x => x.Content)
                      .IsUnicode(false);
            });
        }
    }
}
