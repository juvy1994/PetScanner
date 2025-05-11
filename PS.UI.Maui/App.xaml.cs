namespace PS.UI.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new AppShell());
            //SE CAMBIO POR QUE NO SE MOSTRABA EL MENU:
            MainPage = new AppShell();
        }
    }
}
