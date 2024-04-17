using DemoApplication.Services;
using DemoApplication.Views;
using Microsoft.Extensions.Logging;
using Refit;
namespace DemoApplication
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
            Routing.RegisterRoute(nameof(ProfileView), typeof(ProfileView));
            Routing.RegisterRoute(nameof(DetailView), typeof(DetailView));
            builder.AppServices();
            var settings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            builder.Services.AddRefitClient<IApiService>(settings)
                .ConfigureHttpClient(j =>
                {
                    j.BaseAddress = new Uri("https://reqres.in");
                });
            return builder.Build();
        }
    }
}
