using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for GiveAccountAccess.xaml
    /// </summary>
    public partial class GiveAccountAccess : UserControl
    {
        public GiveAccountAccess()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Strings.AccountURL);

            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 370;
            wndw.Width = 400;
            wndw.Body = new Controls.Waiting();
            wndw.IsTwoColumn = false;
            wndw.PageTitle = null;
            wndw.PageDescription = null;
            wndw.Title = "Wating...";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            wndw.ShowDialog();

            if (wndw.DialogResult.Value == true)
            {
            }
            else
            {
                Strings.deviceTitle = "Pedometer HJ-720IT";
                Strings.manufacturer = "Omron";
                Prototype1.Window1.LoadTwoColumnWindow(null, new Controls.RecordPicker2(), null);
            }
        }
    }
}