using DotNet_AWS_Deployment_Demo.Context;
using DotNet_AWS_Deployment_Demo.Extensions;
using DotNet_AWS_Deployment_Demo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IArticleService, ArticleService>();

var assemblyName = typeof(Program).Assembly.GetName().Name;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(c => c.UseNpgsql(connectionString, m => m.MigrationsAssembly(assemblyName)));
var app = builder.Build();

await app.InitDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();