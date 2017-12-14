using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Backround_Cycler.WPF.Controls
{
    class ClickableLink : Label
    {
        public static readonly RoutedEvent ClickEvent;

        static ClickableLink ()
        {
            ClickEvent = ButtonBase.ClickEvent.AddOwner (typeof (ClickableLink));
        }

        public event RoutedEventHandler Click
        {
            add { AddHandler (ClickEvent, value); }
            remove { RemoveHandler (ClickEvent, value); }
        }

        protected override void OnMouseDown (MouseButtonEventArgs e)
        {
            base.OnMouseDown (e);
            CaptureMouse ();
        }

        protected override void OnMouseUp (MouseButtonEventArgs e)
        {
            base.OnMouseUp (e);
            if (IsMouseCaptured)
            {
                ReleaseMouseCapture ();
                if (IsMouseOver)
                    RaiseEvent (new RoutedEventArgs (ClickEvent, this));
            }
        }
    }
}
