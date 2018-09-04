using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Ghost.Controls.Buttons
{
    public class Close : Ghost.Controls.Button, INotifyPropertyChanged
    {
        public Grid WorkspaceParentControl = null;
        public Grid WorkspaceControl = null;
        public Ghost.Toolbar ToolBarControl = null;
        public FrameworkElement ControlInView = null;
        private Ghost.Wrapper.Window GhostWindow = null;
        private Window ParentWindow = null;

        public Close()
        {
            InitializeButtons();
            Loaded += new RoutedEventHandler(Control_Loaded);
        }

        private void InitializeButtons()
        {
            AllowSelect = false;
            Width = 25;
            Height = 25;
            ToolTip = "Close";
        }

        private void Control_Loaded(object sender, EventArgs args)
        {
            RenderButton();
            ToolBarControl.PropertyChanged += new PropertyChangedEventHandler(Close_PropertyChanged);
            Style = (Style)FindResource("ButtonStyle");
        }

        private void Close_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "CloseButtonState")
            {
                RenderButton();
            }
        }

        private void RenderButton()
        {
            switch (ToolBarControl.CloseButtonState)
            {
                case CloseButtonStates.Close:
                    RenderButtonVisuals("icn_close");
                    Click += new RoutedEventHandler(Close_Click);
                    break;

                case CloseButtonStates.Pin:
                    RenderButtonVisuals("icn_pinned");
                    Click += new RoutedEventHandler(Pinned_Click);
                    break;

                case CloseButtonStates.UnPin:
                    Click += new RoutedEventHandler(UnPin_Click);
                    RenderButtonVisuals("icn_unpin");
                    break;

                default:
                    RenderButtonVisuals("icn_close");
                    Click += new RoutedEventHandler(Close_Click);
                    break;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs args)
        {
            Window.GetWindow(this).Close();
        }

        private void UnPin_Click(object sender, RoutedEventArgs args)
        {
            Window.GetWindow(this).Close();
            ToolBarControl.CloseButtonState = CloseButtonStates.Pin;
        }

        private void Pinned_Click(object sender, RoutedEventArgs args)
        {
            if (ControlInView != null)
            {
                WorkspaceControl.Children.Clear();
                ToolBarControl.Visibility = Visibility.Collapsed;

                Window ParentWindow = Window.GetWindow(this);
                ParentWindow.Closed += new EventHandler(ParentWindow_Close);

                if (ToolBarControl.FileMenu.HasItems)
                {
                    if (ToolBarControl.FileMenu.Items[0].GetType().BaseType == typeof(UserControl))
                    {
                        GhostWindow = new Wrapper.Window(ControlInView, (List<UserControl>)ToolBarControl.FileMenu.ItemsSource);
                    }
                    else if (ToolBarControl.FileMenu.Items[0].GetType().BaseType == typeof(System.Object))
                    {
                        GhostWindow = new Ghost.Wrapper.Window(ControlInView, (Files.ImageCollection)ToolBarControl.FileMenu.ItemsSource);
                    }
                }

                GhostWindow.Closed += new EventHandler(GhostWindow_Closed);
                GhostWindow.CloseButtonState = CloseButtonStates.UnPin;
                GhostWindow.Show();
            }
        }

        private void ParentWindow_Close(object sender, EventArgs args)
        {
            GhostWindow.CloseButtonState = CloseButtonStates.Close;
        }

        private void GhostWindow_Closed(object sender, EventArgs args)
        {
            if (ControlInView != null)
            {
                ToolBarControl.Visibility = Visibility.Visible;
                WorkspaceControl.Children.Clear();
                WorkspaceControl.Children.Add(ControlInView);
            }
        }

        private void RenderButtonVisuals(String icnName)
        {
            Icon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}.png", icnName));
            HoverIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
            SelectedIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
        }

        //private void Close_Click(object sender, RoutedEventArgs e){
        //    Window.GetWindow(this).Close();
        //}

        //private void Btn_Pin_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.ControlInView != null)
        //    {
        //        this.StopAll();
        //        this.Visibility = Visibility.Collapsed;
        //        this.WorkspaceControl.Children.Clear();
        //        this.ClearAllToolsFromWorkSpace();
        //        Window mainWindow = Window.GetWindow(this);
        //        mainWindow.Closed += new EventHandler(MainWindow_Closed);

        //        if (this.isControlsInMenu)
        //            ghostWindow = new Ghost.Wrapper.Window(this.ControlInView, (List<UserControl>)this.Btn_Open_Menu.ItemsSource);
        //        else
        //            ghostWindow = new Ghost.Wrapper.Window(this.ControlInView, (Files.ImageCollection)this.Btn_Open_Menu.ItemsSource);

        //        ghostWindow.IsWindowPinnend = true;
        //        ghostWindow.Closed += new EventHandler(GhostWindow_Closed);

        //        ghostWindow.Show();
        //    }

        //}
        //private void MainWindow_Closed(object sender, EventArgs args)
        //{
        //    ghostWindow.IsWindowPinnend = false;
        //    ghostWindow.WindowLaunchedGhostFromClosed();
        //}
        //private void GhostWindow_Closed(object sender, EventArgs args)
        //{
        //    if (this.ControlInView != null)
        //    {
        //        this.ClearAllToolsFromWorkSpace();
        //        this.WorkspaceControl.Children.Clear();
        //        this.Visibility = Visibility.Visible;
        //        this.WorkspaceControl.Children.Add(this.ControlInView);

        //    }
        //}
    }
}