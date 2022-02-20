using MediaToAscii.Configs;
using OpenCvSharp;
using System.Text;

namespace MediaToAscii.Services.Images
{
    internal class ImageService : IImageService
    {
        ImageConfig _imageConfig;

        public ImageService(ImageConfig config) => _imageConfig = config;

        public string ImageToAscii(Mat image)
        {
            using var grayImage = image.CvtColor(ColorConversionCodes.BGR2GRAY);
            using var resizedImage = grayImage.Resize(new Size(_imageConfig.Width, _imageConfig.Height));

            return ConvertToAscii(resizedImage);
        }

        public string ImageToAscii(string path)
        {
            using var grayImage = new Mat(path, ImreadModes.Grayscale);
            if (grayImage.Empty())
            {
                throw new Exception("Wrong path. Press any key");
            }

            using var resizedImage = grayImage.Resize(new Size(_imageConfig.Width, _imageConfig.Height));

            return ConvertToAscii(resizedImage);
        }


        string ConvertToAscii(Mat image)
        {
            var builder = new StringBuilder();
            for (int x = 0; x < image.Rows; x++)
            {
                for (int y = 0; y < image.Cols; y++)
                {
                    var pixel = image.Get<Vec3b>(x, y);

                    int index = (pixel.Item0 * 10) / byte.MaxValue;
                    builder.Append(_imageConfig.Symbols[index]);
                }

                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }
    }
}
