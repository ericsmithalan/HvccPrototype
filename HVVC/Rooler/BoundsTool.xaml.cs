using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Rooler
{
    /// <summary>
    /// Interaction logic for BoundsFinder.xaml
    /// </summary>
    public partial class BoundsTool : Tool
    {
        private IntPoint mouseDownLoc = new IntPoint();
        private Rect bounds;
        private IntRect screenBounds;
        private IScreenShot screenshot;

        public BoundsTool(IScreenServiceHost host) : base(host)
        {
            screenshot = Host.CurrentScreen;

            InitializeComponent();

            BoundsWidth.Width = new GridLength(0, GridUnitType.Pixel);
            BoundsHeight.Height = new GridLength(0, GridUnitType.Pixel);
            Dimensions.Visibility = Visibility.Collapsed;

            Dimensions.CloseClicked += delegate
            {
                CloseService();
            };
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (CaptureMouse())
            {
                mouseDownLoc = NativeMethods.GetCursorPos();

                Bounds = new IntRect(mouseDownLoc.X, mouseDownLoc.Y, 0, 0);

                Cursor = Cursors.None;

                e.Handled = true;
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            if (IsMouseCaptured)
            {
                ReleaseMouseCapture();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    Freeze();
                    e.Handled = true;
                    break;
            }

            base.OnKeyDown(e);
        }

        protected override void Freeze()
        {
            base.Freeze();

            Cursor = Cursors.Arrow;
            Dimensions.CanClose = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (IsMouseCaptured)
            {
                IntPoint mousePosition = NativeMethods.GetCursorPos();

                IntPoint topLeft = new IntPoint(Math.Min(mousePosition.X, mouseDownLoc.X), Math.Min(mousePosition.Y, mouseDownLoc.Y));
                IntPoint bottomRight = new IntPoint(Math.Max(mousePosition.X, mouseDownLoc.X), Math.Max(mousePosition.Y, mouseDownLoc.Y));

                Bounds = new IntRect(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
            }
        }

        private bool IsGrayed
        {
            get
            {
                return ((SolidColorBrush)Resources["MaskBackground"]).Color.A != 0;
            }
            set
            {
                Color currentColor = ((SolidColorBrush)Resources["MaskBackground"]).Color;
                if (value)
                {
                    ((SolidColorBrush)Resources["MaskBackground"]).Color = Color.FromArgb(0x40, currentColor.R, currentColor.G, currentColor.B);
                }
                else
                {
                    ((SolidColorBrush)Resources["MaskBackground"]).Color = Color.FromArgb(0x00, currentColor.R, currentColor.G, currentColor.B);
                }
            }
        }

        private IntRect Bounds
        {
            get { return screenBounds; }
            set
            {
                screenBounds = value;

                bounds = NativeMethods.ScreenToClient(this, screenBounds);

                BoundsOffsetX.Width = new GridLength(bounds.Left, GridUnitType.Pixel);
                BoundsOffsetY.Height = new GridLength(bounds.Top, GridUnitType.Pixel);

                BoundsWidth.Width = new GridLength(bounds.Width, GridUnitType.Pixel);
                BoundsHeight.Height = new GridLength(bounds.Height, GridUnitType.Pixel);

                Dimensions.Visibility = Visibility.Visible;
                Dimensions.Text = string.Format(@"{0} x {1}", screenBounds.Width, screenBounds.Height);
            }
        }

        private void AnimateBounds(IntRect screenBounds)
        {
            this.screenBounds = screenBounds;
            bounds = NativeMethods.ScreenToClient(this, this.screenBounds);

            TimeSpan duration = TimeSpan.FromSeconds(.2);
            BoundsOffsetX.AnimateTo(bounds.Left, duration);
            BoundsOffsetY.AnimateTo(bounds.Top, duration);

            BoundsWidth.AnimateTo(bounds.Width, duration);
            BoundsHeight.AnimateTo(bounds.Height, duration);

            Dimensions.Visibility = Visibility.Visible;
            Dimensions.Text = string.Format(@"{0} x {1}", this.screenBounds.Width, this.screenBounds.Height);
        }

        protected override void OnLostMouseCapture(MouseEventArgs e)
        {
            base.OnLostMouseCapture(e);

            if (bounds.Width == 0 || bounds.Height == 0)
            {
                CloseService();

                return;
            }

            IsGrayed = false;
            Cursor = Cursors.Arrow;

            IntRect startRect = NativeMethods.ClientToScreen(this, bounds);
            startRect.Width -= 1;
            startRect.Height -= 1;
            IntRect screenBounds = ScreenCoordinates.Collapse(startRect, screenshot);

            if (!screenBounds.IsEmpty)
            {
                AnimateBounds(screenBounds);
            }

            BoundsRect.Visibility = Visibility.Visible;
            Dimensions.CanClose = true;

            //BitmapFrame frame = BitmapFrame.Create(this.screenshot.Image);
            //PngBitmapEncoder encoder = new PngBitmapEncoder();
            //encoder.Frames.Add(frame);

            //using (FileStream fs = new FileStream(@"C:\tmp\ss.png", FileMode.Create, FileAccess.Write)) {
            //    encoder.Save(fs);
            //};
        }
    }
}