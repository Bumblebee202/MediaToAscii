namespace MediaToAscii.Menus
{
    internal abstract class MenuBase : IMenu
    {
        protected bool _exit;
        protected int _currentPosition;
        public abstract string Name { get; }
        protected IEnumerable<IMenu> Items { get; set; }

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

                Action();
            }

            _exit = false;
        }

        protected virtual void DispayItems()
        {
            for (int index = 0; index < Items.Count(); index++)
            {
                var item = Items.ElementAt(index);

                if (index == _currentPosition)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }

                Console.SetCursorPosition(0, 0 + index);
                Console.Write(item.Name);
                Console.ResetColor();
            }
        }

        protected virtual void Action()
        {
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.Escape:
                    Exit();
                    break;
                case ConsoleKey.Enter:
                    Enter();
                    break;
                default:
                    Move(key);
                    break;
            }
        }

        protected virtual void Exit()
        {
            _exit = true;
            Console.Clear();
            Console.CursorVisible = false;
        }

        protected virtual void Enter()
        {
            if (Items.Any())
            {
                Items.ElementAt(_currentPosition).Show();
                _currentPosition = 0;
            }
        }

        protected virtual void Move(ConsoleKey key)
        {
            _currentPosition += key switch
            {
                ConsoleKey.UpArrow when _currentPosition > 0 => -1,
                ConsoleKey.DownArrow when _currentPosition < Items.Count() - 1 => 1,
                _ => 0,
            };
        }
    }
}
