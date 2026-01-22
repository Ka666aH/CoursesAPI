using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configurations
{
    public class AuthorshipConfiguration : IEntityTypeConfiguration<Authorship>
    {
        public void Configure(EntityTypeBuilder<Authorship> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.User).WithMany().HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.Course).WithMany().HasForeignKey(a => a.CourseId);
        }
    }
}