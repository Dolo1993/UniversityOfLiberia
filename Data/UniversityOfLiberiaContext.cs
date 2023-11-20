using Microsoft.EntityFrameworkCore;
using UniversityOfLiberia.Models;

namespace UniversityOfLiberia.Data
{
    public class UniversityOfLiberiaContext : DbContext
    {
        public UniversityOfLiberiaContext(DbContextOptions<UniversityOfLiberiaContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; } // Corrected type

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Other configurations...

            modelBuilder.Entity<CourseAssignment>().HasKey(c => new { c.InstructorID, c.CourseID });

            // Ensure that the table name is correctly specified for the 'Departments' entity.
            modelBuilder.Entity<Department>().ToTable("Departments");

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
