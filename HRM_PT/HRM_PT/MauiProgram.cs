using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace HRM_PT
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            string dbPath = FileAccessHelper.GetLocalFilePath("humanresource.db");
            builder.Services.AddSingleton<EmployeeRepository>(s => ActivatorUtilities.CreateInstance<EmployeeRepository>(s, dbPath));
            builder.Services.AddSingleton<LeaveRepository>(s => ActivatorUtilities.CreateInstance<LeaveRepository>(s, dbPath));
            builder.Services.AddSingleton<LoginsRepository>(s => ActivatorUtilities.CreateInstance<LoginsRepository>(s, dbPath));
#if WINDOWS
    builder.ConfigureLifecycleEvents(events =>
    {
    events.AddWindows(wndLifeCycleBuilder =>
    {
    wndLifeCycleBuilder.OnWindowCreated(window =>
    {
    IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
    Microsoft.UI.WindowId win32WindowsId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
    Microsoft.UI.Windowing.AppWindow winuiAppWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(win32WindowsId);
    if (winuiAppWindow.Presenter is Microsoft.UI.Windowing.OverlappedPresenter p)
    {
    p.Maximize();
    //p.IsResizable = false;
    p.IsMaximizable = false;
    //p.IsMinimizable = false;
    }
    });
    });
    });
#endif
            return builder.Build();
        }
    }
}


/*#if DEBUG
        builder.Logging.AddDebug();
#endif*/