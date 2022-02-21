using MediaToAscii.Services.Videos;

namespace MediaToAscii.Menus
{
    internal class VideoMenu : MenuBase
    {
        CancellationTokenSource _cancellationTokenSource;
        IVideoService _videoService;

        public VideoMenu(IVideoService videoService) : base(items: Enumerable.Empty<IMenu>())
        {
            _videoService = videoService;
        }

        public override string Name => "Show video";

        public override void Open()
        {
            try
            {
                _cancellationTokenSource = new CancellationTokenSource();
                var token = _cancellationTokenSource.Token;

                Console.ResetColor();
                Console.Clear();
                Console.CursorVisible = true;

                Console.Write("Enter video path: ");
                var path = Console.ReadLine();
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception("Wrong path. Press any key");
                }
                Console.Clear();

                var task = Task.Run(() => _videoService.VideoToAscii(path, token), token);

                while (!_exit)
                {
                    Action();
                }

                _exit = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Action();
            }
        }

        protected override void Action()
        {
            Console.ReadKey();
            Exit();
        }

        protected override void Exit()
        {
            _cancellationTokenSource?.Cancel();
            base.Exit();
        }

        protected override void Enter() => Exit();
    }
}
