
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Repositories;
using Arthes.DATA.Validations;
using Arthes.WEB.Models;

using FluentValidation.AspNetCore;

using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddFluentValidation(v =>
    {
        v.RegisterValidatorsFromAssemblyContaining<ValidatorRevista>();        
    });

builder.Services.AddDbContext<ArthesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ArthesConn")));
builder.Services.AddAutoMapper(typeof(NovaReceitaViewModel));
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Receita}/{action=Index}/{id?}"
    );

app.Run();
