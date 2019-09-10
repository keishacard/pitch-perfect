using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pitch_perfect.Models;

namespace pitch_perfect.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Pitch> Pitch { get; set; }
        public DbSet<Publication> Publication { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //User user = new User
            //{
            //    Username = "Sunny",
            //    NormalizedUserName = "SUNNY",
            //    Email = "sunny@dog.com",
            //    NormalizedEmail = "SUNNY@DOG.COM",
            //    EmailConfirmed = true,
            //    LockoutEnabled = false,
            //    SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
            //    Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            //};
            //var passwordHash = new PasswordHasher<User>();
            //user.PasswordHash = passwordHash.HashPassword(user, "Sunny1!");
            ////builder.Entity<User>().HasData(user);

            //Pitch pitch = new Pitch
            //{
            //    PitchId = 1,
            //    UserId = user.Id,
            //    Title = "Dogs Who Dig Live Longer",
            //    Synopsis = "Scientific study proves irrefutably that digging is essential to longevity, not to mention personal sense of accomplishment.",
            //    SubmittedTo = "The Daily Kibble",
            //    DateSubmitted = DateTime.ParseExact("06/09/2019 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
            //};

            //builder.Entity<Pitch>().HasData(pitch);

            //Publication publication = new Publication
            //{
            //    PublicationId = 1,
            //    UserId = user.Id,
            //    Title = "The Daily Kibble",
            //    Specialty = "Daily newspaper for informed canines"
            //};

            //builder.Entity<Publication>().HasData(Publication);
        }
    }
}
//public DbSet<pitch_perfect.Models.Pitch> Pitch { get; set; }
//    }
//}
