using System;
using System.Windows;
using System.Windows.Controls;

namespace Rooler
{
    public class Dimensions : Control
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(Dimensions), new PropertyMetadata(null));
        public static readonly DependencyProperty CanCloseProperty = DependencyProperty.Register("CanClose", typeof(bool), typeof(Dimensions), new PropertyMetadata(false));

        static Dimensions()
        {
            Dimensions.DefaultStyleKeyProperty.OverrideMetadata(typeof(Dimensions), new FrameworkPropertyMetadata(typeof(Dimensions)));
        }

        public event EventHandler CloseClicked;

        public string Text
        {
            get { return (string)GetValue(Dimensions.TextProperty); }
            set { SetValue(Dimensions.TextProperty, value); }
        }

        public bool CanClose
        {
            get { return (bool)GetValue(Dimensions.CanCloseProperty); }
            set { SetValue(Dimensions.CanCloseProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Button closeButton = (Button)GetTemplateChild("CloseButton");
            closeButton.Click += delegate
            {
                if (CloseClicked != null)
                {
                    CloseClicked(this, EventArgs.Empty);
                }
            };
        }
    }
}