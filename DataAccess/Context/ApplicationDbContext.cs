/*
    Microsoft.EntityFrameworkCore
    Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools
    Microsoft.AspNetCore.Identity.EntityframeworkCore
 */
using DataAccess.Entities;
using DataAccess.Maps;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Salloon> Salloons { get; set; }
        public DbSet<Reservation> Reservations  { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Week> Weeks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MovieGenreMap());
            base.OnModelCreating(builder);
        }



    }
}
