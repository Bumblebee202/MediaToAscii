using MediaToAscii.Configs;

namespace MediaToAscii.Services.Configs
{
    internal interface IImageConfigService
    {
        void ChangeSymbols(string value);
        void ChangeWidth(int value);
        void ChangeHeight(int value);
        ImageConfig LoadImageConfig();
    }
}
