using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PostgreDBContext : DbContext
    {
        public PostgreDBContext(DbContextOptions<PostgreDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //here Полностью расписать конфигурацию?
            modelBuilder.Entity<UserProfile>().HasNoKey();
            modelBuilder.Entity<Enrollment>().HasKey(e => new { e.UserId, e.CourseId});
        }
    }

}
