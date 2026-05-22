//Program.cs is the main entry point.
//Everything the app needs to work must be registered here before the app starts.

using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AppDbContext>/*this line tells the app, AppDbContext exits*/(options =>
    options.UseSqlServer/*tells to use SQLServer as the database*/(builder.Configuration.GetConnectionString/*Reads the DB address from appsettings.json*/("DefaultConnection")));
//it is called dependency injection.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//To describe API automatically.
app.UseSwagger();

//To provide a user interface for testing the API.
app.UseSwaggerUI();

//Checks wheather user has permission to access APIs.
app.UseAuthorization();

//Tells ASP.NET to use all controller APIs
app.MapControllers();

//Starts the application.
app.Run();