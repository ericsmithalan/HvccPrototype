using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Ghost
{
    /// <summary>
    /// Interaction logic for Toolbar.xaml
    /// </summary>
    public partial class Toolbar : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private FrameworkElement _controlInView;
        private Grid _workspaceParent;
        private Grid _workspace;
        private InkCanvas _drawingCanvas;
        private bool _isWindowPinnable;

        private Files.ImageCollection images = null;

        private delegate void OpenFileDelegate();

        private delegate void LoadImageListDelegate();

        private delegate void LoadDirectoryDelegate();

        private bool isControlsInMenu = false;
        private int _workSpaceChildElements = 0;
        public Ghost.Controls.ButtonMenu FileMenu;

        private CloseButtonStates _closeButtonState;

        public CloseButtonStates CloseButtonState
        {
            get { return _closeButtonState; }
            set
            {
                _closeButtonState = value;
                OnPropertyChanged("CloseButtonState");
            }
        }

        public FrameworkElement ControlInView
        {
            get { return _controlInView; }
            set { _controlInView = value; }
        }

        public Grid WorkspaceControl
        {
            get { return _workspace; }
            set { _workspace = value; }
        }

        public Grid WorkspaceParentControl
        {
            get { return _workspaceParent; }
            set { _workspaceParent = value; }
        }

        public InkCanvas DrawingCanvas
        {
            get { return _drawingCanvas; }
            set { _drawingCanvas = value; }
        }

        public int WorkSpaceChildElements
        {
            get
            {
                return _workSpaceChildElements;
            }
            set
            {
                _workSpaceChildElements = value;
                OnPropertyChanged("WorkSpaceChildElements");
            }
        }

        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Toolbar()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Toolbar_Loaded);
            FileMenu = Btn_Open_Menu;
        }

        private void Toolbar_Loaded(object sender, RoutedEventArgs args)
        {
            InitializeTools();
            PropertyChanged += new PropertyChangedEventHandler(Toolbar_PropertyChanged);
        }

        private void Toolbar_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "CloseButtonState")
            {
                ConfigureButtonsForCloseButtonState();
            }
        }

        private void ConfigureButtonsForCloseButtonState()
        {
            if (CloseButtonState == CloseButtonStates.Pin)
            {
                Sldr_Opacity.Visibility = Visibility.Collapsed;
            }

            if (CloseButtonState == CloseButtonStates.UnPin)
            {
                Sldr_Opacity.Visibility = Visibility.Visible;
            }

            if (CloseButtonState == CloseButtonStates.Close)
            {
                Sldr_Opacity.Visibility = Visibility.Visible;
            }
        }

        private void InitializeTools()
        {
            SetOpenMenu();
            Btn_Rulers.WorkspaceParentControl = WorkspaceParentControl;
            Btn_Rulers.ToolBarControl = this;

            Btn_Save.WorkspaceParentControl = WorkspaceParentControl;
            Btn_Save.DrawingCanvas = DrawingCanvas;
            Btn_Save.ToolBarControl = this;

            Btn_Screenshot.WorkspaceParentControl = WorkspaceParentControl;
            Btn_Screenshot.DrawingCanvas = DrawingCanvas;
            Btn_Screenshot.ToolBarControl = this;

            Btn_EraseDrawing.WorkspaceParentControl = WorkspaceParentControl;
            Btn_EraseDrawing.DrawingCanvas = DrawingCanvas;
            Btn_EraseDrawing.ToolBarControl = this;

            Btn_Draw.WorkspaceParentControl = WorkspaceParentControl;
            Btn_Draw.DrawingCanvas = DrawingCanvas;
            Btn_Draw.ToolBarControl = this;

            Btn_Font.WorkspaceParentControl = WorkspaceParentControl;
            Btn_Font.WorkspaceControl = WorkspaceControl;
            Btn_Font.ToolBarControl = this;

            Btn_Close.WorkspaceParentControl = WorkspaceParentControl;
            Btn_Close.ControlInView = ControlInView;
            Btn_Close.WorkspaceControl = WorkspaceControl;
            Btn_Close.ToolBarControl = this;

            ConfigureButtonsForCloseButtonState();
            //this.Btn_Zoom.WorkspaceParentControl = this.WorkspaceParentControl;

            WorkspaceControl.Unloaded += new RoutedEventHandler(WorkspaceControl_Unloaded);
        }

        private void WorkspaceControl_Unloaded(object sender, RoutedEventArgs args)
        {
        }

        private void SetOpenMenu()
        {
            if (Btn_Open_Menu.Items.Count > 1)
            {
                Btn_Open_Menu.Visibility = Visibility.Visible;
                Btn_Open.IsDropdown = true;
            }
            else
            {
                Btn_Open_Menu.Visibility = Visibility.Collapsed;
                Btn_Open.IsDropdown = false;
            }
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Escape)
            {
                //this.StopAll();
            }
        }

        private void Sldr_Opacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sldr = (Slider)sender;
            if (WorkspaceControl != null)
            {
                WorkspaceControl.Opacity = sldr.Value / 100;
            }
        }

        private void Btn_Open_Click(object sender, RoutedEventArgs e)
        {
            Controls.Button btn = (Controls.Button)sender;
            btn.IsSelected = true;

            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Data Sources (*.jpg, *.gif, *.png)|*.jpg*;*.gif;*.png";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenFileDelegate del1 = delegate ()
                {
                    images = new Ghost.Files.ImageCollection(System.IO.Path.GetDirectoryName(ofd.FileName));
                    Imaging.PixelSnappedImage psi = new Ghost.Imaging.PixelSnappedImage();
                    psi.Source = Utilities.GetBitmapSourceFromUrlPath(String.Format("{1}/{0}", System.IO.Path.GetFileName(ofd.FileName), System.IO.Path.GetDirectoryName(ofd.FileName)));
                    btn.IsSelected = false;
                    WorkspaceControl.Children.Clear();
                    ControlInView = psi;
                    WorkspaceControl.Children.Add(psi);
                    UpdateMenuWithImages(images);
                    SetOpenMenu();
                };
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, del1);
            }
            else
            {
                btn.IsSelected = false;
            }
        }

        public void LoadImageList(Files.ImageCollection images)
        {
            Btn_Open_Menu.ItemsSource = images;
        }

        public void LoadDirectory(String directory)
        {
            LoadDirectoryDelegate del1 = delegate ()
            {
                Files.ImageCollection images = new Ghost.Files.ImageCollection(System.IO.Path.GetDirectoryName(directory));
                Btn_Open_Menu.ItemsSource = images;
            };
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, del1);
        }

        public void UpdateMenuWithControls(List<UserControl> controlsMenu)
        {
            Btn_Open_Menu.ItemTemplate = (DataTemplate)FindResource("ControlItemTemplate");
            Btn_Open_Menu.ItemsSource = controlsMenu;
        }

        public void UpdateMenuWithImages(Files.ImageCollection images)
        {
            Btn_Open_Menu.ItemTemplate = (DataTemplate)FindResource("FileMenuItemTemplate");
            Btn_Open_Menu.ItemsSource = images;
        }

        private void Btn_Open_Menu_Click(object sender, RoutedEventArgs e)
        {
            if (FileMenu.HasItems)
            {
                if (FileMenu.Items[0].GetType().BaseType == typeof(System.Object))
                {
                    MenuItem mi = e.OriginalSource as MenuItem;
                    Imaging.PixelSnappedImage psi = new Ghost.Imaging.PixelSnappedImage();
                    psi.Source = Utilities.GetBitmapSourceFromUrlPath(mi.Header.ToString());
                    ControlInView = psi;
                    WorkspaceControl.Children.Clear();
                    WorkspaceControl.Children.Add(psi);
                }
                else if (FileMenu.Items[0].GetType().BaseType == typeof(UserControl))
                {
                    MenuItem mi = e.OriginalSource as MenuItem;
                    UserControl ctl = mi.Header as UserControl;
                    ControlInView = ctl;
                    WorkspaceControl.Children.Clear();
                    WorkspaceControl.Children.Add(ctl);
                }
            }
        }
    }
}