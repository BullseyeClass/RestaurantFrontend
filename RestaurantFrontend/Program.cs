using Microsoft.AspNetCore.Authentication.Cookies;
using RestaurantFrontend.Repository.Interface;
using RestaurantFrontend.Repository.JsonHandler;
using RestaurantFrontend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IJsonHelper, JsonHelper>();
builder.Services.AddScoped<IGettingProductsFromDB, GettingProductsFromDB>();
builder.Services.AddScoped<IGettingMostPopularItem, GettingMostPopularItemFromDB>();
builder.Services.AddScoped<IGettingMyWishList, GettingMyWishListFromDB>();
builder.Services.AddScoped<IJsonHelperMWL, JsonHelperMWL>();
builder.Services.AddScoped<TokenExpirationFilter>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.Strict;
            options.LoginPath = "/Registration";
            //options.AccessDeniedPath = "/Account/AccessDenied"; // Specify the access denied page URL
        });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(45);
});



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

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
