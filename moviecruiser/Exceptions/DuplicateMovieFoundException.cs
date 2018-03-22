using System;

namespace MovieCruiser.Exceptions
{
  public class DuplicateMovieFoundException : ApplicationException
  {
    public DuplicateMovieFoundException() { }
    public DuplicateMovieFoundException(string message) : base(message) { }
  }
}
