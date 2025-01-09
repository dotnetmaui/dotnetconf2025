using Microsoft.Extensions.Logging;

namespace demoFontAwesome
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
                    fonts.AddFont("FontAwesome-Brands-400.otf", "FontAwsomeBrand");
                    fonts.AddFont("FontAwesome-Regular-400.otf", "FontAwsomeRegular");
                    fonts.AddFont("FontAwesome-Solid-400.otf", "FontAwsomeSolid");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
