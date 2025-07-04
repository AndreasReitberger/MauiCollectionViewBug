#if WINDOWS
using Microsoft.Maui.Handlers;
#endif
using MauiAppCollectionViewBug.ViewModels;

namespace MauiAppCollectionViewBug
{
    public static class AppHostBuilderExtensions
    {
        /*
         * The view models do not inherit from an interface, so they only need their concrete type provided to the AddSingleton<T> and AddTransient<T> methods.
         */
        public static MauiAppBuilder ConfigureApp(this MauiAppBuilder builder)
        {
            builder
                .RegisterDispatcher()
                .RegisterMainViewModels()
                .RegisterMainViews()
                ;

            ConfigureMappers();
            return builder;
        }

        /// <summary>
        /// Registers the main view models as Singleton.
        /// https://learn.microsoft.com/en-us/dotnet/architecture/maui/dependency-injection
        /// </summary>
        /// <param name="builder"></param>
        /// <returns>MauiAppBuilder</returns>
        public static MauiAppBuilder RegisterMainViewModels(this MauiAppBuilder builder)
        {
            // Main view models
            builder.Services.AddSingleton<MainPageViewModel>();
            return builder;
        }
        public static MauiAppBuilder RegisterMainViews(this MauiAppBuilder builder)
        {
            // Main view models
            builder.Services.AddSingleton<MainPage>();
            return builder;
        }

        public static MauiAppBuilder RegisterDispatcher(this MauiAppBuilder builder)
        {
            // Example: https://github.com/jamesmontemagno/ToolkitMessenger/blob/master/MauiApp2/MauiProgram.cs
            IDispatcher? dispatcher = Dispatcher.GetForCurrentThread();
            if (dispatcher is not null)
                builder.Services.AddSingleton(dispatcher);
            return builder;
        }
        public static void ConfigureMappers()
        {
#if WINDOWS
            ///Ref: https://github.com/dotnet/maui/issues/16047
            SwitchHandler.Mapper.AppendToMapping("CustomLabelSwitch", (handler, control) =>
            {
                handler.PlatformView.OnContent = null; // new Label { Text = "Foo", TextColor = Colors.Red }.ToPlatform(handler.MauiContext);
                handler.PlatformView.OffContent = null;
            });
#endif
        }
    }
}