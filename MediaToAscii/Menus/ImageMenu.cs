﻿using MediaToAscii.Services.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaToAscii.Menus
{
    internal class ImageMenu : MenuBase
    {
        IImageService _imageService;

        public ImageMenu(IImageService imageService) : base(items: Enumerable.Empty<IMenu>())
        {
            _imageService = imageService;
        }

        public override string Name => "Image";

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
                var ascii = _imageService.ImageToAscii(path);

                Console.SetCursorPosition(0, 0);
                Console.WriteLine(ascii);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected override void ShowItem() => Exit();
    }
}