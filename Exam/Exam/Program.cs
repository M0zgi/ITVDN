using BLL;
using BLL.Services;
using Exam.Interfeces;
using Exam.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProductServices = Exam.Services.ProductServices;
using UserServices = Exam.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddBusinesslogicLayer();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddScoped<LiqPayServicies>();
//builder.Services.AddScoped<GoogleServices>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
