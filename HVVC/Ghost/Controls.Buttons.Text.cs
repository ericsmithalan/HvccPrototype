using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ghost.Controls.Buttons
{
    public class Text : Ghost.Controls.Button, INotifyPropertyChanged
    {
        public Grid WorkspaceParentControl = null;
        public Grid WorkspaceControl = null;
        public Ghost.Toolbar ToolBarControl = null;

        public Text()
        {
            InitializeButtons();
            Loaded += new RoutedEventHandler(Control_Loaded);
        }

        private void InitializeButtons()
        {
            AllowSelect = true;
            Width = 25;
            Height = 25;
            ToolTip = "Text";
            IsEnabled = true;
            SelectedChanged += delegate { HandleSelectedChange(); };
            RenderButtonVisuals("icn_font");
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
                    IsEnabled = false;
                }
                else
                {
                    IsEnabled = true;
                }
            }
        }

        private void HandleSelectedChange()
        {
            if (IsSelected)
            {
                UnselectAllButtons();
                ShowTextDialogs();
            }
            else
            {
                HideTextDialogs();
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
            catch (Exception ex) { }
        }

        private void UnselectAllButtons()
        {
            foreach (Ghost.Controls.Button btn in Utilities.FindVisualChildren<Ghost.Controls.Button>(Parent))
            {
                if (btn.IsSelected && btn != this)
                {
                    btn.IsSelected = false;
                }
            }
        }

        private void ShowTextInfoDialog(object sender, MouseButtonEventArgs args)
        {
            if (IsSelected)
            {
                TextBlock tb = (TextBlock)sender;
                MessageBox.Show(String.Format("'{4}'\nFontFamily: {0}\nFontSize: {1}px\nFontWeight: {2}\nColor: {3}", tb.FontFamily.ToString(), tb.FontSize.ToString(), tb.FontWeight.ToString(), tb.Foreground.ToString(), tb.Text.ToString()));
            }
        }

        private void ShowTextDialogs()
        {
            foreach (TextBlock tb in Utilities.FindVisualChildren<TextBlock>(WorkspaceControl))
            {
                tb.MouseLeftButtonDown += new MouseButtonEventHandler(ShowTextInfoDialog);
                tb.Background = Brushes.LightPink;
            }
        }

        private void HideTextDialogs()
        {
            foreach (TextBlock tb in Utilities.FindVisualChildren<TextBlock>(WorkspaceControl))
            {
                tb.MouseLeftButtonDown -= new MouseButtonEventHandler(ShowTextInfoDialog);
                tb.Background = Brushes.Transparent;
            }
        }
    }
}