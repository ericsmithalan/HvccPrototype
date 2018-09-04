using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Rooler
{
    /// <summary>
    /// Interaction logic for Capture.xaml
    /// </summary>
    public partial class Capture : Tool
    {
        private Point mouseDownLoc = new Point();
        private Rect bounds;
        private ScreenShot screenshot;
        private bool isInDrawMode = true;

        public static RoutedCommand CopyCommand = new RoutedCommand();

        public Capture(IScreenServiceHost host) : base(host)
        {
            InitializeComponent();

            InputBindings.Add(new InputBinding(Capture.CopyCommand, new KeyGesture(Key.C, ModifierKeys.Control)));
            CommandBindings.Add(new CommandBinding(Capture.CopyCommand, HandleCopy));

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
            if (isInDrawMode)
            {
                if (CaptureMouse())
                {
                    mouseDownLoc = e.GetPosition(this);

                    Bounds = new Rect(mouseDownLoc.X, mouseDownLoc.Y, 0, 0);

                    Cursor = Cursors.None;

                    e.Handled = true;
                }
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
                Point topLeft = new Point(Math.Min(e.GetPosition(this).X, mouseDownLoc.X), Math.Min(e.GetPosition(this).Y, mouseDownLoc.Y));
                Point bottomRight = new Point(Math.Max(e.GetPosition(this).X, mouseDownLoc.X), Math.Max(e.GetPosition(this).Y, mouseDownLoc.Y));

                Bounds = new Rect(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
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

        private Rect Bounds
        {
            get { return bounds; }
            set
            {
                bounds = value;

                BoundsOffsetX.Width = new GridLength(bounds.Left, GridUnitType.Pixel);
                BoundsOffsetY.Height = new GridLength(bounds.Top, GridUnitType.Pixel);

                BoundsWidth.Width = new GridLength(bounds.Width, GridUnitType.Pixel);
                BoundsHeight.Height = new GridLength(bounds.Height, GridUnitType.Pixel);

                Dimensions.Visibility = Visibility.Visible;
                Dimensions.Text = string.Format(@"{0} x {1}", bounds.Width, bounds.Height);
            }
        }

        private void AnimateBounds(Rect bounds)
        {
            this.bounds = bounds;

            TimeSpan duration = TimeSpan.FromSeconds(.2);
            BoundsOffsetX.AnimateTo(this.bounds.Left, duration);
            BoundsOffsetY.AnimateTo(this.bounds.Top, duration);

            BoundsWidth.AnimateTo(this.bounds.Width, duration);
            BoundsHeight.AnimateTo(this.bounds.Height, duration);

            Dimensions.Visibility = Visibility.Visible;
            Dimensions.Text = string.Format(@"{0} x {1}", this.bounds.Width, this.bounds.Height);
        }

        protected override void OnLostMouseCapture(MouseEventArgs e)
        {
            base.OnLostMouseCapture(e);

            if (this.bounds.Width < 3 || this.bounds.Height < 3)
            {
                CloseService();

                return;
            }

            Cursor = Cursors.Arrow;

            IntRect startRect = NativeMethods.ClientToScreen(this, this.bounds);

            screenshot = new ScreenShot(startRect);

            startRect.Width -= 1;
            startRect.Height -= 1;

            IntRect screenBounds = ScreenCoordinates.Collapse(startRect, screenshot);
            Rect bounds = NativeMethods.ScreenToClient(this, screenBounds);

            if (!bounds.IsEmpty)
            {
                AnimateBounds(bounds);
            }

            isInDrawMode = false;
            Dimensions.CanClose = true;
        }

        private void CaptureIt()
        {
            IntRect bounds = NativeMethods.ClientToScreen(this, Bounds);

            ScreenShot screenshot = new ScreenShot(bounds);

            Clipboard.SetImage(screenshot.Image);

            CloseService();
        }

        private void HandleCopy(object sender, ExecutedRoutedEventArgs e)
        {
            CaptureIt();
        }
    }
}