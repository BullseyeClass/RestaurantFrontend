using RestaurantFrontend.Repository.Interface;
using RestaurantFrontend.Repository.JsonHandler;
using RestaurantFrontend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IJsonHelper, JsonHelper>();
builder.Services.AddScoped<IGettingProductsFromDB, GettingProductsFromDB>();
builder.Services.AddScoped<IGettingMostPopularItem, GettingMostPopularItemFromDB>();
builder.Services.AddScoped<IGettingMyWishList, GettingMyWishListFromDB>();
builder.Services.AddScoped<IJsonHelperMWL, JsonHelperMWL>();



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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
