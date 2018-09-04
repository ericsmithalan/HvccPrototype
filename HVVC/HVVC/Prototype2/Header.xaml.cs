using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderDialogContent(new Options());
                Window wndw = App.OpenDialog();
                wndw.Title = "Options";
                wndw.ShowDialog();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderDialogContent(new RemoveAccount());
                Window wndw = App.OpenDialog();
                wndw.Title = "Remove User";
                wndw.ShowDialog();
            }
        }

        private void Bitmap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Window.GetWindow(this).Close();
            }
            else
            {
                //if (Settings.IsGhostApp)
                //  Application.Current.Windows[1].Close();
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Process.Start(Strings.AccountURL);
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderDialogContent(new Updates());
                Window wndw = App.OpenDialog();
                wndw.Title = "Updates";
                wndw.ShowDialog();
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderDialogContent(new About());
                Window wndw = App.OpenDialog();
                wndw.Title = "About";
                wndw.ShowDialog();
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderDialogContent(new AddGadget());
                Window wndw = App.OpenDialog();
                wndw.Title = "Add Weight Gadget";
                wndw.ShowDialog();
            }
        }
    }
}