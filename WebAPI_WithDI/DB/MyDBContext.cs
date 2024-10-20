using Microsoft.EntityFrameworkCore;
using WebAPI_WithDI.Models;

namespace WebAPI_WithDI.DB
{
    public class MyDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> dbContextOptions):base(dbContextOptions) {
        
        }
    }
}
