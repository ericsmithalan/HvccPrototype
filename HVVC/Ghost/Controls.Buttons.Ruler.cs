using Rooler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ghost.Controls.Buttons
{
    public class Rulers : StackPanel, INotifyPropertyChanged, IScreenServiceHost
    {
        public IScreenService currentService = null;
        public List<IScreenService> currentServices = new List<IScreenService>();
        public bool preserveAnnotations;
        public IScreenShot lastScreenshot;

        public event PropertyChangedEventHandler PropertyChanged;

        private VisibleRulers _show;
        public List<DistanceTool> currentDemensionsTools;
        private DistanceTool currentDemensionsTool = null;
        private Ghost.Controls.Button VerticalRulerButton;
        private Ghost.Controls.Button HorizontalRulerButton;
        public Grid WorkspaceParentControl = null;
        public VisibleRulers Show { get { return _show; } set { _show = value; } }
        public Ghost.Toolbar ToolBarControl = null;

        #region Initialize and Load Control

        public Rulers()
        {
            Loaded += new RoutedEventHandler(Control_Loaded);
            Orientation = Orientation.Horizontal;
            InitializeButtons();
            RenderButtonIcons();
        }

        private void Control_Loaded(object sender, RoutedEventArgs args)
        {
            VerticalRulerButton.Style = (Style)FindResource("ButtonStyle");
            HorizontalRulerButton.Style = (Style)FindResource("ButtonStyle");
            InitializeParentControl();
        }

        private void RenderButtonIcons()
        {
            RenderButtonVisuals(VerticalRulerButton, "icn_vert");
            RenderButtonVisuals(HorizontalRulerButton, "icn_horiz");
            Children.Add(HorizontalRulerButton);
            Children.Add(VerticalRulerButton);

            //switch (this.Show)
            //{
            //    case VisibleRulers.X:
            //        this.RenderButtonVisuals(this.HorizontalRulerButton, "icn_horiz");
            //        this.Children.Add(this.HorizontalRulerButton);
            //        break;
            //    case VisibleRulers.Y:
            //        this.RenderButtonVisuals(this.VerticalRulerButton, "icn_vert");
            //        this.Children.Add(this.VerticalRulerButton);
            //        break;
            //    case VisibleRulers.Both:
            //        this.RenderButtonVisuals(this.VerticalRulerButton, "icn_vert");
            //        this.RenderButtonVisuals(this.HorizontalRulerButton, "icn_horiz");
            //        this.Children.Add(this.HorizontalRulerButton);
            //        this.Children.Add(this.VerticalRulerButton);
            //        break;
            //    default:
            //        this.RenderButtonVisuals(this.VerticalRulerButton, "icn_vert");
            //        this.RenderButtonVisuals(this.HorizontalRulerButton, "icn_horiz");
            //        this.Children.Add(this.HorizontalRulerButton);
            //        this.Children.Add(this.VerticalRulerButton);
            //        break;

            //}
        }

        private void RenderButtonVisuals(Ghost.Controls.Button btn, String icnName)
        {
            btn.Icon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}.png", icnName));
            btn.HoverIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
            btn.SelectedIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
        }

        private void InitializeParentControl()
        {
            WorkspaceParentControl.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(WorkspaceParentControl_MouseLeftButtonDown);
            WorkspaceParentControl.PreviewMouseRightButtonDown += new MouseButtonEventHandler(WorkspaceParentControl_MouseRightButtonDown);
            WorkspaceParentControl.MouseEnter += new MouseEventHandler(WorkspaceParentControl_MouseEnter);
            WorkspaceParentControl.MouseLeave += new MouseEventHandler(WorkspaceParentControl_MouseLeave);
        }

        private void InitializeButtons()
        {
            VerticalRulerButton = new Ghost.Controls.Button();
            VerticalRulerButton.AllowSelect = true;
            VerticalRulerButton.Width = 25;
            VerticalRulerButton.Height = 25;
            VerticalRulerButton.Margin = new Thickness(5, 0, 0, 0);
            VerticalRulerButton.ToolTip = "Vertical Ruler";
            VerticalRulerButton.Click += new RoutedEventHandler(ButtonClick);

            HorizontalRulerButton = new Ghost.Controls.Button();
            HorizontalRulerButton.AllowSelect = true;
            HorizontalRulerButton.Width = 25;
            HorizontalRulerButton.Height = 25;
            HorizontalRulerButton.Margin = new Thickness(0, 0, 0, 0);
            HorizontalRulerButton.ToolTip = "Horizontal Ruler";
            HorizontalRulerButton.Click += new RoutedEventHandler(ButtonClick);
        }

        #endregion Initialize and Load Control

        #region Private Methods

        private void UnselectAllButtons(Ghost.Controls.Button selButton)
        {
            foreach (Ghost.Controls.Button btn in Utilities.FindVisualChildren<Ghost.Controls.Button>(Parent))
            {
                if (btn.AllowSelect)
                {
                    if (btn.IsSelected && btn != selButton)
                    {
                        btn.IsSelected = false;
                    }
                }
            }
        }

        private void AddDistanceTool()
        {
            if (HorizontalRulerButton.IsSelected)
            {
                currentDemensionsTool = new DistanceTool(StretchMode.EastWest, this);
            }
            else if (VerticalRulerButton.IsSelected)
            {
                currentDemensionsTool = new DistanceTool(StretchMode.NorthSouth, this);
            }
            else
            {
                return;
            }

            ToolBarControl.WorkSpaceChildElements += 1;
            CurrentService = currentDemensionsTool;
            if (currentDemensionsTool != null)
            {
                WorkspaceParentControl.Children.Add(currentDemensionsTool);
            }
        }

        private void RemoveDistanceTool()
        {
            if (currentDemensionsTool != null)
            {
                WorkspaceParentControl.Children.Remove(currentDemensionsTool);
                currentDemensionsTool = null;
                ToolBarControl.WorkSpaceChildElements -= 1;
                //this.CurrentService.CloseService();
            }
        }

        #endregion Private Methods

        #region MouseEvents

        private void ButtonClick(object sender, RoutedEventArgs args)
        {
            Ghost.Controls.Button btn = sender as Ghost.Controls.Button;
            UnselectAllButtons(btn);
        }

        protected void WorkspaceParentControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddDistanceTool();
        }

        private void WorkspaceParentControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (currentDemensionsTool == null)
            {
                AddDistanceTool();
            }
        }

        private void WorkspaceParentControl_MouseLeave(object sender, MouseEventArgs e)
        {
            RemoveDistanceTool();
        }

        private void WorkspaceParentControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //routing takes too long. adding this for now to make removing faster.
            RemoveDistanceTool();
            if (HorizontalRulerButton.IsSelected)
            {
                HorizontalRulerButton.IsSelected = false;
            }

            if (VerticalRulerButton.IsSelected)
            {
                VerticalRulerButton.IsSelected = false;
            }
        }

        #endregion MouseEvents

        #region Rooler Service

        private void CloseAllServices()
        {
            List<IScreenService> currentServices = new List<IScreenService>(this.currentServices);
            foreach (IScreenService service in currentServices)
            {
                service.CloseService();
            }
        }

        public bool PreserveAnnotations
        {
            get { return preserveAnnotations; }
            set { preserveAnnotations = value; OnPropertyChanged("PreserveAnnotations"); }
        }

        public IScreenShot CurrentScreen
        {
            get
            {
                if (currentServices.Count == 0)
                {
                    lastScreenshot = new VirtualizedScreenShot();
                }
                return lastScreenshot;
            }
        }

        public void ServiceClosed(object sender, EventArgs e)
        {
            IScreenService service = (IScreenService)sender;
            service.ServiceClosed -= ServiceClosed;
            currentServices.Remove(service);
            if (service == currentService)
            {
                currentService = null;
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
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
                    }
                }
                currentService = value;
                if (currentService != null)
                {
                    currentServices.Add(currentService);
                    //this.WorkspaceParentControl.Children.Add(this.currentService.Visual);
                    currentService.ServiceClosed += ServiceClosed;
                }
            }
        }

        #endregion Rooler Service
    }
}