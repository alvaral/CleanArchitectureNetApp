using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "9a0e02be - b73e - 4d2d - 8202 - c6472abd5211",
                    RoleId = "4a474a30-e030-4331-b025-8d814f45a508",
                },
                new IdentityUserRole<string>
                {
                    UserId = "ce732cab-604d-4935-9972-dde028e21588",
                    RoleId = "796e3df0-1cde-4991-9877-c6c6986e2e00",
                }
            );
        }
    }
}
