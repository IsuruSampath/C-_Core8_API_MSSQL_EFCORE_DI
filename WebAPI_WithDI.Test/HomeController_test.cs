using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Moq;
using NPOI.SS.Formula.Functions;
using WebAPI_WithDI.Controllers;
using WebAPI_WithDI.DB;
using WebAPI_WithDI.Models;
using WebAPI_WithDI.Service;
using WebAPI_WithDI.Util;

namespace WebAPI_WithDI.Test
{
    public class HomeController_test
    {

        private readonly Mock<IMovieService> _mockMovieService;
        private readonly HomeController _controller;

        public HomeController_test()
        {
            _mockMovieService = new Mock<IMovieService>();
            _controller = new HomeController(_mockMovieService.Object);
        }

        [Fact]
        public async Task GetAllMoviesInController_ShouldReturnAllMovies()
        {
            var m1 = new Movie { Title = "Harry Potter and the Sorcerer's Stone", Genre = "Adventure,Fantacy", Description = "Nice movie" };
            var m2 = new Movie { Title = "Harry Potter and the Chamber of Secrets", Genre = "Adventure,Fantacy", Description = "superb movie" };
            var m3 = new Movie { Title = "Harry Potter and the Prisoner of Azkaban", Genre = "Adventure,Fantacy", Description = "damn good movie" };
            var movies = new List<Movie> { m1, m2, m3 };

            ResponseModel rModel = new ResponseModel()
            {
                IsSuccess = true,
                Code = Utils.responseStatus.SUCCESS.ToString(),
                Message = "testing",
                Data = movies
            };
            
            _mockMovieService.Setup(s => s.GetAllMovies()).ReturnsAsync(rModel);

            //when
            var result = await _controller.GetAllMovies() as OkObjectResult;

            //then
            Assert.NotNull(result);
            Assert.Equal(rModel, result.Value);
        }

        [Fact]
        public async Task AddMovieInController_ShouldAddMovie()
        {
            //given
            var m1 = new Movie { Title = "Harry Potter and the Goblet of Fire", Genre = "Adventure,Fantacy", Description = "Nice movie" };

            ResponseModel rModel = new ResponseModel()
            {
                IsSuccess = true,
                Code = Utils.responseStatus.SUCCESS.ToString(),
                Message = "testing",
                Data = 1//added to db
            };

            _mockMovieService.Setup(s => s.AddMovie(m1)).ReturnsAsync(rModel);

            //when
            var result = await _controller.AddMovieV1(m1) as OkObjectResult;

            //then
            Assert.NotNull(result);
            Assert.Equal(rModel, result.Value);
        }
    }
}