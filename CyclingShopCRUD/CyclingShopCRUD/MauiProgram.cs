using CyclingShopCRUD.Services.ProductService;
using Microsoft.Extensions.Logging;

namespace CyclingShopCRUD
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"ProductDB.d3");
            builder.Services.AddSingleton<IProductRepository, ProductService>(p => ActivatorUtilities.CreateInstance<ProductService>(p, dbPath)); 

            return builder.Build();
        }
    }
}
