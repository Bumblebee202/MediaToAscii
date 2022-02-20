﻿using MediaToAscii.Services.Videos;

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

        protected override void DispayItems()
        {
            try
            {
                _cancellationTokenSource = new CancellationTokenSource();
                var token = _cancellationTokenSource.Token;

                Console.Clear();
                Console.CursorVisible = true;

                Console.Write("Enter video path: ");
                var path = Console.ReadLine();
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception("Wrong path. Press any key");
                }
                Console.Clear();

                Task.Run(() => _videoService.VideoToAscii(path, token), token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected override void Exit()
        {
            _cancellationTokenSource?.Cancel();
            base.Exit();
        }

        protected override void Enter() => Exit();
    }
}
