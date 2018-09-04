using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Rooler
{
    public enum StretchMode
    {
        NorthSouth,
        EastWest,
        NorthSouthEastWest,
    }

    /// <summary>
    /// Interaction logic for DistanceAdorner.xaml
    /// </summary>
    public partial class DistanceTool : Tool, IScreenService
    {
        private IntPoint previousPoint = new IntPoint();
        private IScreenShot screenshot;

        public event EventHandler DimensionsCloseClicked;

        protected virtual void OnDimensionsCloseClicked(EventArgs e)
        {
            if (DimensionsCloseClicked != null)
            {
                DimensionsCloseClicked(this, e);
            }
        }

        public DistanceTool(StretchMode stretch, IScreenServiceHost host) : base(host)
        {
            StretchMode = stretch;

            screenshot = Host.CurrentScreen;

            InitializeComponent();

            if (StretchMode == StretchMode.EastWest)
            {
                N.Visibility = Visibility.Collapsed;
                S.Visibility = Visibility.Collapsed;
            }
            else if (StretchMode == StretchMode.NorthSouth)
            {
                E.Visibility = Visibility.Collapsed;
                W.Visibility = Visibility.Collapsed;
            }
#if !DEBUG
			this.Cursor = Cursors.None;
#endif

            Dimensions.CloseClicked += delegate
            {
                CloseService();
                OnDimensionsCloseClicked(new EventArgs());
            };

            Loaded += delegate
            {
                Update();
            };
        }

        public StretchMode StretchMode { get; set; }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!IsFrozen)
            {
                Update(false);
            }
        }

        public override void Update()
        {
            Update(true);
        }

        private void Update(bool force)
        {
            IntPoint mousePt = NativeMethods.GetCursorPos();

            if (Keyboard.IsKeyDown(Key.Space))
            {
            }

            if (force || mousePt != previousPoint)
            {
                previousPoint = mousePt;

                IntRect rect = ScreenCoordinates.ExpandPoint(mousePt, screenshot);
                if (!rect.IsEmpty)
                {
                    UpdateBounds(rect, mousePt);
                }
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            CloseService();
            Freeze();
        }

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            CloseService();
            Freeze();
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
            Background = Brushes.Transparent;
            Cursor = Cursors.Arrow;
            Dimensions.CanClose = true;
        }

        protected void UpdateBounds(IntRect screenBounds, IntPoint point)
        {
            Rect bounds = NativeMethods.ScreenToClient(this, screenBounds);
            Point screenPoint = NativeMethods.ScreenToClient(this, point);

            Bounds.Width = bounds.Width;
            Bounds.Height = bounds.Height;
            Bounds.Margin = new Thickness(bounds.Left, bounds.Top, 0, 0);

            CenterY.Height = new GridLength(Math.Max(screenPoint.Y - bounds.Y, 0));
            CenterX.Width = new GridLength(Math.Max(screenPoint.X - bounds.X, 0));

            if (StretchMode == StretchMode.EastWest)
            {
                Dimensions.Text = string.Format(@"{0}", screenBounds.Width);
            }
            else if (StretchMode == StretchMode.NorthSouth)
            {
                Dimensions.Text = string.Format(@"{0}", screenBounds.Height);
            }
            else
            {
                Dimensions.Text = string.Format(@"{0} x {1}", screenBounds.Width, screenBounds.Height);
            }
        }

        //protected override void OnKeyUp(KeyEventArgs e) {
        //    base.OnKeyUp(e);

        //    if (e.Key == Key.D) {
        //        VirtualizedScreenShot vs = this.screenshot as VirtualizedScreenShot;
        //        if (vs != null) {
        //            Point mousePt = NativeMethods.GetCursorPos();
        //            ScreenShot currentTile = vs.GetTile((int)mousePt.X, (int)mousePt.Y);

        //            if (currentTile != null) {
        //                BitmapFrame frame = BitmapFrame.Create(currentTile.Image);
        //                PngBitmapEncoder encoder = new PngBitmapEncoder();
        //                encoder.Frames.Add(frame);

        //                using (FileStream fs = new FileStream(@"C:\tmp\ss.png", FileMode.Create, FileAccess.Write)) {
        //                    encoder.Save(fs);
        //                };
        //            }
        //        }
        //    }
        //}
    }
}