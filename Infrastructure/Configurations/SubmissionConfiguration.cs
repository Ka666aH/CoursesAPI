using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Configurations
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.Assignment).WithMany().HasForeignKey(s => s.AssignmentId);
            builder.HasOne(s => s.User).WithMany().HasForeignKey(s => s.UserId);
        }
    }
}