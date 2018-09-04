using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HVCC.Prototype2
{
    public class EditableTextBlock : TextBox
    {
        public EditableTextBlock()
        {
            Style = (Style)FindResource("WND_Header_Edit");
            Focus();
            SelectAll();
            InvalidateVisual();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if ((e.Key == Key.Return || e.Key == Key.Escape))
            {
                Deactivate();
            }
        }

        protected override void OnGotMouseCapture(MouseEventArgs e)
        {
            base.OnGotMouseCapture(e);
            Activate();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            Deactivate();
        }

        //<Setter Property="FontFamily" Value="Arial" />
        //<Setter Property="FontSize" Value="18" />
        //<Setter Property="BorderBrush" Value="Red" />
        //<Setter Property="BorderThickness" Value="1" />
        //<Setter Property="TextWrapping" Value="Wrap" />
        //<Setter Property="Foreground" Value="#333333" />
        //<Setter Property="HorizontalAlignment" Value="Center" />
        //<Setter Property="TextAlignment" Value="Center" />

        private void Activate()
        {
            BorderBrush = Brushes.Red;
            BorderThickness = new Thickness(1);
        }

        private void Deactivate()
        {
            BorderBrush = Brushes.White;
            BorderThickness = new Thickness(1);
        }
    }
}