using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using railstutorialv2.Models;
using railstutorialv2.Services;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddScoped(_ => new MySqlConnection(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IUserService, UserService>();
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

app.MapPost("/create",
    (User user, IUserService service) =>
    {
        var result = service.Create(user);
        return Results.Ok(result);
    });

app.MapGet("/get",
    (int id, IUserService service) =>
    {
        var user = service.Get(id);
        if (user is null) return Results.NotFound("User not found");
        return Results.Ok(user);
    });

app.MapGet("/{id}",
    (string id, IUserService service) =>
    {
        //var id = (int)context.GetRouteValue("id");
        var userId = Int32.Parse(id);
        var user = service.Get(userId);
        if (user is null) return Results.NotFound("User not found");
        return Results.Ok(user);
    });

app.MapGet("/list",
    (IUserService service) =>
    {
        var users = service.List();

        return Results.Ok(users);
    });

app.MapPut("/update",
    (User newUser, IUserService service) =>
    {
        var updatedUser = service.Update(newUser);
        if (updatedUser is null) Results.NotFound("User not found");
        return Results.Ok(updatedUser);
    });

app.MapDelete("/delete",
    (int id, IUserService service) =>
    {
        var result = service.Delete(id);
        if (!result) Results.BadRequest("Something went worng");
        return Results.Ok(result);
    });

//app.MapGet("/", () => "Hello World!")
//    .WithName("Hello");

//app.MapGet("/hello", () => new { Hello = "World" })
//    .WithName("HelloObject");

//app.MapGet("/users", async (MySqlConnection db) =>
//    await db.QueryAsync<User>("select * from users"))
//    .WithName("GetAllUsers");

//app.MapGet("/users/{userId}", async context =>
//{
//    string paramstr = (string)context.GetRouteValue("userId");
//    await context.Response.WriteAsync("Hello ASP.NET Core World EndPoint!:" + paramstr);
//})
//    .WithName("FetchUser");
app.Run();

