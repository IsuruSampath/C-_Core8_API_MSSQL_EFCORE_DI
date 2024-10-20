using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Moq;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Linq;
using System.Text.Json;
using WebAPI_WithDI.DB;
using WebAPI_WithDI.Models;
using WebAPI_WithDI.Service;

namespace WebAPI_WithDI.Test
{
    public class MovieService_test
    {
        private DbContextOptions<MyDBContext> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<MyDBContext>()
                .UseInMemoryDatabase(databaseName: "SQLConnection_test")
                .Options;
        }

        [Fact]
        public async Task GetAllMovies_ShouldReturnAllMovies()
        {
            //given
            var m1 = new Movie { Title = "Pirates of the Caribbean: The Curse of the Black Pearl", Genre = "Adventure,Fantacy", Description = "superb movie" };
            var m2 = new Movie { Title = "Pirates of the Caribbean: Dead Man's Chest", Genre = "Adventure,Fantacy", Description = "superb movie" };
            var m3 = new Movie { Title = "Pirates of the Caribbean: At World's End", Genre = "Adventure,Fantacy", Description = "damn good movie" };
            var options = GetInMemoryOptions();

            using (var context = new MyDBContext(options))
            {
                context.Movies.Add(m1);
                context.Movies.Add(m2);
                context.Movies.Add(m3);
                context.SaveChanges();

                var _movieService = new MovieService(context);

                //when
                ResponseModel mResult = await _movieService.GetAllMovies();

                //then
                Assert.IsType<ResponseModel>(mResult);
                Assert.True(mResult.IsSuccess);
                Assert.Contains(JsonSerializer.Serialize(m1), JsonSerializer.Serialize(mResult.Data));
            }
        }

        [Fact]
        public async Task AddMovie_ShouldAddMovie()
        {
            //given
            var m4 = new Movie { Title = "Pirates of the Caribbean: On Stranger Tides", Genre = "Adventure,Fantacy", Description = "will be a damn good movie" };
            var options = GetInMemoryOptions();

            using (var context = new MyDBContext(options))
            {
                var _movieService = new MovieService(context);

                //when
                ResponseModel mResult = await _movieService.AddMovie(m4);
                
                //then
                Assert.IsType<ResponseModel>(mResult);
                Assert.True(mResult.IsSuccess);
            }
        }
    }
}