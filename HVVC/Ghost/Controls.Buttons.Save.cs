using System;
using System.Windows;
using System.Windows.Controls;

namespace Ghost.Controls.Buttons
{
    public class Save : Ghost.Controls.Button
    {
        public Grid WorkspaceParentControl = null;
        public Ghost.Toolbar ToolBarControl = null;
        public InkCanvas DrawingCanvas = null;

        public Save()
        {
            InitializeButtons();
            Loaded += new RoutedEventHandler(Control_Loaded);
        }

        private void InitializeButtons()
        {
            AllowSelect = false;
            Width = 25;
            Height = 25;
            ToolTip = "Save";
            Click += new RoutedEventHandler(Save_Click);
            RenderButtonVisuals("icn_save");
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Controls.Button btn = (Controls.Button)sender;
            bool isDirectorySelected = Imaging.Capture.CaptureControlImageAndSave(DrawingCanvas);

            //turn button off after dialog closes.
            if (isDirectorySelected == true || isDirectorySelected == false)
            {
                btn.IsSelected = false;
            }
        }
    }
}