using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPI_WithDI.DB;
using WebAPI_WithDI.Models;
using WebAPI_WithDI.Service;

namespace WebAPI_WithDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //using parameter
        [HttpGet("/GetMovieV1")]
        public async Task<IActionResult> GetMovieV1(int idx)
        {
            ResponseModel movie = await _movieService.GetMovieById(idx);
            if (movie is not null)
            {
                return Ok(movie);
            }
            else
            {
                return BadRequest();
            }
        }

        //using routing
        [HttpGet("/GetMovieV2/{idx}")]
        public async Task<IActionResult> GetMovieV2(int idx)
        {
            ResponseModel movie = await _movieService.GetMovieById(idx);
            if (movie is not null)
            {
                return Ok(movie);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("/GetAllMovies")]
        public async Task<IActionResult> GetAllMovies()
        {
            ResponseModel list = await _movieService.GetAllMovies();
            if (list is not null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("/AddMovieV1")]
        public async Task<IActionResult> AddMovieV1(Movie movie)
        {
            ResponseModel response = await _movieService.AddMovie(movie);
            if (response is not null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("/AddMovieV2")]
        public async Task<IActionResult> AddMovieV2(string title,string genre, string description)
        {
            Movie movie = new Movie() { Title = title,Genre = genre, Description = description };
            ResponseModel response = await _movieService.AddMovie(movie);
            if (response is not null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("/UpdateMovie")]
        public async Task<IActionResult> UpdateMovie(Movie movie)
        {
            ResponseModel response = await _movieService.UpdateMovie(movie);
            if (response is not null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("/RemoveMovie")]
        public async Task<IActionResult> RemoveMovie(int id)
        {
            ResponseModel response = await _movieService.RemoveMovie(id);
            if (response is not null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
