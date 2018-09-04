using System.Windows;
using System.Windows.Controls;

namespace HVCC.Prototype2
{
    public class WindowMaster : UserControl
    {
        public static readonly DependencyProperty IsDevicesMenusShownProperty = DependencyProperty.Register("IsDevicesMenusShown", typeof(bool), typeof(WindowMaster), new PropertyMetadata(null));
        public static readonly DependencyProperty IsDialogProperty = DependencyProperty.Register("IsDialog", typeof(bool), typeof(WindowMaster), new PropertyMetadata(null));
        public static readonly DependencyProperty WindowContentControlProperty = DependencyProperty.Register("WindowContentControl", typeof(Prototype2.ControlBase), typeof(WindowMaster), new PropertyMetadata(null));
        public static readonly DependencyProperty WindowHeaderControlProperty = DependencyProperty.Register("WindowHeaderControl", typeof(UserControl), typeof(WindowMaster), new PropertyMetadata(null));

        static WindowMaster()
        {
            WindowMaster.DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowMaster), new FrameworkPropertyMetadata(typeof(WindowMaster)));
        }

        public bool IsDevicesMenusShown
        {
            get { return (bool)GetValue(WindowMaster.IsDevicesMenusShownProperty); }
            set { SetValue(WindowMaster.IsDevicesMenusShownProperty, value); }
        }

        public bool IsDialog
        {
            get { return (bool)GetValue(WindowMaster.IsDialogProperty); }
            set { SetValue(WindowMaster.IsDialogProperty, value); }
        }

        public Prototype2.ControlBase WindowContentControl
        {
            get { return (Prototype2.ControlBase)GetValue(WindowMaster.WindowContentControlProperty); }
            set { SetValue(WindowMaster.WindowContentControlProperty, value); }
        }

        public UserControl WindowHeaderControl
        {
            get { return (UserControl)GetValue(WindowMaster.WindowHeaderControlProperty); }
            set { SetValue(WindowMaster.WindowHeaderControlProperty, value); }
        }
    }
}