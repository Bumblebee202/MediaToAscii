using OpenCvSharp;
using System.Text;

namespace MediaToAscii.Services.Images
{
    internal class ImageService : IImageService
    {
        int _asciiWidth;
        int _asciiHeight;
        string _symbols;

        public ImageService()
        {
            _symbols = "#*@%=+*:-. ";
            _asciiWidth = 100;
            _asciiHeight = 50;
        }

        public string ImageToAscii(Mat image)
        {
            using var grayImage = image.CvtColor(ColorConversionCodes.BGR2GRAY);
            using var resizedImage = grayImage.Resize(new Size(_asciiWidth, _asciiHeight));

            return ConvertToAscii(resizedImage);
        }

        public string ImageToAscii(string path)
        {
            using var grayImage = new Mat(path, ImreadModes.Grayscale);
            if (grayImage.Empty())
            {
                throw new Exception("Wrong path. Press any key");
            }

            using var resizedImage = grayImage.Resize(new Size(_asciiWidth, _asciiHeight));

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
                    builder.Append(_symbols[index]);
                }

                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }
    }
}
