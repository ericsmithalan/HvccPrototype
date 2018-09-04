using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for UploadComplete.xaml
    /// </summary>
    public partial class UploadComplete : UserControl
    {
        public UploadComplete()
        {
            InitializeComponent();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            tb_user.Text = String.Format("{0}’s", Strings.recordName);
            base.OnRender(drawingContext);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Strings.AccountURL);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start(Strings.AppURL);
        }
    }
}