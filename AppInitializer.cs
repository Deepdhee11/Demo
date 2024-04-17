using DemoApplication.Services;
using DemoApplication.ViewModels;
using DemoApplication.Views;

namespace DemoApplication
{
    public static class AppInitializer
    {
        public static MauiAppBuilder AppServices(this MauiAppBuilder builder)
        {
            builder.RegisterViews()
                   .RegisterViewModels()
                   .AppDataServices();
            return builder;
        }

        private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddSingleton<ProfileMenuView>();
            builder.Services.AddSingleton<ProfileView>();
            builder.Services.AddSingleton<DetailView>();
            return builder;
        }
        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<ProfileMenuViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<DetailViewModel>();
            return builder;
        }
        private static MauiAppBuilder AppDataServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IDataService, DataService>();

            return builder;
        }
    }
}
