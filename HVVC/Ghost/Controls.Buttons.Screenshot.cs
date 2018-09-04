using System;
using System.Windows;
using System.Windows.Controls;

namespace Ghost.Controls.Buttons
{
    public class Screenshot : Ghost.Controls.Button
    {
        public Grid WorkspaceParentControl = null;
        public Ghost.Toolbar ToolBarControl = null;
        public InkCanvas DrawingCanvas = null;

        public Screenshot()
        {
            InitializeButtons();
            Loaded += new RoutedEventHandler(Control_Loaded);
        }

        private void InitializeButtons()
        {
            AllowSelect = false;
            Width = 25;
            Height = 25;
            ToolTip = "Copy screenshot to clipboard";
            Click += new RoutedEventHandler(Screenshot_Click);
            RenderButtonVisuals("icn_camera");
            //this.SelectedChanged += delegate { this.HandleSelectedChange(VerticalRulerButton); };
        }

        private void Control_Loaded(object sender, EventArgs args)
        {
            Style = (Style)FindResource("ButtonStyle");
        }

        private void RenderButtonVisuals(String icnName)
        {
            Icon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}.png", icnName));
            HoverIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
            SelectedIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
        }

        private void Screenshot_Click(object sender, RoutedEventArgs e)
        {
            Imaging.Capture.CaptureControlImageToClipboard(DrawingCanvas);
        }
    }
}