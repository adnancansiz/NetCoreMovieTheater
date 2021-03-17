using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Maps
{
    public class MovieGenreMap : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.Ignore(x => x.Id);
            builder.HasKey(x => new { x.MovieId, x.GenreId });
            builder.HasOne(x => x.Movie).WithMany(x => x.MovieGenres).HasForeignKey(x => x.MovieId);
            builder.HasOne(x => x.Genre).WithMany(x => x.MovieGenres).HasForeignKey(x => x.GenreId);
        }
    }
}
