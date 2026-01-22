using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new { e.UserId, e.CourseId });
            builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
            builder.HasOne(e => e.Course).WithMany().HasForeignKey(e => e.CourseId);
        }
    }
}