using Application.Services;
using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Persistance.Context;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.InjectRepositories(builder.Configuration);
        //builder.Services.InjectServices();

        builder.Services.AddControllersWithViews();
        builder.Services.InjectRepositories(builder.Configuration);
        builder.Services.InjectServices();



        #region Authentication
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Use 'None' if not using HTTPS
            options.Cookie.SameSite = SameSiteMode.Strict; // Adjust as per your requirements
            options.LoginPath = "/User/Login"; // Redirect to login page if unauthorized
            options.AccessDeniedPath = "/User/Login"; // Redirect to access denied page
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie expiration time
        });
        #endregion


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
            pattern: "{controller=Quiz}/{action=GetQuizes}");

        app.Run();
    }
}

#region Authentication

#endregion
