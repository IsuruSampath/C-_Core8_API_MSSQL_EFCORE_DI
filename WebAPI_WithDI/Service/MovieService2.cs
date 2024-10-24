using WebAPI_WithDI.Models;

namespace WebAPI_WithDI.Service
{
    public class MovieService2 : IMovieService
    {
        public async Task<ResponseModel> AddMovie(Movie movie)
        {
            return new ResponseModel
            {
                IsSuccess = true,
                Message = "dummy AddMovie",
                Code = "100",
                Data = null
            };
        }

        public async Task<ResponseModel> GetAllMovies()
        {
            return new ResponseModel
            {
                IsSuccess = true,
                Message = "dummy GetAllMovies",
                Code = "100",
                Data = null
            };
        }

        public async Task<ResponseModel> GetMovieById(int id)
        {
            ResponseModel rp = new ResponseModel
            {
                IsSuccess = true,
                Message = "dummy GetMovieById",
                Code = "100",
                Data = null
            };

            return rp;
        }

        public async Task<ResponseModel> RemoveMovie(int id)
        {
            return new ResponseModel
            {
                IsSuccess = true,
                Message = "dummy RemoveMovie",
                Code = "100",
                Data = null
            };
        }

        public async Task<ResponseModel> UpdateMovie(Movie movie)
        {
            return new ResponseModel
            {
                IsSuccess = true,
                Message = "dummy UpdateMovie",
                Code = "100",
                Data = null
            };
        }
    }
}
