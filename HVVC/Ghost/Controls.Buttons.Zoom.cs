using System;
using System.Windows;
using System.Windows.Controls;

namespace Ghost.Controls.Buttons
{
    public class Zoom : Ghost.Controls.Button
    {
        public Grid WorkspaceParentControl = null;
        public Ghost.Toolbar ToolBarControl = null;

        public Zoom()
        {
            InitializeButtons();
            Loaded += new RoutedEventHandler(Control_Loaded);
        }

        private void InitializeButtons()
        {
            AllowSelect = false;
            Width = 25;
            Height = 25;
            ToolTip = "Zoom tool";
            Click += new RoutedEventHandler(Zoom_Click);
            //this.SelectedChanged += delegate { this.HandleSelectedChange(VerticalRulerButton); };
        }

        private void Control_Loaded(object sender, EventArgs args)
        {
            Style = (Style)FindResource("ButtonStyle");
            RenderButtonIcons();
        }

        private void RenderButtonIcons()
        {
            RenderButtonVisuals("icn_zoom");
        }

        private void RenderButtonVisuals(String icnName)
        {
            Icon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}.png", icnName));
            HoverIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
            SelectedIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
        }

        private void Zoom_Click(object sender, RoutedEventArgs e)
        {
        }

        //private void Btn_Zoom_Click(object sender, RoutedEventArgs e)
        //{
        //    Ghost.Controls.Button btn = (Ghost.Controls.Button)sender;
        //    this.StopAll();

        //    if (!btn.IsSelected)
        //    {
        //        //btn.IsSelected = true;
        //        //this.ToolColumn.Width = new GridLength(330);
        //        //this.magnifier = new Magnifier(this);
        //        //this.ToolGrid.Children.Add(this.magnifier.Visual);
        //    }
        //    else
        //    {
        //        this.StopMagnify();
        //    }
        //}
        //private void StopMagnify()
        //{
        //    //if (this.magnifier != null)
        //    //{
        //    //    //this.ResetAndStopAll();
        //    //    //this.ToolColumn.Width = new GridLength(0);
        //    //    //if (this.magnifier != null)
        //    //    //    this.ToolGrid.Children.Remove(this.magnifier.Visual);
        //    //    //this.magnifier = null;
        //    //}
        //}
    }
}