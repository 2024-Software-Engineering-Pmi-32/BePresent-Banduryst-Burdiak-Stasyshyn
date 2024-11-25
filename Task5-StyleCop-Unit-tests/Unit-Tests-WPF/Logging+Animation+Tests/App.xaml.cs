namespace bepresent_wpf
{
    using Serilog;
    using System.Windows;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console() 
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application started");
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {

            Log.Information("Application exited");
            Log.CloseAndFlush();

            base.OnExit(e);
        }
    }
}
