using Microsoft.EntityFrameworkCore;
using StudentPortal.web.Data;
using StudentPortal.web.Log;
using System;
using System.IO;
using NLog;
using NLog.Web;

class Program
{
    static void Main(string[] args)
    {
        // Load NLog configuration from the correct path
        string nlogConfigPath = Path.Combine(AppContext.BaseDirectory, "NLog.config");
        LogManager.Setup().LoadConfigurationFromFile(nlogConfigPath);

        var logger = LogManager.GetCurrentClassLogger();

        // Verify NLog is loaded correctly
        Console.WriteLine($"NLog Config Loaded: {(LogManager.Configuration != null ? "Yes" : "No")}");
        logger.Info("Application is starting - This should appear in the log file!");

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure logging (remove default providers and use NLog)
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            // Register services
            builder.Services.AddControllersWithViews();

            // Register custom logging service
            builder.Services.AddSingleton<ILoggingService, LoggingService>();

            // Register DbContext with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("StudentPortal")));

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Map routes
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Log that application is running
            logger.Info("Application Running");
            Console.WriteLine("Logged: Application Running");

            app.Run();
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Application failed to start");
            Console.WriteLine($"Logged Error: {ex.Message}");
            throw;
        }
        finally
        {
            // Ensure logs are flushed before shutdown
            LogManager.Shutdown();
            Console.WriteLine("NLog Shutdown Called");
        }
    }
}
