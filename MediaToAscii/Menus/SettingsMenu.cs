namespace MediaToAscii.Menus
{
    internal class SettingsMenu : MenuBase
    {

        public SettingsMenu(IEnumerable<IMenu> items) : base(items)
        {
        }

        public override string Name => "Settings";
    }
}
