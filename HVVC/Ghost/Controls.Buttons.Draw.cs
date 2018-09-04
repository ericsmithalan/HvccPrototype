using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Ghost.Controls.Buttons
{
    public class Draw : Ghost.Controls.Button, INotifyPropertyChanged
    {
        public Grid WorkspaceParentControl = null;
        public InkCanvas DrawingCanvas = null;
        public Ghost.Toolbar ToolBarControl = null;

        public Draw()
        {
            InitializeButtons();
            Loaded += new RoutedEventHandler(Control_Loaded);
        }

        private void InitializeButtons()
        {
            AllowSelect = true;
            Width = 25;
            Height = 25;
            ToolTip = "Draw tool";
            SelectedChanged += delegate { HandleSelectedChange(); };
            RenderButtonVisuals("icn_pen");
        }

        private void Control_Loaded(object sender, EventArgs args)
        {
            DrawingCanvas.PreviewMouseRightButtonDown += delegate { IsSelected = false; };
            Style = (Style)FindResource("ButtonStyle");
            DrawingCanvas.StrokeCollected += new InkCanvasStrokeCollectedEventHandler(DrawingCanvas_StrokeCollected);
        }

        private void DrawingCanvas_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs args)
        {
            ToolBarControl.WorkSpaceChildElements += 1;
        }

        private void RenderButtonVisuals(String icnName)
        {
            Icon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}.png", icnName));
            HoverIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
            SelectedIcon = Utilities.GetBitmapSourceFromGhostApplicationPath(String.Format("{0}_hvr.png", icnName));
        }

        private void HandleSelectedChange()
        {
            if (IsSelected)
            {
                DrawingCanvas.EditingMode = InkCanvasEditingMode.Ink;
                UnselectAllButtons();
            }
            else
            {
                DrawingCanvas.EditingMode = InkCanvasEditingMode.None;
            }
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