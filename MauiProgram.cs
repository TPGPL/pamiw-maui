using Microsoft.Extensions.Logging;
using PamiwMauiApp.Services;
using PamiwMauiApp.ViewModels;
using PamiwMauiApp.Views;

namespace PamiwMauiApp
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
                })
                .AddServices()
                .AddViewModels()
                .AddViews();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder AddServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IBookService, BookService>();
            builder.Services.AddSingleton<IPublisherService, PublisherService>();
            builder.Services.AddSingleton<IAuthorService, AuthorService>();

            builder.Services.AddSingleton<HttpClient>(sp => new HttpClient() { BaseAddress = new Uri("http://localhost:8081/api/") });

            return builder;
        }


        private static MauiAppBuilder AddViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<AuthorsViewModel>();
            builder.Services.AddSingleton<PublishersViewModel>();
            builder.Services.AddSingleton<BooksViewModel>();

            builder.Services.AddTransient<AuthorDetailsViewModel>();
            builder.Services.AddTransient<NewAuthorViewModel>();
            builder.Services.AddTransient<PublisherDetailsViewModel>();
            builder.Services.AddTransient<NewPublisherViewModel>();
            builder.Services.AddTransient<BookDetailsViewModel>();
            builder.Services.AddTransient<NewBookViewModel>();

            return builder;
        }

        private static MauiAppBuilder AddViews(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<BooksView>();
            builder.Services.AddSingleton<AuthorsView>();
            builder.Services.AddSingleton<PublishersView>();

            builder.Services.AddTransient<AuthorDetailsView>();
            builder.Services.AddTransient<NewAuthorView>();
            builder.Services.AddTransient<PublisherDetailsView>();
            builder.Services.AddTransient<NewPublisherView>();
            builder.Services.AddTransient<BookDetailsView>();
            builder.Services.AddTransient<NewBookView>();

            return builder;
        }
    }
}
