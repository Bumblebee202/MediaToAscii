namespace MediaToAscii.Menus
{
    internal class ExitMenu : MenuBase
    {
        public ExitMenu() : base(items: Enumerable.Empty<IMenu>())
        {
            
        }

        public override string Name => "Exit";

        public override void Show() => Environment.Exit(0);
    }
}
