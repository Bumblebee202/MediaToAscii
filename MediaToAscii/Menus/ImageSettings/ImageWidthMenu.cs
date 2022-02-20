using MediaToAscii.Services.Configs;

namespace MediaToAscii.Menus.ImageSettings
{
    internal class ImageWidthMenu : ImageSettingsMenuBase
    {
        public ImageWidthMenu(IImageConfigService imageConfigService) : base(imageConfigService)
        {
        }

        public override string Name => "Change width";

        protected override string ValueName => "width";

        protected override void ChangeValue(string value)
        {
            if (int.TryParse(value, out var height))
            {
                _imageConfigService.ChangeWidth(height);
            }
            else
            {
                throw new ArgumentException("Incorrect value");
            }
        }
    }
}
