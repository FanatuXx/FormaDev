using PFF.Domain;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using PFF.Domain.Services;
using PFF.Domain.Repositories; //Nécessaire pour utiliser l'interface Scalar

string policyName = "CorsicanPoliceDepartment";

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddCors(c => c.AddPolicy(policyName, o =>
{
    o.WithOrigins("https://localhost:7269").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddDbContext<ApplicationDbContext>(o =>
{
    o.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DuneDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
});

builder.Services.AddScoped<IPathologyRepository, PathologyService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors(policyName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

