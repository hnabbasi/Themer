using Xamarin.Forms;

namespace Themer
{
    public partial class App : Application
    {
        public static Theme AppTheme { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }

    public enum Theme
    {
        Light,
        Dark
    }
}
