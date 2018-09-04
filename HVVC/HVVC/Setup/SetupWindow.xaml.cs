using System;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Setup
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class SetupWindow : Window
    {
        public static Window MainWindow;
        private static StackPanel MainGrid;
        private static FrameworkElement GridContent;
        private FrameworkElement GridContent2;

        public SetupWindow()
        {
            InitializeComponent();

            if (!HVCC.Settings.IsStaticPresentation)
            {
                MainWindow = this;
                MainGrid = grid_main;
                RenderBody(new ULA());
            }
            Closed += new EventHandler(Window1_Closed);
        }

        private void Window1_Closed(object sender, EventArgs args)
        {
            if (GridContent2 != null)
            {
                grid_main.Children.Remove(GridContent2);
            }

            if (GridContent != null)
            {
                MainGrid.Children.Remove(GridContent);
            }
        }

        public static void RenderBody(FrameworkElement fe)
        {
            if (GridContent != null)
            {
                MainGrid.Children.Remove(GridContent);
            }

            MainGrid.Children.Add(fe);
            GridContent = fe;
        }

        public void RenderBody2(FrameworkElement fe)
        {
            if (GridContent2 != null)
            {
                grid_main.Children.Remove(GridContent2);
            }

            grid_main.Children.Add(fe);
            GridContent2 = fe;
        }
    }
}