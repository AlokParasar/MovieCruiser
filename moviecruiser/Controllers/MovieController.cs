/// <summary>
/// The Movie Cruiser Controller
/// </summary>
namespace MovieCruiser.Controllers
{
  using System;
  using System.Collections.Generic;
  using Microsoft.AspNetCore.Mvc;
  using Data.Models;
  using Data.Persistance;
  using Exceptions;
  using ViewModels;

  [Route("api/[controller]")]
  public class MovieController : Controller
  {
    private readonly IMovieRepository _repo;
    public MovieController(IMovieRepository repo)
    {
      _repo = repo;
    }

    /// <summary>
    /// To fetch all movies
    /// GET: api/movie
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
      ApiResponse response = new ApiResponse();
      try
      {
        IList<Movie> _movies = _repo.GetMovies();
        response.Success = true;
        response.Message = string.Empty;
        response.Data = _movies;
        return Ok(response);
      }
      catch (MovieNotFoundException mnf)
      {
        response.Success = false;
        response.Message = mnf.Message;
        response.Data = null;
        return Ok(response);
      }
      catch (Exception Ex)
      {
        var msg = Ex.Message;
        return StatusCode(500);
      }
    }

    /// <summary>
    ///To fetch movie by id
    /// GET: api/movie/Movie Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      ApiResponse response = new ApiResponse();
      try
      {
        Movie _movie = _repo.GetMovieById(id);
        response.Success = true;
        response.Message = string.Empty;
        response.Data = _movie;
        return Ok(response);
      }
      catch (MovieNotFoundException nfe)
      {
        response.Success = false;
        response.Message = nfe.Message;
        response.Data = null;
        return Ok(response);
      }
    }

    /// <summary>
    /// To add a new movie
    /// POST api/movie
    /// </summary>
    /// <param name="movie"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody]Movie movie)
    {
      ApiResponse response = new ApiResponse();
      try
      {
        Movie _movie = _repo.Add(movie);
        response.Success = true;
        response.Message = "Movie added successfully to recommend";
        response.Data = _movie;
        return StatusCode(201, response);
      }
      catch (DuplicateMovieFoundException dne)
      {
        response.Success = false;
        response.Message = dne.Message;
        response.Data = null;
        return StatusCode(409, response);
      }
    }

    /// <summary>
    ///To delete a movie
    /// DELETE api/movie/Movie Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      ApiResponse response = new ApiResponse();
      try
      {
        _repo.Remove(id);
        response.Success = true;
        response.Message = "Movie removed successfully from recommend";
        response.Data = null;
        return StatusCode(202, response);
      }
      catch (MovieNotFoundException nfe)
      {
        response.Success = false;
        response.Message = nfe.Message;
        response.Data = null;
        return Ok(response);
      }
    }

    /// <summary>
    ///To add/update comments
    ///PUT: api/movie/Movie Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="comment"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] string comment)
    {
      ApiResponse response = new ApiResponse();
      try
      {
        var _movie= _repo.Update(id, comment);
        response.Success = true;
        response.Message = "Movie comments successfully updated";
        response.Data = _movie;
        return Ok(response);
      }
      catch (MovieNotFoundException nfe)
      {
        response.Success = false;
        response.Message = nfe.Message;
        response.Data = null;
        return Ok(response);
      }
    }
  }
}
