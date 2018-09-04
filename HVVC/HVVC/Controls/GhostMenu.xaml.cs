using Rooler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for GhostMenu.xaml
    /// </summary>
    public partial class GhostMenu : UserControl, INotifyPropertyChanged, IScreenServiceHost
    {
        private IScreenService currentService = null;
        private List<IScreenService> currentServices = new List<IScreenService>();
        private bool isHorizontal = false;
        private FrameworkElement _targetControl;

        private DistanceTool currentDemensionsTool = null;

        public FrameworkElement TargetControl
        {
            get { return _targetControl; }
            set { _targetControl = value; }
        }

        private Grid _targetServiceGrid;

        public Grid TargetServiceGrid
        {
            get { return _targetServiceGrid; }
            set { _targetServiceGrid = value; }
        }

        private Window _targetWindow;

        public Window TargetWindow
        {
            get { return _targetWindow; }
            set { _targetWindow = value; }
        }

        public GhostMenu()
        {
            InitializeComponent();
            if (Settings.IsGhostApp && HVCC.Settings.IsStaticPresentation == true)
            {
                Visibility = Visibility.Visible;
            }
            else
            {
                Visibility = Visibility.Collapsed;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            TargetServiceGrid.MouseRightButtonDown += new MouseButtonEventHandler(TargetServiceGrid_MouseRightButtonDown);
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            if (TargetWindow != null)
            {
                TargetWindow.Close();
            }
            else
            {
                Application.Current.Windows[1].Close();
            }
        }

        private void sldr_opacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sldr = (Slider)sender;
            if (TargetControl != null)
            {
                TargetControl.Opacity = sldr.Value / 100;
            }
        }

        private void vruler_Click(object sender, RoutedEventArgs e)
        {
            TargetServiceGrid.MouseLeftButtonDown += new MouseButtonEventHandler(_targetServiceGrid_MouseLeftButtonDown);

            isHorizontal = false;

            if (currentDemensionsTool != null)
            {
                TargetServiceGrid.Children.Remove(currentDemensionsTool);
            }

            currentDemensionsTool = new DistanceTool(StretchMode.NorthSouth, this);
            currentDemensionsTool.DimensionsCloseClicked += new EventHandler(currentDemensionsTool_DimensionsCloseClicked);
            CurrentService = currentDemensionsTool;
        }

        private void hruler_Click(object sender, RoutedEventArgs e)
        {
            TargetServiceGrid.MouseLeftButtonDown += new MouseButtonEventHandler(_targetServiceGrid_MouseLeftButtonDown);

            isHorizontal = true;

            if (currentDemensionsTool != null)
            {
                TargetServiceGrid.Children.Remove(currentDemensionsTool);
            }

            currentDemensionsTool = new DistanceTool(StretchMode.EastWest, this);
            currentDemensionsTool.DimensionsCloseClicked += new EventHandler(currentDemensionsTool_DimensionsCloseClicked);
            CurrentService = currentDemensionsTool;
        }

        private void currentDemensionsTool_DimensionsCloseClicked(object sender, EventArgs args)
        {
            DistanceTool tool = (DistanceTool)sender;
            TargetServiceGrid.Children.Remove(tool);
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
                    TargetServiceGrid.Children.Add(currentService.Visual);
                    currentService.ServiceClosed += ServiceClosed;
                }
            }
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

        private void CloseAllServices()
        {
            List<IScreenService> currentServices = new List<IScreenService>(this.currentServices);
            foreach (IScreenService service in currentServices)
            {
                service.CloseService();
            }

            Debug.Assert(TargetServiceGrid.Children.Count == 0);
            Debug.Assert(this.currentServices.Count == 0);
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

        protected void _targetServiceGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (!isHorizontal)
            {
                currentDemensionsTool = new DistanceTool(StretchMode.NorthSouth, this);
                currentDemensionsTool.DimensionsCloseClicked += new EventHandler(currentDemensionsTool_DimensionsCloseClicked);
                CurrentService = currentDemensionsTool;
            }
            else
            {
                currentDemensionsTool = new DistanceTool(StretchMode.EastWest, this);
                currentDemensionsTool.DimensionsCloseClicked += new EventHandler(currentDemensionsTool_DimensionsCloseClicked);
                CurrentService = currentDemensionsTool;
            }
        }

        protected void TargetServiceGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonDown(e);

            TargetServiceGrid.Children.Remove(currentDemensionsTool);
            TargetServiceGrid.MouseLeftButtonDown -= _targetServiceGrid_MouseLeftButtonDown;
        }

        private void ServiceClosed(object sender, EventArgs e)
        {
            IScreenService service = (IScreenService)sender;

            service.ServiceClosed -= ServiceClosed;

            currentServices.Remove(service);

            //service.Visual.Close();

            if (service == currentService)
            {
                currentService = null;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Control ctl = (Control)sender;
            Window wndw = Window.GetWindow(ctl);

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)TargetServiceGrid.ActualWidth, (int)TargetServiceGrid.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bmp.Clear();
            bmp.Render(TargetServiceGrid);

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));

            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
                using (Stream stream = File.Create(filePath))
                {
                    encoder.Save(stream);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Control ctl = (Control)sender;
            Window wndw = Window.GetWindow(ctl);

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)TargetServiceGrid.ActualWidth, (int)TargetServiceGrid.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bmp.Clear();
            bmp.Render(TargetServiceGrid);

            PngBitmapEncoder encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bmp));

            MemoryStream fs = new MemoryStream();

            encoder.Save(fs);

            System.Drawing.Image imgToCopy = System.Drawing.Image.FromStream(fs);

            System.Windows.Forms.Clipboard.SetImage(imgToCopy);

            imgToCopy.Dispose();
            fs.Close();
            fs.Dispose();
        }
    }
}