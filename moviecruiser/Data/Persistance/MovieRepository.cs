namespace MovieCruiser.Data.Persistance
{
  using System.Collections.Generic;
  using Data.Models;
  using Exceptions;

  public class MovieRepository : IMovieRepository
  {
    private readonly IMoviesDbContext _context;
    public MovieRepository(IMoviesDbContext context)
    {
      _context = context;
    }

    #region CRUD methods
    public Movie Add(Movie movie)
    {
      Movie _movie = _context.Movies.Find(movie.id);
      if (_movie == null)
      {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return movie;
      }
      else
      {
        throw new DuplicateMovieFoundException("This movie is already in your favorites");
      }
    }

    public Movie GetMovieById(int id)
    {
      Movie _movie = _context.Movies.Find(id);
      if (_movie != null)
      {
        return _movie;
      }
      else
      {
        throw new MovieNotFoundException("No movie found with this id");
      }
    }

    public List<Movie> GetMovies()
    {
      List<Movie> _movies = new List<Movie>();
      return _movies;
    }

    public bool Remove(int id)
    {
      Movie _movie = _context.Movies.Find(id);
      if (_movie != null)
      {
        _context.Movies.Remove(_movie);
        _context.SaveChanges();
        return true;
      }
      else
      {
        throw new MovieNotFoundException("No movie found with this id");
      }
    }

    public Movie Update(int id, string comment)
    {
      Movie _movie = _context.Movies.Find(id);
      if (_movie != null)
      {
        _movie.comments = comment;
        _context.SaveChanges();
        return _movie;
      }
      else
      {
        throw new MovieNotFoundException("No movie found with this id");
      }
    }
    #endregion
  }
}
