using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuseumManagementSystem.Areas.Identity.Data;
using MuseumManagementSystem.Models;

namespace MuseumManagementSystem.Data
{
    public class MuseumManagementSystemDbContext : IdentityDbContext<MuseumManagementSystemUser>
    {
        public MuseumManagementSystemDbContext(DbContextOptions<MuseumManagementSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Muze> Muze { get; set; }

        public DbSet<Eser> Eser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            const string AdminRole = "1";
            const string UserRole = "2";

            const string ADMIN_ID = "41D720B7-7165-4997-98ED-0F6E889804C5";
            const string ADMIN_ID2 = "23477228-D07E-4B3E-A41D-841495F23AF0";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = AdminRole,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = UserRole,
                    Name = "Uye",
                    NormalizedName = "UYE"
                }
            );

            var hasher = new PasswordHasher<MuseumManagementSystemUser>();
            builder.Entity<MuseumManagementSystemUser>().HasData(
                new MuseumManagementSystemUser
                {
                    Id = ADMIN_ID,
                    UserName = "b211210373@sakarya.edu.tr",
                    NormalizedUserName = "B211210373@SAKARYA.EDU.TR",
                    Email = "b211210373@sakarya.edu.tr",
                    NormalizedEmail = "B211210373@SAKARYA.EDU.TR",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "123"),
                    SecurityStamp = string.Empty
                },
                new MuseumManagementSystemUser
                {
                    Id = ADMIN_ID2,
                    UserName = "b211210376@sakarya.edu.tr",
                    NormalizedUserName = "B211210376@SAKARYA.EDU.TR",
                    Email = "b211210376@sakarya.edu.tr",
                    NormalizedEmail = "B211210376@SAKARYA.EDU.TR",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "123"),
                    SecurityStamp = string.Empty
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = AdminRole,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = AdminRole,
                    UserId = ADMIN_ID2
                }
            );
        }
    }
}
