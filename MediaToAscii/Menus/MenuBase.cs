﻿namespace MediaToAscii.Menus
{
    internal abstract class MenuBase : IMenu
    {
        protected bool _exit;
        protected int _currentPosition;
        public abstract string Name { get; }
        protected IEnumerable<IMenu> Items { get; set; }

        protected virtual int Left => 50;
        protected virtual int Top => 10;

        public MenuBase(IEnumerable<IMenu> items)
        {
            _exit = false;
            _currentPosition = 0;
            Items = items ?? Enumerable.Empty<IMenu>();
        }

        public virtual void Show()
        {
            while (!_exit)
            {
                Console.CursorVisible = false;
                DispayItems();

                Move();
            }
        }

        protected virtual void DispayItems()
        {
            for (int index = 0; index < Items.Count(); index++)
            {
                var item = Items.ElementAt(index);

                Console.SetCursorPosition(Left, Top + index);

                if (index == _currentPosition)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }

                Console.Write(item.Name);
                Console.ResetColor();
            }
        }

        protected virtual void Move()
        {
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                _exit = true;
                return;
            }
            else if (key == ConsoleKey.Enter)
            {
                Items.ElementAt(_currentPosition)
                     .Show();

                return;
            }

            _currentPosition += key switch
            {
                ConsoleKey.UpArrow when _currentPosition > 0 => -1,
                ConsoleKey.DownArrow when _currentPosition < Items.Count() - 1 => 1,
                _ => 0,
            };
        }
    }
}
