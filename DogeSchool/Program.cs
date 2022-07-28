using BuildingManager.Repository.IoC;
using DogeSchool.Repository.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IConnectionFactory, ConnectionFactory>();
builder.Services.AddRepository(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
