﻿using Microsoft.EntityFrameworkCore;
using SwaggerTesting.Models;

namespace SwaggerTesting.Context
{
    public class PokemonAppDbContext : DbContext
    {
        public PokemonAppDbContext(DbContextOptions<PokemonAppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many to many relationship decleration
            modelBuilder.Entity<PokemonCategory>().HasKey(pc => new { pc.CategoryId, pc.PokemonId });

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(pc => pc.PokemonId);

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(pc => pc.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(pc => pc.CategoryId);

            modelBuilder.Entity<PokemonOwner>().HasKey(pc => new { pc.OwnerId, pc.PokemonId });

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(pc => pc.Owner)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(pc => pc.PokemonId);

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(pc => pc.Owner)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(pc => pc.OwnerId);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electric" },
                new Category { Id = 2, Name = "Water" },
                new Category { Id = 3, Name = "Leaf" }
                );

            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Kanto" },
                new Country { Id = 2, Name = "Saffron City" },
                new Country { Id = 3, Name = "Millet Town" }
                );

            // Seed Owners
            modelBuilder.Entity<Owner>().HasData(
                new Owner { Id = 1, FirstName = "Jack", LastName = "Lodon", Gym = "Brocks Gym", CountryId = 1},
                new Owner { Id = 2, FirstName = "Harry", LastName = "Potter", Gym = "Mistys Gym", CountryId = 2 },
                new Owner { Id = 3, FirstName = "Ash", LastName = "Ketchum", Gym = "Ashs Gym", CountryId = 3 }
                );

            // Seed Reviewers
            modelBuilder.Entity<Reviewer>().HasData(
                new Reviewer { Id = 1, FirstName = "Teddy", LastName = "Smith" },
                new Reviewer { Id = 2, FirstName = "Taylor", LastName = "Jones" },
                new Reviewer { Id = 3, FirstName = "Jessica", LastName = "McGregor" }
                );

            // Seed Pokemons
            modelBuilder.Entity<Pokemon>().HasData(
                new Pokemon { Id = 1, Name = "Pikachu", BirthDate = DateTime.SpecifyKind(new DateTime(1903, 1, 1), DateTimeKind.Utc) },
                new Pokemon { Id = 2, Name = "Squirle", BirthDate = DateTime.SpecifyKind(new DateTime(2000, 10, 7), DateTimeKind.Utc) },
                new Pokemon { Id = 3, Name = "PVenasaur", BirthDate = DateTime.SpecifyKind(new DateTime(1986, 3, 6), DateTimeKind.Utc) }
                  );

            // Seed PokemonCategories
            modelBuilder.Entity<PokemonCategory>().HasData(
                new PokemonCategory { PokemonId = 1, CategoryId = 1 },
                new PokemonCategory { PokemonId = 2, CategoryId = 2 },
                new PokemonCategory { PokemonId = 3, CategoryId = 3 }
                );

            // Seed PokemonOwners
            modelBuilder.Entity<PokemonOwner>().HasData(
                new PokemonOwner { PokemonId = 1, OwnerId = 1 },
                new PokemonOwner { PokemonId = 2, OwnerId = 2 },
                new PokemonOwner { PokemonId = 3, OwnerId = 3 }
                );

            // Seed Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, Title = "Pikachu Review", Text = "Pikachu is the best pokemon, because it is electric", Rating = 5, PokemonId = 1, ReviewerId = 1 },
                new Review { Id = 2, Title = "Squirtle Review", Text = "Squirtle is great", Rating = 5, PokemonId = 2, ReviewerId = 2 },
                new Review { Id = 3, Title = "Venasaur Review", Text = "Venasaur is strong", Rating = 5, PokemonId = 3, ReviewerId = 3 }
                );
        }
    }
}
