using MediaToAscii.Services.Images;
using OpenCvSharp;

namespace MediaToAscii.Services.Videos
{
    internal class VideoService : IVideoService
    {
        int _sleep;
        IImageService _imageService;

        public VideoService(IImageService imageService)
        {
            _sleep = 1000 / 60;
            _imageService = imageService;
        }

        public void VideoToAscii(string path, CancellationToken cancellationToken)
        {
            using var videoCapture = new VideoCapture(path);

            while (videoCapture.IsOpened())
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                Console.SetCursorPosition(0, 0);

                using var image = new Mat();
                videoCapture.Read(image);
                if (image.Empty())
                {
                    break;
                }

                var ascii = _imageService.ImageToAscii(image);
                Console.WriteLine(ascii);
                Thread.Sleep(_sleep);
            }
        }
    }
}
