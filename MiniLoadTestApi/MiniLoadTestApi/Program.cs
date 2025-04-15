var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Simple health check
app.MapGet("/health", () => Results.Ok("API is healthy"));

// Get users
app.MapGet("/users", () =>
{
    var users = new[]
    {
        new { Id = 1, Name = "Alice" },
        new { Id = 2, Name = "Bob" },
        new { Id = 3, Name = "Charlie" }
    };
    return Results.Ok(users);
});

// Fake login
app.MapPost("/login", (UserLogin login) =>
{
    if (login.Username == "admin" && login.Password == "1234")
        return Results.Ok(new { Token = "fake-jwt-token" });

    return Results.Unauthorized();
});

app.Run();

record UserLogin(string Username, string Password);
