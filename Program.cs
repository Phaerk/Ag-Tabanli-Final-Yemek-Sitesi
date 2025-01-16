using Microsoft.EntityFrameworkCore;
using Delicious_Food_Recipes.Models;
using Delicious_Food_Recipes.Services.Contract;
using Delicious_Food_Recipes.Services.Implementation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Delicious_Food_Recipes.Services.Contract.Favorites;
using Delicious_Food_Recipes.Services.Implementation.Favorites;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database context configuration
builder.Services.AddDbContext<DbWebapplication01Context>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLString"));
});

// Add classes from our services folder
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();  // Add IRecipeService and its implementation

// Cookie Configuration
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(Options =>
    {
        Options.LoginPath = "/Start/Singin";
        Options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

// Clear Cache (Avoid returning once you log out)
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
            new ResponseCacheAttribute
            {
                NoStore = true,
                Location = ResponseCacheLocation.None,
            }
        );
});

// HTTPClient i�in servis ekleyelim
builder.Services.AddHttpClient(); // HttpClient servisini ekliyoruz

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Start}/{action=Singin}/{id?}");

app.Run();
