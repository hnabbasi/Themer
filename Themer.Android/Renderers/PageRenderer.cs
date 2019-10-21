using System;
using Android.Content;
using Android.Content.Res;
using Themer.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(ContentPage), typeof(Themer.Droid.Renderers.PageRenderer))]
namespace Themer.Droid.Renderers
{
    public class PageRenderer : Xamarin.Forms.Platform.Android.PageRenderer
    {
        public PageRenderer(Context context) : base(context) {}

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            SetAppTheme();
        }

        void SetAppTheme()
        {
            if (Resources.Configuration.UiMode.HasFlag(UiMode.NightYes))
            {
                SetTheme(Themer.Theme.Dark);
            }
            else
            {
                SetTheme(Themer.Theme.Light);
            }
        }

        void SetTheme(Theme mode)
        {
            if (mode == Themer.Theme.Dark)
            {
                if (App.AppTheme == Themer.Theme.Dark)
                    return;

                App.Current.Resources = new DarkTheme();

                App.AppTheme = Themer.Theme.Dark;
            }
            else
            {
                if (App.AppTheme != Themer.Theme.Dark)
                    return;
                App.Current.Resources = new LightTheme();
                App.AppTheme = Themer.Theme.Light;
            }
        }
    }
}
