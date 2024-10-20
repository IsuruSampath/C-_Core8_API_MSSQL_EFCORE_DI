using Microsoft.EntityFrameworkCore;
using WebAPI_WithDI.DB;
using WebAPI_WithDI.Models;
using WebAPI_WithDI.Util;

namespace WebAPI_WithDI.Service
{
    public class MovieService : IMovieService
    {
        private readonly MyDBContext? _dbContext;
        private ResponseModel response;

        public MovieService(MyDBContext myDBContext)
        {
            _dbContext = myDBContext;
        }

        public async Task<ResponseModel> AddMovie(Movie movie)
        {
            try
            {
                _dbContext.Movies.Add(movie);
                int result = await _dbContext.SaveChangesAsync();
                response = new ResponseModel()
                {
                    IsSuccess = true,
                    Code = Utils.responseStatus.SUCCESS.ToString(),
                    Message = "Movie add success",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                response = new ResponseModel()
                {
                    IsSuccess = false,
                    Code = Utils.responseStatus.EXCEPTION.ToString(),
                    Message = "Movie add failed",
                    Data = "exception : " + ex.Message + " | inner exception : " + ex.InnerException
                };
            }
            return response;
        }

        public async Task<ResponseModel> GetAllMovies()
        {
            try
            {
                List<Movie> mList = await _dbContext.Movies.ToListAsync();
                if (mList == null && mList.Count == 0)
                {
                    response = new ResponseModel()
                    {
                        IsSuccess = false,
                        Code = Utils.responseStatus.FAIL.ToString(),
                        Message = "Movie list not available",
                        Data = "",
                    };
                }
                else
                {
                    response = new ResponseModel()
                    {
                        IsSuccess = true,
                        Code = Utils.responseStatus.SUCCESS.ToString(),
                        Message = "Movie list available",
                        Data = mList,
                    };
                }
            }
            catch (Exception ex)
            {
                response = new ResponseModel()
                {
                    IsSuccess = false,
                    Code = Utils.responseStatus.EXCEPTION.ToString(),
                    Message = "Movie list not available",
                    Data = "exception : " + ex.Message + " | inner exception : " + ex.InnerException,
                };
            }
            return response;
        }

        public async Task<ResponseModel> GetMovieById(int id)
        {
            try
            {
                Movie movie = await _dbContext.Movies.FirstOrDefaultAsync(a => a.Id == id);
                if (movie == null)
                {
                    response = new ResponseModel()
                    {
                        IsSuccess = false,
                        Code = Utils.responseStatus.FAIL.ToString(),
                        Message = "Movie not available",
                        Data = "",
                    };
                }
                else
                {
                    response = new ResponseModel()
                    {
                        IsSuccess = true,
                        Code = Utils.responseStatus.SUCCESS.ToString(),
                        Message = "Movie available",
                        Data = movie,
                    };
                }        
            }
            catch (Exception ex)
            {
                response = new ResponseModel()
                {
                    IsSuccess = false,
                    Code = Utils.responseStatus.EXCEPTION.ToString(),
                    Message = "Movie not available",
                    Data = "exception : " + ex.Message + " | inner exception : " + ex.InnerException,
                };
            }
            return response;
        }

        public async Task<ResponseModel> RemoveMovie(int id)
        {
            try
            {
                Movie movie = _dbContext.Movies.FirstOrDefault(a => a.Id == id);
                _dbContext.Movies.Remove(movie);
                await _dbContext.SaveChangesAsync();

                response = new ResponseModel()
                {
                    IsSuccess = true,
                    Code = Utils.responseStatus.SUCCESS.ToString(),
                    Message = "Movie remove success",
                    Data = ""
                };
            }
            catch (Exception ex)
            {
                response = new ResponseModel()
                {
                    IsSuccess = false,
                    Code = Utils.responseStatus.EXCEPTION.ToString(),
                    Message = "Movie remove failed",
                    Data = "exception : " + ex.Message + " | inner exception : " + ex.InnerException
                };
            }
            return response;
        }

        public async Task<ResponseModel> UpdateMovie(Movie movie)
        {
            try
            {
                _dbContext.Movies.Update(movie);
                int result = await _dbContext.SaveChangesAsync();
                response = new ResponseModel()
                {
                    IsSuccess = true,
                    Code = Utils.responseStatus.SUCCESS.ToString(),
                    Message = "Movie update success",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                response = new ResponseModel()
                {
                    IsSuccess = false,
                    Code = Utils.responseStatus.EXCEPTION.ToString(),
                    Message = "Movie update failed",
                    Data = "exception : " + ex.Message + " | inner exception : " + ex.InnerException
                };
            }
            return response;
        }
    }
}
