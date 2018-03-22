namespace MovieCruiser.Data
{
  using Microsoft.EntityFrameworkCore;
  using Data.Models;

  public class MoviesDbContext:DbContext, IMoviesDbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
    }
}
