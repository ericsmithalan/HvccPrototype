using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for SelectFromList.xaml
    /// </summary>
    public partial class SelectFromList : ControlBase
    {
        public SelectFromList()
        {
            InitializeComponent();
            lb_type.SelectedIndex = 0;

            Loaded += new RoutedEventHandler(Content_Loaded);

            ListBoxItem lbi = (ListBoxItem)lb_type.SelectedItem;
            lbi.Focus();
            lbi.CaptureMouse();
            lbi.CaptureStylus();
            lbi.InvalidateVisual();
            lbi.IsSelected = true;
        }

        private void Content_Loaded(object sender, RoutedEventArgs args)
        {
            if (Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(1);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lv = (ListBox)sender;
            tb_models.Text = "";
            switch (lv.SelectedIndex)
            {
                case 0:
                    RenderGlucose();
                    break;

                case 1:
                    RenderBloodPressure();
                    break;

                case 2:
                    RenderPeakFlow();
                    break;

                case 3:
                    RenderPedometer();
                    break;

                case 4:
                    RenderWeightScale();
                    break;
            }
        }

        private void RenderGlucose()
        {
            sp_brand.IsEnabled = true;
            lb_brand.Items.Clear();

            ListBoxItem lbi1 = new ListBoxItem();
            lbi1.Content = "Home Diagnostics, Inc.";

            lb_brand.Items.Add(lbi1);
            lb_brand.SelectedIndex = 0;
        }

        private void RenderBloodPressure()
        {
            sp_brand.IsEnabled = true;
            lb_brand.Items.Clear();

            ListBoxItem lbi1 = new ListBoxItem();
            lbi1.Content = "A&D Medical";
            ListBoxItem lbi2 = new ListBoxItem();
            lbi2.Content = "HomeMedics";
            ListBoxItem lbi3 = new ListBoxItem();
            lbi3.Content = "MicroLife";
            ListBoxItem lbi4 = new ListBoxItem();
            lbi4.Content = "Omron";
            ListBoxItem lbi5 = new ListBoxItem();
            lbi5.Content = "Walgreens";

            lb_brand.Items.Add(lbi1);
            lb_brand.Items.Add(lbi2);
            lb_brand.Items.Add(lbi3);
            lb_brand.Items.Add(lbi4);
            lb_brand.Items.Add(lbi5);

            lb_brand.SelectedIndex = 0;
        }

        private void RenderPeakFlow()
        {
            sp_brand.IsEnabled = true;
            lb_brand.Items.Clear();

            ListBoxItem lbi1 = new ListBoxItem();
            lbi1.Content = "Microlife";

            lb_brand.Items.Add(lbi1);

            lb_brand.SelectedIndex = 0;
        }

        private void RenderPedometer()
        {
            sp_brand.IsEnabled = true;
            lb_brand.Items.Clear();

            ListBoxItem lbi1 = new ListBoxItem();
            lbi1.Content = "Omron";

            lb_brand.Items.Add(lbi1);

            lb_brand.SelectedIndex = 0;
        }

        private void RenderWeightScale()
        {
            sp_brand.IsEnabled = true;
            lb_brand.Items.Clear();

            ListBoxItem lbi1 = new ListBoxItem();
            lbi1.Content = "A&D Medical";
            ListBoxItem lbi2 = new ListBoxItem();
            lbi2.Content = "Tanita";

            lb_brand.Items.Add(lbi1);
            lb_brand.Items.Add(lbi2);

            lb_brand.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (lb_type.SelectedIndex == 0)
            {
                if (lb_brand.SelectedIndex == 0)
                {
                    tb_models.Text = "TRUEtrack, TRUEread, TRUEbalance, TRUEresult";
                }
            }
            if (lb_type.SelectedIndex == 1)
            {
                if (lb_brand.SelectedIndex == 0)
                {
                    tb_models.Text = "UA-767PC";
                }

                if (lb_brand.SelectedIndex == 1)
                {
                    tb_models.Text = "HoMedics Automatic Arm Blood Pressure Monitor, HoMedics Deluxe Automatic Arm Blood Pressure Monitor, Walgreens Automatic Wrist Blood Pressure Monitor, Walgreens Automatic Arm Blood Pressure Monitor, Walgreens Deluxe Automatic Arm Blood Pressure Monitor, Walgreens Ultra Deluxe Automatic Arm Blood Pressure Monitor";
                }

                if (lb_brand.SelectedIndex == 2)
                {
                    tb_models.Text = "3AC1-PC, 3MC1-PC, 3AX1-4U, 3AC1-AP, 3BG1-4K, 3BUI-4, Life Fitness 3AX1-4U, Premier Value 3AC1-PC, CVS BP Monitor (SKU:344534), CVS BP Wrist Monitor (SKU: 271248)";
                }

                if (lb_brand.SelectedIndex == 3)
                {
                    tb_models.Text = "Elite 7300IT, HEM-790IT, HEM-670ITN";
                }

                if (lb_brand.SelectedIndex == 4)
                {
                    tb_models.Text = "Walgreens Premium Arm Blood Pressure Monitor";
                }
            }
            if (lb_type.SelectedIndex == 2)
            {
                if (lb_brand.SelectedIndex == 0)
                {
                    tb_models.Text = "PF100";
                }
            }
            if (lb_type.SelectedIndex == 3)
            {
                if (lb_brand.SelectedIndex == 0)
                {
                    tb_models.Text = "720ITC";
                }
            }
            if (lb_type.SelectedIndex == 4)
            {
                if (lb_brand.SelectedIndex == 0)
                {
                    tb_models.Text = "UC-321PL";
                }

                if (lb_brand.SelectedIndex == 0)
                {
                    tb_models.Text = "HD-351BT, BC-590BT";
                }
            }
            sp_info.Visibility = Visibility.Visible;
            btn_install.IsEnabled = true;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Process.Start(Strings.DeviceURL);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderWindowContent(new AddDevice());
            }
        }

        private void btn_install_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderWindowContent(new InstallingDevice(1));
            }
        }
    }
}