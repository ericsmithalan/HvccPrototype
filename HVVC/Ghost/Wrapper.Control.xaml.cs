using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Ghost.Wrapper
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Control : UserControl
    {
        public Control(UserControl ctl)
        {
            try
            {
                InitializeComponent();
                Tools.WorkspaceControl = WorkSpace;
                Tools.ControlInView = ctl;
                Tools.WorkspaceParentControl = WorkSpaceParent;
                Tools.DrawingCanvas = ContentCanvas;

                WorkSpace.Children.Add(ctl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Control(FrameworkElement frameworkElement)
        {
            try
            {
                InitializeComponent();
                Tools.WorkspaceControl = WorkSpace;
                Tools.WorkspaceParentControl = WorkSpaceParent;
                Tools.DrawingCanvas = ContentCanvas;
                Tools.ControlInView = frameworkElement;
                WorkSpace.Children.Add(frameworkElement);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Control(FrameworkElement frameworkElement, List<UserControl> controlsMenu)
        {
            try
            {
                InitializeComponent();
                Tools.WorkspaceControl = WorkSpace;
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

        public Control(String imageLocation)
        {
            try
            {
                InitializeComponent();
                Tools.WorkspaceControl = WorkSpace;
                Tools.WorkspaceParentControl = WorkSpaceParent;
                Tools.DrawingCanvas = ContentCanvas;

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

        public Control(List<UserControl> ctls)
        {
            try
            {
                InitializeComponent();
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;
                Tools.WorkspaceControl = WorkSpace;
                Tools.WorkspaceParentControl = WorkSpaceParent;
                Tools.DrawingCanvas = ContentCanvas;
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
    }
}