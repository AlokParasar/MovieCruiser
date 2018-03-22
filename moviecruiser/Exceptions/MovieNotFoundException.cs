using System;

namespace MovieCruiser.Exceptions
{
  public class MovieNotFoundException : ApplicationException
  {
    public MovieNotFoundException() { }
    public MovieNotFoundException(string message) : base(message) { }
  }
}
