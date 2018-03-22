namespace MovieCruiser.Data.Persistance
{
  using System.Collections.Generic;
  using Data.Models;

  public interface IMovieRepository
  {
    Movie Add(Movie movie);
    List<Movie> GetMovies();
    Movie GetMovieById(int id);
    bool Remove(int id);
    Movie Update(int id, string comment);
  }
}
