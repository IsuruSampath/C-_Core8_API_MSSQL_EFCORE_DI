using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI_WithDI.DB;
using WebAPI_WithDI.Models;

namespace WebAPI_WithDI.Test
{
    public class MyDbContext_test
    {
        private DbContextOptions<MyDBContext> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<MyDBContext>()
                .UseInMemoryDatabase(databaseName: "SQLConnection_test")
                .Options;
        }

        //Test db context file
        [Fact]
        public void AbleToInsertAndRetrieveData()
        {
            var m1 = new Movie { Title = "LOTR:The fellowship of the ring", Genre = "Adventure,Fantacy", Description = "Nice movie" };

            var options = GetInMemoryOptions();

            using (var context = new MyDBContext(options))
            {
                context.Movies.Add(m1);
                context.SaveChanges();
            }

            using(var context = new MyDBContext(options))
            {
                var movie = context.Movies.FirstOrDefault(k => k.Title == "LOTR:The fellowship of the ring");
                Assert.NotNull(movie);
                Assert.Equal(JsonSerializer.Serialize(m1) ,JsonSerializer.Serialize(movie));
            }
        }
    }
}
