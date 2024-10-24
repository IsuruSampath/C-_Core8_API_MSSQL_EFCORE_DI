using Microsoft.EntityFrameworkCore;
using WebAPI_WithDI.DB;
using WebAPI_WithDI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieService, MovieService2>();
builder.Services.AddDbContext<MyDBContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
