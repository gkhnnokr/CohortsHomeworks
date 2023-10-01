using BookStore.DBOperation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
using BookStore.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DataGenerator>();
// Add services for in-memory database and BookRepository
builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<BookStoreDbContext>();
    var dataGenerator = services.GetRequiredService<DataGenerator>();

    // Initialize data using DataGenerator
    DataGenerator.Initialize(services);

    // Access the data from the in-memory database
    var books = dbContext.Books.ToList();

    // Now 'books' should contain the data generated by DataGenerator
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCostumExceptionMiddle();

app.MapControllers();

app.Run();
