// See https://aka.ms/new-console-template for more information
using MediaToAscii.Services.Images;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IImageService, ImageService>()
    .BuildServiceProvider();