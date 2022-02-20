using MediaToAscii.Services.Images;

namespace MediaToAscii.Menus
{
    internal class ImageMenu : MenuBase
    {
        IImageService _imageService;

        public ImageMenu(IImageService imageService) : base(items: Enumerable.Empty<IMenu>())
        {
            _imageService = imageService;
        }

        public override string Name => "Show image";

        protected override void DispayItems()
        {
            try
            {
                Console.Clear();
                Console.CursorVisible = true;

                Console.Write("Enter image path: ");
                var path = Console.ReadLine();
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception("Wrong path. Press any key");
                }
                Console.Clear();
                Console.CursorVisible = false;

                var ascii = _imageService.ImageToAscii(path);

                Console.SetCursorPosition(0, 0);
                Console.WriteLine(ascii);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected override void Enter() => Exit();
    }
}
