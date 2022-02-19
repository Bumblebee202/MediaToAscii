using OpenCvSharp;

namespace MediaToAscii.Services.Images
{
    internal interface IImageService
    {
        string ImageToAscii(Mat image);
    }
}
