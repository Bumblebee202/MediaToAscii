using MediaToAscii.Services.Configs;

namespace MediaToAscii.Menus.ImageSettings
{
    internal class ImageSymbolsMenu : ImageSettingsMenuBase
    {
        public ImageSymbolsMenu(IImageConfigService imageConfigService) : base(imageConfigService)
        {
        }

        public override string Name => "Change symbols";

        protected override string ValueName => "symbols";

        protected override void ChangeValue(string value) => _imageConfigService.ChangeSymbols(value);
    }
}
