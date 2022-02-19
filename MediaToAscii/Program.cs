// See https://aka.ms/new-console-template for more information
using MediaToAscii.Services.Images;
using MediaToAscii.Services.Videos;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IImageService, ImageService>()
    .AddSingleton<IVideoService, VideoService>()
    .BuildServiceProvider();
