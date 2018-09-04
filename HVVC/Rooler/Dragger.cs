using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Rooler
{
    public class Dragger
    {
        private FrameworkElement target;
        private TranslateTransform offset = new TranslateTransform();
        private Point lastMousePt;

        public Dragger(FrameworkElement target)
        {
            this.target = target;

            this.target.RenderTransform = offset;

            this.target.MouseLeftButtonDown += HandleMouseDown;
            this.target.MouseLeftButtonUp += HandleMouseUp;
            this.target.MouseMove += HandleMouseMove;
            this.target.LostMouseCapture += HandleLostCapture;
        }

        private void HandleMouseDown(object sender, MouseButtonEventArgs e)
        {
            lastMousePt = e.GetPosition(target);

            if (target.CaptureMouse())
            {
                lastMousePt = e.GetPosition(target);
                e.Handled = true;
            }
        }

        private void HandleMouseUp(object sender, MouseButtonEventArgs e)
        {
            target.ReleaseMouseCapture();
        }

        private void HandleMouseMove(object sender, MouseEventArgs e)
        {
            if (target.IsMouseCaptured)
            {
                Point point = e.GetPosition(target);

                offset.X += point.X - lastMousePt.X;
                offset.Y += point.Y - lastMousePt.Y;
            }
        }

        private void HandleLostCapture(object sender, EventArgs e)
        {
        }
    }
}