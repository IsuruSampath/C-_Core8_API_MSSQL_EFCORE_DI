using WebAPI_WithDI.Models;

namespace WebAPI_WithDI.Service
{
    public interface IMovieService
    {
        public Task<ResponseModel> GetMovieById(int id);

        public Task<ResponseModel> GetAllMovies();

        public Task<ResponseModel> AddMovie(Movie movie);

        public Task<ResponseModel> UpdateMovie(Movie movie);

        public Task<ResponseModel> RemoveMovie(int id);
    }
}
