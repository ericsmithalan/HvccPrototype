using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Ghost.Controls.Buttons
{
    public class Erase : Ghost.Controls.Button, INotifyPropertyChanged
    {
        public Grid WorkspaceParentControl = null;
        public InkCanvas DrawingCanvas = null;
        public Ghost.Toolbar ToolBarControl = null;

        public Erase()
        {
            InitializeButtons();
            Loaded += new RoutedEventHandler(Control_Loaded);
        }

        private void InitializeButtons()
        {
            AllowSelect = false;
            Width = 25;
            Height = 25;
            ToolTip = "Erase All";
            IsEnabled = false;
            Click += new RoutedEventHandler(Erase_Click);
            RenderButtonVisuals("icn_erase");
        }

        private void Control_Loaded(object sender, EventArgs args)
        {
            Style = (Style)FindResource("ButtonStyle");
            ToolBarControl.PropertyChanged += new PropertyChangedEventHandler(ToolBarControl_PropertyChanged);
        }

        private void ToolBarControl_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "WorkSpaceChildElements")
            {
                if (ToolBarControl.WorkSpaceChildElements > 0)
                {
                    IsEnabled = true;
                }
                else
                {
                    IsEnabled = false;
                }
            }
        }

        private void RenderButtonVisuals(String icnName)
        {
            try
            {
                Icon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}.png", icnName));
                HoverIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
                SelectedIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void Erase_Click(object sender, RoutedEventArgs e)
        {
            ToolBarControl.WorkSpaceChildElements = 0;
            UnselectAllButtons();
            DrawingCanvas.Strokes.Clear();
            WorkspaceParentControl.Children.RemoveRange(1, WorkspaceParentControl.Children.Count);
        }

        private void UnselectAllButtons()
        {
            foreach (Ghost.Controls.Button btn in Utilities.FindVisualChildren<Ghost.Controls.Button>(Parent))
            {
                if (btn.AllowSelect)
                {
                    if (btn.IsSelected && btn != this)
                    {
                        btn.IsSelected = false;
                    }
                }
            }
        }
    }
}