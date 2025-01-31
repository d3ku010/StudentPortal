using Microsoft.EntityFrameworkCore;
using StudentPortal.web.Data;
using StudentPortal.web.Log; // Ensure this contains ILoggingService & LoggingService
using System;
using NLog;
using NLog.Web;

LogManager.Setup().LoadConfigurationFromFile("nlog.config");
var logger = LogManager.GetCurrentClassLogger();
logger.Info(" Application is starting - This should appear in the log file!");

Console.WriteLine($"NLog Configuration Loaded: {(LogManager.Configuration != null ? "Yes" : "No")}");

try
{
    logger.Info("Application Starting");
    Console.WriteLine("Logged: Application Starting");

    var builder = WebApplication.CreateBuilder(args);

    // Configure NLog
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Register services
    builder.Services.AddControllersWithViews();

    // Register LoggingService as ILoggingService
    builder.Services.AddSingleton<ILoggingService, LoggingService>();

    // Register DbContext
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

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();

    logger.Info("Application Running");
    Console.WriteLine("Logged: Application Running");

}
catch (Exception ex)
{
    logger.Error(ex, "Application failed to start");
    Console.WriteLine($"Logged Error: {ex.Message}");
    throw;
}
finally
{
    LogManager.Shutdown();
    Console.WriteLine("NLog Shutdown Called");
}