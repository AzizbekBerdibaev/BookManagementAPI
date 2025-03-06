using BookManagementAPI;
using BookManagementAPI.Dtos;
using BookManagementAPI.Entities;
using BookManagementAPI.Service;
using BookManagementAPI.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IValidator<CreateBookDto>, CreateBookDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateBookDto>, UpdateBookDtoValidator>();

builder.Services.AddScoped <IBookService, BookService>();



builder.Services.AddDbContext<BookDBContext>(options =>
{
    var connectionString = "Host=localhost; Port=5432; Database=BookManagement; Username=postgres; Password=2005";

    options.UseNpgsql(connectionString)
           .UseLazyLoadingProxies()
           .UseSnakeCaseNamingConvention();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
