using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MauiAppTestCollViewLiveCharts2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp(true)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            
        builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient <ChartViewModel>();
            builder.Services.AddTransient <MainPage>();
            builder.Services.AddTransient <NewPage1>();
            return builder.Build();
        }
    }
}