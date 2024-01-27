using FluentValidation;
using FluentValidation.AspNetCore;
using FoodRecipes.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.Load("FoodRecipes.Shared"));
builder.Services.AddDbContext<FoodRecipeDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("RecipeCnn")));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment()) app.UseWebAssemblyDebugging();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = new PathString("/Images")
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
