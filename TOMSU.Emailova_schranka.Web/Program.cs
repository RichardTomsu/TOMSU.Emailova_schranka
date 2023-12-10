using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Application.Implementation;
using TOMSU.Emailova_schranka.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<IMessageAdminService, MessageAdminDFService>();
string connection = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.34");
builder.Services.AddDbContext<EmailDbContext>(optionsBuilder => optionsBuilder.UseMySql(connection,serverVersion));
builder.Services.AddScoped<IMessageAdminService, MessageAdminService>();
builder.Services.AddScoped<IHomeService, HomeService>();

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
	name: "areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
