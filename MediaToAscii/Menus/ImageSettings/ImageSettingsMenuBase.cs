using MediaToAscii.Services.Configs;

namespace MediaToAscii.Menus.ImageSettings
{
    internal abstract class ImageSettingsMenuBase : MenuBase
    {
        protected abstract string ValueName { get; }
        protected IImageConfigService _imageConfigService;

        protected ImageSettingsMenuBase(IImageConfigService imageConfigService) : base(Enumerable.Empty<IMenu>())
        {
            _imageConfigService = imageConfigService;
        }

        public override void Show()
        {
            Console.Clear();
            Console.CursorVisible = true;

            DispayItems();

            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        protected override void DispayItems()
        {
            while (true)
            {
                try
                {
                    Console.ResetColor();
                    Console.Write($"Enter new {ValueName}: ");
                    var value = Console.ReadLine();
                    ChangeValue(value);
                    break;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
            }
        }

        protected abstract void ChangeValue(string value);
    }
}
