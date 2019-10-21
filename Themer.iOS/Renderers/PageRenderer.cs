using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Themer.Styles;

[assembly: ExportRenderer(typeof(ContentPage), typeof(Themer.iOS.Renderers.PageRenderer))]
namespace Themer.iOS.Renderers
{
    public class PageRenderer : Xamarin.Forms.Platform.iOS.PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            SetAppTheme();
        }

        public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection)
        {
            base.TraitCollectionDidChange(previousTraitCollection);

            if (TraitCollection.UserInterfaceStyle != previousTraitCollection.UserInterfaceStyle)
                SetAppTheme();
        }

        void SetAppTheme()
        {
            if (TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Dark)
            {
                if (App.AppTheme == Theme.Dark)
                    return;

                App.Current.Resources = new DarkTheme();
                App.AppTheme = Theme.Dark;
            }
            else
            {
                if (App.AppTheme != Theme.Dark)
                    return;

                App.Current.Resources = new LightTheme();
                App.AppTheme = Theme.Light;
            }
        }
    }
}
