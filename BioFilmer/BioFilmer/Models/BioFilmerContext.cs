using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Newtonsoft.Json;

namespace BioFilmer.Models
{
    public class BioFilmerContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieShowtime> MovieShowtimes { get; set; }

        public BioFilmerContext(string connectionString) 
        {
            this.Database.SetConnectionString(connectionString);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BioFilmer");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
                .Property(f => f.Genres)
                .HasConversion(
                    e => JsonConvert.SerializeObject(e),
                    e => JsonConvert.DeserializeObject<string[]>(e)
                ); 
            
            builder.Entity<MovieShowtime>()
                .HasKey(
                    k => new { k.CinemaName, k.MovieTitle, k.Showtime}
                );
        }
    }
}
