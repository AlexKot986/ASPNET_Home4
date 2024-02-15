using AuthLearn.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthLearn.DAL.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Salt).IsRequired();

            builder.HasOne<Role>().WithMany().HasForeignKey(x=>x.RoleId);
        }
    }
}
