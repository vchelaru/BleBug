using Microsoft.Extensions.Logging;
using Shiny;
using Shiny.BluetoothLE;

namespace BluetoothMauiTest1
{
    public static class MauiProgram
    {
        static IServiceCollection serviceCollection;
        static IServiceProvider serviceProvider;
        public static IBleManager BleManager
        {
            get
            {
                serviceProvider = serviceProvider ?? serviceCollection.BuildServiceProvider();

                var toReturn = serviceProvider.GetService<IBleManager>();
                return toReturn;
            }
        }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseShiny()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddBluetoothLE();

            serviceCollection = builder.Services;
            return builder.Build();
        }
    }
}
