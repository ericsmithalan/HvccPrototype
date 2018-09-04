using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Rooler
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged, IScreenServiceHost
    {
        private IScreenService currentService = null;

        private List<IScreenService> currentServices = new List<IScreenService>();

        private Magnifier magnifier;

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.IDataObject data = System.Windows.Clipboard.GetDataObject();

            string[] formats = data.GetFormats();

#if !DEBUG
			// Makes it a royal pain to debug...
			this.Topmost = true;
			this.ShowInTaskbar = false;
			//this.CaptureButton.Visibility = Visibility.Collapsed;
#endif

            new Dragger(Toolbar);

            ToleranceSlider.Value = ScreenCoordinates.ColorTolerance;

            ToleranceSlider.ValueChanged += delegate
            {
                ScreenCoordinates.ColorTolerance = ToleranceSlider.Value;
            };

            DataContext = this;

            IntRect screenBounds = ScreenShot.FullScreenBounds;
            Top = screenBounds.Top;
            Left = screenBounds.Left;
            Width = screenBounds.Width;
            Height = screenBounds.Height;
        }

        private bool preserveAnnotations;

        public bool PreserveAnnotations
        {
            get { return preserveAnnotations; }
            set
            {
                preserveAnnotations = value;
                OnPropertyChanged("PreserveAnnotations");
            }
        }

        protected override void OnDeactivated(EventArgs e)
        {
            CurrentService = null;

            base.OnDeactivated(e);
        }

        private void StartBounds(object sender, EventArgs e)
        {
            CurrentService = new BoundsTool(this);
        }

        private void StartStretch(object sender, EventArgs e)
        {
            CurrentService = new DistanceTool(StretchMode.NorthSouthEastWest, this);
        }

        private void StartStretchNS(object sender, EventArgs e)
        {
            CurrentService = new DistanceTool(StretchMode.NorthSouth, this);
        }

        private void StartStretchEW(object sender, EventArgs e)
        {
            CurrentService = new DistanceTool(StretchMode.EastWest, this);
        }

        private void StartMagnify(object sender, EventArgs e)
        {
            if (magnifier != null)
            {
                magnifier.CloseService();
                magnifier = null;
            }

            magnifier = new Magnifier(this);
            ContentRoot.Children.Add(magnifier.Visual);

            magnifier.ServiceClosed += delegate
            {
                Magnify.IsChecked = false;
                if (magnifier != null)
                {
                    ContentRoot.Children.Remove(magnifier.Visual);
                }

                magnifier = null;
            };
        }

        private void StopMagnify(object sender, EventArgs e)
        {
            if (magnifier != null)
            {
                magnifier.CloseService();
            }
        }

        private void StartCapture(object sender, EventArgs e)
        {
            CurrentService = new Capture(this);
        }

        public IScreenService CurrentService
        {
            get { return currentService; }
            set
            {
                if (currentService != null)
                {
                    if (!PreserveAnnotations && !currentService.IsFrozen)
                    {
                        currentService.CloseService();
                        Debug.Assert(currentService == null);
                    }
                }

                currentService = value;

                if (currentService != null)
                {
                    currentServices.Add(currentService);
                    ContentRoot.Children.Add(currentService.Visual);
                    currentService.ServiceClosed += ServiceClosed;
                }
            }
        }

        private IScreenShot lastScreenshot;

        public IScreenShot CurrentScreen
        {
            get
            {
                if (currentServices.Count == 0)
                {
                    lastScreenshot = new VirtualizedScreenShot();
                    //this.lastScreenshot = new ScreenShot();
                }
                return lastScreenshot;
            }
        }

        private void ServiceClosed(object sender, EventArgs e)
        {
            IScreenService service = (IScreenService)sender;

            service.ServiceClosed -= ServiceClosed;

            currentServices.Remove(service);
            ContentRoot.Children.Remove(service.Visual);
            //service.Visual.Close();

            if (service == currentService)
            {
                currentService = null;
            }

            foreach (UIElement child in Toggles.Children)
            {
                ToggleButton tb = child as ToggleButton;
                if (tb != null)
                {
                    tb.IsChecked = false;
                }
            }
        }

        private void Close(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            DragMove();
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Escape)
            {
                CloseAllServices();
            }
        }

        private void CloseAllServices()
        {
            List<IScreenService> currentServices = new List<IScreenService>(this.currentServices);
            foreach (IScreenService service in currentServices)
            {
                service.CloseService();
            }

            if (magnifier != null)
            {
                magnifier.CloseService();
            }

            Debug.Assert(ContentRoot.Children.Count == 0);
            Debug.Assert(this.currentServices.Count == 0);
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);

            Preferences.IsExpanded = true;
            ToleranceSlider.Value += e.Delta * .05;

            if (CurrentService != null)
            {
                CurrentService.Update();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            Debug.Assert(GetType().GetProperty(propertyName) != null);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}