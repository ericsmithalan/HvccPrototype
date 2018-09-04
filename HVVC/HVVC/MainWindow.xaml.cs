using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace HVCC
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public String ScreenShotDirectoryPath = System.IO.Path.Combine("C:\\", "HVCCScreens\\");
        private DispatcherTimer WindowLaunchTimer;
        private DispatcherTimer ScreenShotTimer;
        private HVCC.Prototype2.Pages HVCCPages = new HVCC.Prototype2.Pages();
        private HVCC.Prototype2.ControlBase SelControl;

        public MainWindow()
        {
            InitializeComponent();

            ScreenShotTimer = new DispatcherTimer();
            ScreenShotTimer.Interval = TimeSpan.FromSeconds(.1);
            BindDataToJumpToComboBoxes();
        }

        private void BindDataToJumpToComboBoxes()
        {
            cmb_dialogs.ItemsSource = HVCCPages.Dialogs;
            cmb_windows.ItemsSource = HVCCPages.Windows;
            cmb_setup.ItemsSource = HVCCPages.InfoPaneErrorPages;
        }

        private void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs args)
        {
            Application.Current.Shutdown();
        }

        private void CloseAllWindows()
        {
            if (Application.Current.Windows.Count > 1)
            {
                foreach (Window wndw in Application.Current.Windows)
                {
                    if (wndw.Name != Name)
                    {
                        wndw.Close();
                    }
                }
            }
        }

        private void ShowAllWindows_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.Count > 1)
            {
                if (MessageBox.Show("You need to close all Prototype windows. Do you want to go ahead and do that now?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    CloseAllWindows();
                    CreateScreenShots();
                }
            }
            else
            {
                CreateScreenShots();
            }
        }

        private void HidePreviewContent()
        {
            PreviewAreaPanel.Visibility = Visibility.Hidden;
            //this.PreviewDescriptionPanel.Visibility = Visibility.Collapsed;
        }

        private void ShowPreviewContent()
        {
            PreviewAreaPanel.Visibility = Visibility.Visible;
            //this.PreviewDescriptionPanel.Visibility = Visibility.Visible;
        }

        private delegate void OpenWindowForScreenshot();

        private delegate void TakeScreenshot();

        private void CreateScreenShots()
        {
            try
            {
                WindowsPanel.Visibility = Visibility.Hidden;
                ScenarioPanel.Visibility = Visibility.Hidden;
                ClearPreviewPane();
                HidePreviewContent();

                Settings.IsStaticPresentation = true;
                Settings.IsGhostApp = false;

                App.MasterWindowTemplate = new HVCC.Prototype2.WindowMaster();

                WindowLaunchTimer = new DispatcherTimer();
                WindowLaunchTimer.Interval = TimeSpan.FromSeconds(.1);

                if (!Directory.Exists(ScreenShotDirectoryPath))
                {
                    Directory.CreateDirectory(ScreenShotDirectoryPath);
                }

                int nWindows = 0;
                int nDialogs = 0;
                Prototype2.ControlBase curCtl = null;

                WindowLaunchTimer.Tick += delegate
                {
                    if (nWindows < HVCCPages.Windows.Count)
                    {
                        curCtl = (Prototype2.ControlBase)HVCCPages.Windows[nWindows];
                        App.RenderWindowContent(curCtl);
                        ScreenShotTimer.Start();
                        nWindows++;
                    }
                    else
                    {
                        if (nDialogs < HVCCPages.Dialogs.Count)
                        {
                            curCtl = (Prototype2.ControlBase)HVCCPages.Dialogs[nDialogs];
                            App.RenderWindowContent(curCtl);
                            ScreenShotTimer.Start();
                            nDialogs++;
                        }
                        else
                        {
                            WindowsPanel.Visibility = Visibility.Visible;
                            ScenarioPanel.Visibility = Visibility.Visible;
                            CloseAllWindows();
                            nWindows = 0;
                            nDialogs = 0;
                            Process.Start(ScreenShotDirectoryPath);
                            Ghost.Imaging.Capture.CombineImagesInDirectory(ScreenShotDirectoryPath, "all");
                            WindowLaunchTimer.Stop();
                        }
                    }

                    ScreenShotTimer.Tick += delegate
                    {
                        Ghost.Imaging.Capture.CaptureControlImageAndSave(App.MasterWindowTemplate, ScreenShotDirectoryPath + curCtl.WindowName);
                        ScreenShotTimer.Stop();
                    };
                };

                HVCC.Prototype2.PrototypeWindow wndw = new HVCC.Prototype2.PrototypeWindow(App.MasterWindowTemplate);
                wndw.Closed += new EventHandler(wndw_Closed);
                wndw.WindowStyle = WindowStyle.None;
                wndw.Topmost = true;
                wndw.Show();
                WindowLaunchTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.Source + "\n\n" + ex.StackTrace);
                throw ex;
            }
        }

        private void ClearPreviewPane()
        {
            PreviewPanel.Children.Clear();
            txt_description.Text = "";
            txt_name.Text = "";
        }

        private bool IsNoWindows()
        {
            if (Application.Current.Windows.Count > 1)
            {
                if (MessageBox.Show("You need to close all Prototype windows. Do you want to go ahead and do that now?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    CloseAllWindows();
                    return true;
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LaunchPreviewWindow(Prototype2.ControlBase fe)
        {
            if (IsNoWindows())
            {
                App.BuildDevicesList();
                ClearPreviewPane();
                SelControl = fe;
                ShowPreviewContent();
                App.RenderStaticWindowContent(fe);
                txt_description.Text = fe.Description;
                txt_name.Text = fe.WindowName;

                Ghost.Wrapper.Control ghstWrapper = new Ghost.Wrapper.Control(App.MasterStaticWindowTemplate, HVCCPages.AllPages);
                PreviewPanel.Children.Add(ghstWrapper);
            }
        }

        private void RenderInPreviewWindow(object sender, SelectionChangedEventArgs e)
        {
            ListView cb = (ListView)sender;
            if (cb.SelectedValue != null)
            {
                Prototype2.ControlBase ctl = (Prototype2.ControlBase)cb.SelectedValue;
                LaunchPreviewWindow(ctl);
            }
        }

        private void SetSettingsFromScenarioComboBoxes()
        {
            if ((bool)cb_isAccount.IsChecked)
            {
                Settings.IsAccountAvailable = true;
            }
            else
            {
                Settings.IsAccountAvailable = false;
            }

            if ((bool)cb_isUploadError.IsChecked)
            {
                Settings.IsTriggerErrorOnUpload = true;
            }
            else
            {
                Settings.IsTriggerErrorOnUpload = false;
            }

            if ((bool)cb_isPermission.IsChecked)
            {
                Settings.IsPermision = true;
            }
            else
            {
                Settings.IsPermision = false;
            }

            if ((bool)cb_isAutoDetect.IsChecked)
            {
                Settings.IsAutoDetectOn = true;
            }
            else
            {
                Settings.IsAutoDetectOn = false;
            }

            if ((bool)cb_isUploadCompleteError.IsChecked)
            {
                Settings.IsUploadCompleteError = true;
            }
            else
            {
                Settings.IsUploadCompleteError = false;
            }
            if ((bool)cb_isGhost.IsChecked)
            {
                Settings.IsGhostApp = true;
            }
            else
            {
                Settings.IsGhostApp = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsNoWindows())
            {
                HVCC.Settings.ResetSettings();

                SelControl = App.MasterStaticWindowTemplate.WindowContentControl;

                App.MasterWindowTemplate = new HVCC.Prototype2.WindowMaster();
                App.MasterDialogTemplate = new HVCC.Prototype2.WindowMaster();

                CloseAllWindows();
                ClearPreviewPane();
                HidePreviewContent();
                SetSettingsFromScenarioComboBoxes();
                CheckForDevicesInstalled();
                Settings.IsStaticPresentation = false;

                //App.Devices[3].IsInstalled = true;
                //App.Devices[3].IsHasData = true;

                //App.DevicePluggInTimer.Start();

                if (!(bool)cb_isInstall.IsChecked)
                {
                    HVCC.Setup.SetupWindow sw = new HVCC.Setup.SetupWindow();
                    sw.Closed += new EventHandler(SetupWindow_Closed);
                    sw.Show();
                }
                else
                {
                    App.RenderWindowContent(new HVCC.Prototype2.Upload());
                    Window wndw = App.OpenWindow();
                    wndw.Closed += new EventHandler(wndw_Closed);
                    wndw.Show();
                }
            }
        }

        private void SetupWindow_Closed(object sender, EventArgs args)
        {
            App.RenderWindowContent(new HVCC.Prototype2.Upload());
            Window wndw = App.OpenWindow();
            wndw.Closed += new EventHandler(wndw_Closed);
            wndw.ShowDialog();
        }

        private void cb_isAccount_Checked(object sender, RoutedEventArgs e)
        {
            if (IsNoWindows())
            {
                CheckBox cb = (CheckBox)sender;
                if ((bool)cb.IsChecked)
                {
                    txt_isAccount.Text = "You already set up an account";
                }
                else
                {
                    txt_isAccount.Text = "You don't have a HV account";
                }
            }
        }

        private void cb_isInstall_Checked(object sender, RoutedEventArgs e)
        {
            if (IsNoWindows())
            {
                CheckBox cb = (CheckBox)sender;
                if ((bool)cb.IsChecked)
                {
                    txt_isInstall.Text = "You already installed HVCC";
                }
                else
                {
                    txt_isInstall.Text = "HVCC is not installed";
                }
            }
        }

        private void CheckForDevicesInstallQue()
        {
            if ((bool)cb_isMultiDeviceDetected.IsChecked)
            {
                foreach (Prototype2.Device device in App.Devices)
                {
                    if (device.ID > 1)
                    {
                        device.IsInInstallQue = true;
                    }
                }
            }
            else
            {
                foreach (Prototype2.Device device in App.Devices)
                {
                    if (device.ID > 1)
                    {
                        device.IsInInstallQue = false;
                    }
                }
            }
        }

        private void CheckForDevicesInstalled()
        {
            if ((bool)cb_isDevice.IsChecked)
            {
                foreach (Prototype2.Device device in App.Devices)
                {
                    if (device.ID > 1)
                    {
                        if (device.ID == 2)
                        {
                            device.IsInstalled = true;
                            device.IsInInstallQue = false;
                        }

                        App.Devices.SetSelectDevice(2);
                    }

                    if ((bool)cb_isMultiDeviceDetected.IsChecked)
                    {
                        if (device.ID > 2)
                        {
                            device.IsInInstallQue = true;
                        }
                    }
                    else
                    {
                        if (device.ID > 2)
                        {
                            device.IsInInstallQue = false;
                        }
                    }
                }
            }
            else
            {
                foreach (Prototype2.Device device in App.Devices)
                {
                    if (device.ID > 1)
                    {
                        device.IsInstalled = false;
                        App.Devices.SetSelectDevice(1);
                    }
                    if ((bool)cb_isMultiDeviceDetected.IsChecked)
                    {
                        if (device.ID > 1)
                        {
                            device.IsInInstallQue = true;
                        }
                    }
                    else
                    {
                        if (device.ID > 1)
                        {
                            device.IsInInstallQue = false;
                        }
                    }
                }
            }
        }

        private void cb_isDevice_Checked(object sender, RoutedEventArgs e)
        {
            if (IsNoWindows())
            {
                CheckBox cb = (CheckBox)sender;
                if ((bool)cb.IsChecked)
                {
                    txt_isDevice.Text = "You already installed a device";
                }
                else
                {
                    txt_isDevice.Text = "No devices have been installed";
                }
            }
        }

        private void cb_isUploadError_Checked(object sender, RoutedEventArgs e)
        {
            if (IsNoWindows())
            {
                CheckBox cb = (CheckBox)sender;
                if ((bool)cb.IsChecked)
                {
                    txt_isUploadError.Text = "You will see an error during upload";
                }
                else
                {
                    txt_isUploadError.Text = "Upload error is turned off";
                }
            }
        }

        private void cb_isUploadCompleteError_Checked(object sender, RoutedEventArgs e)
        {
            if (IsNoWindows())
            {
                CheckBox cb = (CheckBox)sender;
                if ((bool)cb.IsChecked)
                {
                    txt_isUploadCompleteError.Text = "You will see an error after upload";
                }
                else
                {
                    txt_isUploadCompleteError.Text = " No post upload errors";
                }
            }
        }

        private void cb_isMultiDeviceDetected_Checked(object sender, RoutedEventArgs e)
        {
            if (IsNoWindows())
            {
                CheckBox cb = (CheckBox)sender;
                if ((bool)cb.IsChecked)
                {
                    txt_isMultiDeviceDetected.Text = "Devices waiting for install";
                }
                else
                {
                    txt_isMultiDeviceDetected.Text = "No devices waiting for install";
                }
            }
        }

        private void cb_isPermission_Click(object sender, RoutedEventArgs e)
        {
            if (IsNoWindows())
            {
                CheckBox cb = (CheckBox)sender;
                if ((bool)cb.IsChecked)
                {
                    txt_isPermission.Text = "Your account has permissions";
                }
                else
                {
                    txt_isPermission.Text = "Your account doesn't have permissions";
                }
            }
        }

        private void cb_isAutoDetect_Click(object sender, RoutedEventArgs e)
        {
            if (IsNoWindows())
            {
                CheckBox cb = (CheckBox)sender;
                if ((bool)cb.IsChecked)
                {
                    txt_isAutoDetect.Text = "Simulate auto detect on \"add new device page\". (2 second delay)";
                }
                else
                {
                    txt_isAutoDetect.Text = "Auto detect simulation is disabled";
                }
            }
        }

        private void cb_isGhost_Click(object sender, RoutedEventArgs e)
        {
            if (IsNoWindows())
            {
                CheckBox cb = (CheckBox)sender;
                if ((bool)cb.IsChecked)
                {
                    txt_isGhost.Text = "Run in Ghost";
                }
                else
                {
                    txt_isGhost.Text = "Don't run in Ghost";
                }
            }
        }

        private void wndw_Closed(object sender, EventArgs args)
        {
            if (SelControl != null)
            {
                Settings.ResetSettings();
                ShowPreviewContent();
                LaunchPreviewWindow((HVCC.Prototype2.ControlBase)cmb_windows.Items[0]);
                SelControl = null;
            }
        }

        private void prototypeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cmb_windows.SelectedIndex = 0;
            LaunchPreviewWindow((HVCC.Prototype2.ControlBase)cmb_setup.Items[0]);
        }
    }
}