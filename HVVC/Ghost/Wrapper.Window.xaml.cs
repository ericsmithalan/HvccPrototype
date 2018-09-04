using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ghost.Wrapper
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window : System.Windows.Window, INotifyPropertyChanged
    {
        private CloseButtonStates _closeState;

        public event PropertyChangedEventHandler PropertyChanged;

        public CloseButtonStates CloseButtonState
        {
            get { return _closeState; }
            set
            {
                _closeState = value;
                OnPropertyChanged("CloseButtonState");
            }
        }

        public Window(UserControl ctl)
        {
            try
            {
                InitializeComponent();
                InitWindow();
                Tools.ControlInView = ctl;
                WorkSpace.Children.Add(ctl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Window(FrameworkElement frameworkElement, String directory)
        {
            try
            {
                InitializeComponent();
                InitWindow();
                Tools.ControlInView = frameworkElement;
                WorkSpace.Children.Add(frameworkElement);
                Tools.LoadDirectory(directory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Window(FrameworkElement frameworkElement, List<UserControl> controlsMenu)
        {
            try
            {
                InitializeComponent();
                InitWindow();
                Tools.WorkspaceParentControl = WorkSpaceParent;
                Tools.DrawingCanvas = ContentCanvas;
                Tools.ControlInView = frameworkElement;
                WorkSpace.Children.Add(frameworkElement);
                Tools.UpdateMenuWithControls(controlsMenu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Window(FrameworkElement frameworkElement, Files.ImageCollection images)
        {
            try
            {
                InitializeComponent();
                InitWindow();
                Tools.ControlInView = frameworkElement;
                WorkSpace.Children.Add(frameworkElement);
                Tools.LoadImageList(images);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public Window(FrameworkElement frameworkElement, List<System.Windows.Controls.UserControl> itemsSource)
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        InitWindow();
        //        Tools.ControlInView = frameworkElement;
        //        WorkSpace.Children.Add(frameworkElement);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        public Window(String imageLocation)
        {
            try
            {
                InitializeComponent();
                InitWindow();
                Tools.LoadDirectory(imageLocation);
                Ghost.Imaging.PixelSnappedImage img = new Ghost.Imaging.PixelSnappedImage();
                img.Source = Utilities.GetBitmapSourceFromUrlPath(imageLocation);
                Tools.ControlInView = img;
                WorkSpace.Children.Add(img);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Window(List<UserControl> ctls)
        {
            try
            {
                InitializeComponent();
                InitWindow();
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;
                foreach (UserControl ctl in ctls)
                {
                    sp.Children.Add(ctl);
                }

                Tools.ControlInView = sp;
                WorkSpace.Children.Add(sp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitWindow()
        {
            Loaded += new RoutedEventHandler(Window_Loaded);
            Tools.WorkspaceParentControl = WorkSpaceParent;
            Tools.DrawingCanvas = ContentCanvas;
            Tools.WorkspaceControl = WorkSpace;
            PropertyChanged += new PropertyChangedEventHandler(Window_PropertyChanged);
            Tools.CloseButtonState = CloseButtonState;
        }

        private void Window_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            Tools.CloseButtonState = CloseButtonState;
        }

        private void Window_Loaded(object sender, RoutedEventArgs args)
        {
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            WorkSpace.Children.Clear();
            WorkSpaceParent.Children.Clear();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            WorkSpace.Children.Clear();
            WorkSpaceParent.Children.Clear();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}