using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Themer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Handle_ModeChange(object sender, EventArgs e)
        {
            Theme themeRequested = App.AppTheme == Theme.Light ? Theme.Dark : Theme.Light;
            MessagingCenter.Send<Page, Theme>(this, "ModeChanged", themeRequested);
            SetIcon();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetIcon();
        }

        void SetIcon()
        {
            if (App.AppTheme == Theme.Light)
            {
                ModeMenuItem.IconImageSource = "moon.png";
            }
            else
            {

                ModeMenuItem.IconImageSource = "sun.png";
            }
        }
    }
}
