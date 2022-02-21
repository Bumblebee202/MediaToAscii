namespace MediaToAscii.Menus
{
    internal class ExitMenu : MenuBase
    {
        public ExitMenu() : base(items: Enumerable.Empty<IMenu>())
        {
            
        }

        public override string Name => "Exit";

        public override void Open()
        {
            Console.ResetColor();
            Environment.Exit(0);
        }
    }
}
