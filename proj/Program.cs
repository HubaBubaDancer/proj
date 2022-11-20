using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using proj.Data;
using proj.Data.Modules;
using proj.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IdentityDbContext<User>>(opt =>
    opt.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=pass;Database=AuthServer;Pooling=true;"));
builder.Services.AddDbContext<ApplicationDbContext>(opt => 
    opt.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=pass;Database=Main;Pooling=true;"));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo() { Title = "My Api", Version = "v1"});
});

var app = builder.Build();

app.UseSwagger(opt => opt.SerializeAsV2 = true);
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My v1");
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


