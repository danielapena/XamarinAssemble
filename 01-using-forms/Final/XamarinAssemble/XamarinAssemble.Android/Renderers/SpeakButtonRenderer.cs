using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinAssemble;
using XamarinAssemble.Droid.Renderers;

[assembly: ExportRenderer(typeof(SpeakButton), typeof(SpeakButtonRenderer))]
namespace XamarinAssemble.Droid.Renderers
{
    public class SpeakButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetCompoundDrawablesWithIntrinsicBounds(0, Resource.Drawable.speakerphone, 0, 0);
            }
        }
    }
}