using System;
using System.Diagnostics;
using System.Windows;

namespace Rooler
{
    /// <summary>
    /// Interaction logic for Crash.xaml
    /// </summary>
    public partial class Crash : Window
    {
        public Crash(string text)
        {
            InitializeComponent();

            TB.Text = text;

            Hyperlink.NavigateUri = new Uri(Hyperlink.NavigateUri.OriginalString + "&body=(copy_error_info_here)");

            Hyperlink.Click += delegate
            {
                Process.Start('"' + Hyperlink.NavigateUri.OriginalString + '"');
            };
        }
    }
}