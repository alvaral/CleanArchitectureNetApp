using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "9a0e02be - b73e - 4d2d - 8202 - c6472abd5211",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Nombre = "Alvaro",
                    Apellidos = "Alonso",
                    UserName = "alvaral",
                    NormalizedUserName="alvaral",
                    PasswordHash = hasher.HashPassword(null, "alvaral2025"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                     Id = "ce732cab-604d-4935-9972-dde028e21588",
                     Email = "juanperez@localhost.com",
                     NormalizedEmail = "juanperez@localhost.com",
                     Nombre = "Juan",
                     Apellidos = "Perez",
                     UserName = "juanperez",
                     NormalizedUserName = "juanperez",
                     PasswordHash = hasher.HashPassword(null, "juanperez2025"),
                     EmailConfirmed = true,
                }
            );
        }
    }
}
