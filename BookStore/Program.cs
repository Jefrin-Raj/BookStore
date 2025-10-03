using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<BookStore.Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<BookStore.Business.Interface.IBooksRepository, BookStore.Business.Repository.BooksRepository>();
builder.Services.AddScoped<BookStore.Business.Interface.IBooksBusiness, BookStore.Business.BooksBusiness>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.MapControllers();

// ...existing code...
app.Run();
