using FirstGenericRepository.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FirstGenericRepository.DataAcces.Context
{
    public class FirstGenericRepositoryDbContext(DbContextOptions<FirstGenericRepositoryDbContext> options) : DbContext(options)
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Biography> Biography { get; set; }
        public DbSet<Genre> genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "Chuck", LastName = "Norris" },
                new Actor { Id = 2, FirstName = "Jane", LastName = "Doe" },
                new Actor { Id = 3, FirstName = "Van", LastName = "Damne" }
                );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "WakandaForEver", Description = "Box office coming", ActorId = 1 },
                new Movie { Id = 2, Name = "WakandaForEver2", Description = "Box office coming two", ActorId = 2 },
                new Movie { Id = 3, Name = "WakandaForEver3", Description = "Box office coming three", ActorId = 3 },
                new Movie { Id = 4, Name = "WakandaForEver2bis", Description = "Box office coming two", ActorId = 2 }

                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
