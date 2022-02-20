using MediaToAscii.Services.Configs;

namespace MediaToAscii.Menus.ImageSettings
{
    internal class ImageHeightMenu : ImageSettingsMenuBase
    {
        public ImageHeightMenu(IImageConfigService imageConfigService) : base(imageConfigService)
        {
            
        }

        public override string Name => "Change height";

        protected override string ValueName => "height";

        protected override void ChangeValue(string value)
        {
            if (int.TryParse(value, out var height))
            {
                _imageConfigService.ChangeHeight(height);
            }
            else
            {
                throw new ArgumentException("Incorrect value");
            }
        }
    }
}
