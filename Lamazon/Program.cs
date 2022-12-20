using Lamazon.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.RegisterModule(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
    opt.LoginPath = "/Users/Login";
    opt.SlidingExpiration = true;
    opt.ExpireTimeSpan = TimeSpan.FromHours(1);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
