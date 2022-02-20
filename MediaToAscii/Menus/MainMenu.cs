namespace MediaToAscii.Menus
{
    internal class MainMenu : MenuBase
    {
        public override string Name => "Main menu";

        public MainMenu(IEnumerable<IMenu> items) : base(items)
        {

        }
    }
}
