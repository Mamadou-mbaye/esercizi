using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JwtDemo.Models; 
using JwtDemo.Services;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

var accessSecret = builder.Configuration["Jwt:AccessSecret"]!;
var refreshSecret = builder.Configuration["Jwt:RefreshSecret"]!;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(accessSecret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });
    
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddSingleton<TokenService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

var users = new List<User>
{
    new User { Id = 1, Username = "mamadou", Password = "1234" }
};
var refreshTokens = new List<string>();

app.MapPost("/login", (HttpContext context, TokenService tokenService) =>
{
    var body = context.Request.ReadFromJsonAsync<LoginRequest>().Result;

    if (body == null)
        return Results.BadRequest(new { message = "Body non valido" });

    var user = users.Find(u => u.Username == body.Username && u.Password == body.Password);

    if (user == null)
        return Results.Unauthorized();

    var accessToken = tokenService.GenerateAccessToken(user.Id, user.Username);
    var refreshToken = tokenService.GenerateRefreshToken(user.Id, user.Username);

    refreshTokens.Add(refreshToken);

    context.Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
    {
        HttpOnly = true,
        Secure = true,
        SameSite = SameSiteMode.Strict,
        Expires = DateTimeOffset.UtcNow.AddDays(7)
    });

    return Results.Ok(new { accessToken });
});
app.MapGet("/", () => "Hello World!");
app.MapPost("/", (string message) => $"Echo: {message}");

app.MapGet("/protected", (ClaimsPrincipal user) =>
{
    var username = user.FindFirst(ClaimTypes.Name)?.Value;
    return Results.Ok(new { message = $"Ciao {username}, sei autenticato!" });
}).RequireAuthorization();



app.MapPost("/refresh", (HttpContext context, TokenService tokenService) =>
{
    var refreshToken = context.Request.Cookies["refreshToken"];

    if (string.IsNullOrEmpty(refreshToken))
        return Results.Unauthorized();

    if (!refreshTokens.Contains(refreshToken))
        return Results.Forbid();

    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:RefreshSecret"]!);

    try
    {
        var principal = tokenHandler.ValidateToken(refreshToken, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        }, out _);

        var userId = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var username = principal.FindFirst(ClaimTypes.Name)!.Value;

        var newAccessToken = tokenService.GenerateAccessToken(userId, username);

        return Results.Ok(new { accessToken = newAccessToken });
    }
    catch
    {
        return Results.Forbid();
    }
});

app.Run();
record LoginRequest(string Username, string Password);