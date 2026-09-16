/*
*   Activer le JWT token :
*
* 1. Ajouter le package Nugget : Microsoft.AspNetCore.Authentification.JwtBearer
* 2. Ajouter la génération du Token
* 3. Ajout de la sécurité du Token au niveau de l'API (Program.cs & [Authorize])
*
*
*
*/

using AuthSecurity.Infrastructure;
using AuthSecurity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddSingleton<IList<User>>(sp => new List<User>()
{
    new User (1, "Doe", "Jane", "jane.doe@test.be", "Admin"),
    new User (1, "Doe", "John", "john.doe@test.be", "User")
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7048",
            ValidAudience = "https://localhost:7048",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes("MaSuperCléPrivéeDeLaMortQuiTueOuPas!!!"))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
