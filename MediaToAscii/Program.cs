﻿// See https://aka.ms/new-console-template for more information
using MediaToAscii.Menus;
using MediaToAscii.Services.Images;
using MediaToAscii.Services.Videos;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IImageService, ImageService>()
    .AddSingleton<IVideoService, VideoService>()
    .AddSingleton<ExitMenu>()
    .AddSingleton(provider =>
    {
        var exitMenu = provider.GetRequiredService<ExitMenu>();
        var items = new[] { exitMenu };
        return new MainMenu(items);
    })
    .BuildServiceProvider();

var mainMenu = serviceProvider.GetRequiredService<MainMenu>();
mainMenu.Show();