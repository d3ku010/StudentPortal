using Microsoft.EntityFrameworkCore;
using StudentPortal.web.Data;
using StudentPortal.web.Log; // Ensure this contains ILoggingService & LoggingService
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    logger.Info("Application Starting");
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

}
catch (Exception ex)
{
    logger.Error(ex, "Application failed to start");
    throw;
}
finally
{
    LogManager.Shutdown();
}