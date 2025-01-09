using Microsoft.Extensions.Logging;
using OneSignalSDK.DotNet;

namespace demoOneSignal
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            OneSignal.Debug.LogLevel = OneSignalSDK.DotNet.Core.Debug.LogLevel.VERBOSE;
            OneSignal.Initialize("0a10de18-bd70-4c2f-aefe-0f7238c4afe3");

            return builder.Build();
        }
    }
}
