using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HVCC.Prototype1
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

        private void Omron_Upload_Click(object sender, RoutedEventArgs e)
        {
            Strings.deviceTitle = "Pedometer HJ-720IT";
            Strings.manufacturer = "Omron";
            Window1.LoadTwoColumnWindow(null, new Controls.RecordPicker2(), null);
        }

        private void LifeScan_Upload_Click(object sender, RoutedEventArgs e)
        {
            Strings.deviceTitle = "One Touch Ultra 2 Blood Glucose Monitor";
            Strings.manufacturer = "Lifescan";

            Window1.LoadTwoColumnWindow(null, new Controls.RecordPicker2(), null);
        }

        private void LifeScan_Multiple_Click(object sender, RoutedEventArgs e)
        {
            Strings.deviceTitle = "One Touch Ultra 2 Blood Glucose Monitor";
            Strings.manufacturer = "Lifescan";

            Window1.LoadTwoColumnWindow(null, null, new Controls.RecordPicker3());
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            Window1.LoadSingleColumnWindow("Connect your device to your computer", "Please allow up to one minute after pluging it in.", new Controls.NothingHappened());
        }

        private void DeviceDir_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Strings.DeviceURL);
        }

        private void Omron_Settings_Click(object sender, RoutedEventArgs e)
        {
            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 500;
            wndw.Width = 400;
            wndw.Body = new Controls.UploadSettings();
            wndw.IsTwoColumn = true;
            wndw.Title = "Device Settings";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            wndw.ShowDialog();
        }

        private void Omron_Info_Click(object sender, RoutedEventArgs e)
        {
            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 500;
            wndw.Width = 420;
            wndw.Body = new Controls.DeviceInfo();
            wndw.IsTwoColumn = true;
            wndw.Title = "Device Info";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            wndw.ShowDialog();
        }

        private void LifeScan_Settings_Click(object sender, RoutedEventArgs e)
        {
            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 500;
            wndw.Width = 420;
            wndw.Body = new Controls.UploadSettings();
            wndw.IsTwoColumn = true;
            wndw.Title = "Device Settings";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            wndw.ShowDialog();
        }

        private void LifeScan_Info_Click(object sender, RoutedEventArgs e)
        {
            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 500;
            wndw.Width = 420;
            wndw.Body = new Controls.DeviceInfo();
            wndw.IsTwoColumn = true;
            wndw.Title = "Device Info";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            wndw.ShowDialog();
        }

        private void Microlife_Settings_Click(object sender, RoutedEventArgs e)
        {
            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 500;
            wndw.Width = 420;
            wndw.Body = new Controls.UploadSettings();
            wndw.IsTwoColumn = true;
            wndw.Title = "Device Settings";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            wndw.ShowDialog();
        }

        private void Microlife_Info_Click(object sender, RoutedEventArgs e)
        {
            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 500;
            wndw.Width = 420;
            wndw.Body = new Controls.DeviceInfo();
            wndw.IsTwoColumn = true;
            wndw.Title = "Device Info";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            wndw.ShowDialog();
        }

        private void HVAccount_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Strings.AccountURL);
        }

        private void HVSwitch_Click(object sender, RoutedEventArgs e)
        {
            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 370;
            wndw.Width = 400;
            wndw.Body = new Controls.SwitchAccount();
            wndw.IsTwoColumn = false;
            wndw.PageTitle = "Select an option to begin uploading to a different account";
            wndw.Title = "Switch Account";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if ((bool)wndw.ShowDialog())
            {
            }
            else
            {
                ShowRemoveAccountDialog();
            }
        }

        private void HVRemove_Click(object sender, RoutedEventArgs e)
        {
            ShowRemoveAccountDialog();
        }

        private void ShowRemoveAccountDialog()
        {
            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 400;
            wndw.Width = 400;
            wndw.PageTitle = "Do you want to remove the current Connection Center user?";
            wndw.Body = new Controls.RemoveAccount();
            wndw.IsTwoColumn = false;
            wndw.Title = "Remove Account";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if ((bool)wndw.ShowDialog())
            {
            }
            else
            {
                Window1.LoadSingleColumnWindow(null, null, new Controls.RemovingAccount());
            }
        }

        private void Updates_Click(object sender, RoutedEventArgs e)
        {
            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 270;
            wndw.Width = 310;
            wndw.PageTitle = "Searching for updates";
            wndw.PageDescription = "Please wait...";
            wndw.Body = new Controls.Updates();
            wndw.IsTwoColumn = false;
            wndw.Title = "Updates";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            wndw.ShowDialog();
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 550;
            wndw.Width = 400;
            wndw.PageTitle = "Connection Center Options";
            wndw.PageDescription = null;
            wndw.Body = new Controls.Options();
            wndw.IsTwoColumn = false;
            wndw.Title = "Updates";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            wndw.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            HVCC.Prototype1.Dialog wndw = new HVCC.Prototype1.Dialog();
            wndw.Height = 380;
            wndw.Width = 400;
            wndw.PageTitle = null;
            wndw.PageDescription = null;
            wndw.Body = new Controls.About();
            wndw.IsTwoColumn = false;
            wndw.Title = "About";
            wndw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            wndw.ShowDialog();
        }

        private void MenuItem_Click(object sender, MouseEventArgs e)
        {
        }

        private void Data_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Strings.AccountURL);
        }

        private void Troubleshoot_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Strings.SupportURL);
        }
    }
}