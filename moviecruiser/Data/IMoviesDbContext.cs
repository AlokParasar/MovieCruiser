namespace MovieCruiser.Data
{
  using Microsoft.EntityFrameworkCore;
  using Data.Models;

  public interface IMoviesDbContext
  {
    DbSet<Movie> Movies { get; set; }
    int SaveChanges();
  }
}
