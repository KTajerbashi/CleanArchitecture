using Application.Library.Interfaces;
using Application.Library.Interfaces.Patterns;
using Application.Library.Service;
using Application.Library.Service.Products;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.DbContexts;

var builder = WebApplication.CreateBuilder(args);
//  Use Model One

// Add services to the container.
builder.Services.AddControllersWithViews();

//  Authorization Services
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy(UserRolesSeed.Admin, policy => policy.RequireRole(UserRolesSeed.Admin));
    option.AddPolicy(UserRolesSeed.Customer, policy => policy.RequireRole(UserRolesSeed.Customer));
    option.AddPolicy(UserRolesSeed.Operator, policy => policy.RequireRole(UserRolesSeed.Operator));
});

//  Authentication Services
builder.Services.AddAuthentication(option =>
{
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.LoginPath = new PathString("/Authentication/Signin");
    option.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
    option.AccessDeniedPath = new PathString("/Authentication/Signin");
});

//  Add services to the container.
//  Database
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
//  User
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IUserLoginServices, UserLoginServices>();
builder.Services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
//  Role
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
//  Category
builder.Services.AddScoped<IGetCategoriesService, GetCategoriesService>();
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();
//  Product
builder.Services.AddScoped<IEditUserService, EditUserService>();

//  Injections
builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IGetSliderService, GetSliderService>();
builder.Services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();
builder.Services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAddRequestPayService, AddRequestPayService>();
builder.Services.AddScoped<IGetRequestPayService, GetRequestPayService>();
builder.Services.AddScoped<IAddNewOrderService, AddNewOrderService>();
builder.Services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
builder.Services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
builder.Services.AddScoped<IGetRequestPayForAdminService, GetRequestPayForAdminService>();


//  Facad Injection
builder.Services.AddScoped<IProductFacad, ProductFacad>();

//  Use Model One
var conectionString = @"Data Source=DESKTOP-9EC7HCL; Initial Catalog=CleanArchLibraryDb; User id=sa; Password=123123; Integrated Security=true; TrustServerCertificate=True;";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DatabaseContext>(option => option.UseSqlServer(conectionString));


var app = builder.Build();
//  DataBaseContext Injection
//  Configure the HTTP request pipeline.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();


app.Run();
