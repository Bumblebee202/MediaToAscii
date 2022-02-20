// See https://aka.ms/new-console-template for more information
using MediaToAscii.Menus;
using MediaToAscii.Services.Images;
using MediaToAscii.Services.Videos;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IImageService, ImageService>()
    .AddSingleton<IVideoService, VideoService>()
    .AddSingleton<ExitMenu>()
    .AddSingleton<ImageMenu>()
    .AddSingleton<VideoMenu>()
    .AddSingleton(provider =>
    {
        var exitMenu = provider.GetRequiredService<ExitMenu>();
        var imageMenu = provider.GetRequiredService<ImageMenu>();
        var videoMenu = provider.GetRequiredService<VideoMenu>();
        var items = new IMenu[] { imageMenu, videoMenu, exitMenu };
        return new MainMenu(items);
    })
    .BuildServiceProvider();

var mainMenu = serviceProvider.GetRequiredService<MainMenu>();
mainMenu.Show();