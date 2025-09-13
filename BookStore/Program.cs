using BookStore.Application.Services;
using BookStore.DataAcces;
using BookStore.DataAcces.Reposotories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookStoreDbContext>(
    options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BookStoreDbContext))));

builder.Services.AddScoped<IBooksRepository, BookRepository>();
builder.Services.AddScoped<IBooksService, BooksService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
