using System;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class PrototypeWindow : Window
    {
        private Grid MainGrid = new Grid();
        private Prototype2.WindowMaster CurrentContent = null;

        public PrototypeWindow(Prototype2.WindowMaster fe)
        {
            InitializeComponent();
            if (CurrentContent != null)
            {
                MainGrid.Children.Clear();
            }
            CurrentContent = fe;
            MainGrid.Children.Add(CurrentContent);
            Content = MainGrid;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            MainGrid.Children.Clear();
        }
    }
}