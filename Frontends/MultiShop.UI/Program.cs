using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.UI.Extensions;
using MultiShop.UI.Handlers;
using MultiShop.UI.Services.CatalogServices.CategoryServices;
using MultiShop.UI.Services.Concrete;
using MultiShop.UI.Services.Interfaces;
using MultiShop.UI.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
	opt.LoginPath = "/Login/Index/";
	opt.LogoutPath = "/Login/LogOut/";
	opt.AccessDeniedPath = "/Pages/AccessDenied/";
	opt.Cookie.HttpOnly = true;
	opt.Cookie.SameSite = SameSiteMode.Strict;
	opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
	opt.Cookie.Name = "MultiShopJwt";
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
	AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
	{
		opt.LoginPath = "/Login/Index/";
		opt.ExpireTimeSpan = TimeSpan.FromDays(5);
		opt.Cookie.Name = "MultiShopCookie";
		opt.SlidingExpiration = true;
	});

builder.Services.AddAccessTokenManagement();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddHttpClient<IIdentityService, IdentityService>();

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

builder.Services.AddUIServices(builder.Configuration);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
