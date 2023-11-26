using Microsoft.Extensions.Logging;
using PamiwMauiApp.Services;
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
                });


#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IBookService, BookService>();
            builder.Services.AddSingleton<IPublisherService, PublisherService>();
            builder.Services.AddSingleton<IAuthorService, AuthorService>();
            builder.Services.AddSingleton<HttpClient>(sp => new HttpClient() { BaseAddress = new Uri("http://localhost:8081/api/") });

            return builder.Build();
        }
    }
}
