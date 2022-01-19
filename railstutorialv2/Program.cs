using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using railstutorialv2.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped(_ => new MySqlConnection(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.MapGet("/error", () => Results.Problem("An error occurred.", statusCode: 500))
    .ExcludeFromDescription();

app.MapSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!")
    .WithName("Hello");

app.MapGet("/hello", () => new { Hello = "World" })
    .WithName("HelloObject");

app.MapGet("/users", async (MySqlConnection db) =>
    await db.QueryAsync<User>("select * from users"))
    .WithName("GetAllUsers");
app.Run();

