using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using UAAdmin;
using UAAdmin.Infrastructure;
using UAAdmin.Service.Service.CRM;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("dbConn");
builder.Services.AddDbContext<UrbanAutoMasterContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped<ICRMRepository, CRMRepository>();
builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/");
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews().AddCookieTempDataProvider();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => {
        option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        option.LoginPath = "/Login/Login";
        option.AccessDeniedPath = "/Home/Error404";
    });

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddSession(options =>
{
    //options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//For session factory start
builder.Services.AddHttpContextAccessor();
SessionFactory.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
//For session factory end

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
