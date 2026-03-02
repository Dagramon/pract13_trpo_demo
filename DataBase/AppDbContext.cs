using Microsoft.EntityFrameworkCore;

using pract12_trpo.Classes;
using pract12_trpo.Classes.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_trpo.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseStudent> CoursesStudents { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.ects;Database=KaramovSchoolDB;User Id=student_10;Password=student_10;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Passport)
                .WithOne(ps => ps.Student)
                .HasForeignKey<Passport>(ps => ps.StudentId);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);
            modelBuilder.Entity<CourseStudent>()
                .HasKey(cs => new { cs.StudentId, cs.CourseId });
            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(cs => cs.StudentId);
            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(cs => cs.CourseId);
        }
    }
}
