using Microsoft.EntityFrameworkCore;
using ChallengeRandomUserGeneratorAPI.Domain.Entities;

namespace ChallengeRandomUserGeneratorAPI.Infrastructure.Database
{
    public class RUGContext : DbContext
    {
        public RUGContext(DbContextOptions<RUGContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Location, l =>
                {
                    l.OwnsOne(loc => loc.Coordinates);
                    l.OwnsOne(loc => loc.Street);
                    l.OwnsOne(loc => loc.Timezone);
                });

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Dob);

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Id);

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Login);

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Name);

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Registered);

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Picture);
        }

        public DbSet<User> User { get; set; }
    }
}
