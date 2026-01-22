using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            //builder.HasMany(c => c.Authors).WithOne(a => a.Course).HasForeignKey(a => a.CourseId);
            builder.HasMany(c => c.Modules).WithOne().HasForeignKey(m => m.CourseId);
        }
    }
}