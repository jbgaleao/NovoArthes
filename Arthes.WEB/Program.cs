using Arthes.DATA.Interfaces;
using Arthes.DATA.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IRepositoryRevista, RepositoryRevista>();
builder.Services.AddTransient<IRepositoryReceita, RepositoryReceita>();
builder.Services.AddTransient<IRepositoryLinhaReceita, RepositoryLinhaReceita>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Revista}/{action=Index}/{id?}");

app.Run();
