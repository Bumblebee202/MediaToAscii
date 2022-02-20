// See https://aka.ms/new-console-template for more information
using MediaToAscii.Configs;
using MediaToAscii.Menus;
using MediaToAscii.Menus.ImageSettings;
using MediaToAscii.Services.Configs;
using MediaToAscii.Services.Images;
using MediaToAscii.Services.Videos;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IImageService, ImageService>()
    .AddSingleton<IVideoService, VideoService>()
    .AddSingleton<IImageConfigService, ImageConfigService>()
    .AddSingleton(provider =>
    {
        var service = provider.GetRequiredService<IImageConfigService>();
        return service.LoadImageConfig();
    })
    .AddSingleton<ExitMenu>()
    .AddSingleton<ImageMenu>()
    .AddSingleton<VideoMenu>()
    .AddSingleton(provider =>
    {
        var imageHeightMenu = provider.GetRequiredService<ImageHeightMenu>();
        var imageWidthMenu = provider.GetRequiredService<ImageWidthMenu>();
        var imageSymbolsMenu = provider.GetRequiredService<ImageSymbolsMenu>();

        var items = new IMenu[] { imageHeightMenu, imageWidthMenu, imageSymbolsMenu };

        return new SettingsMenu(items);
    })
    .AddSingleton<ImageHeightMenu>()
    .AddSingleton<ImageWidthMenu>()
    .AddSingleton<ImageSymbolsMenu>()
    .AddSingleton(provider =>
    {
        var imageMenu = provider.GetRequiredService<ImageMenu>();
        var videoMenu = provider.GetRequiredService<VideoMenu>();
        var settingsMenu = provider.GetRequiredService<SettingsMenu>();
        var exitMenu = provider.GetRequiredService<ExitMenu>();

        var items = new IMenu[] { imageMenu, videoMenu, settingsMenu, exitMenu };

        return new MainMenu(items);
    })
    .BuildServiceProvider();

var mainMenu = serviceProvider.GetRequiredService<MainMenu>();
mainMenu.Show();