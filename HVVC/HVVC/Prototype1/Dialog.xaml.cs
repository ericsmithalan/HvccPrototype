using System;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Prototype1
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        private String _pageTitle;
        private String _pageDescription;
        private String _status;
        private bool _isTwoColumn;
        private Grid mainStackPanel;
        private FrameworkElement _statusElement;
        private FrameworkElement _body;
        private FrameworkElement currentContent;
        private static Window wndw;

        public String Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public String PageTitle
        {
            get { return _pageTitle; }
            set { _pageTitle = value; }
        }

        public String PageDescription
        {
            get { return _pageDescription; }
            set { _pageDescription = value; }
        }

        public bool IsTwoColumn
        {
            get { return _isTwoColumn; }
            set { _isTwoColumn = value; }
        }

        public FrameworkElement Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public FrameworkElement StatusElement
        {
            get { return _statusElement; }
            set { _statusElement = value; }
        }

        public static void SetWindowHeight(int height)
        {
            wndw.Height = height;
        }

        public Dialog()
        {
            InitializeComponent();
            mainStackPanel = sp_main;
            wndw = this;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (IsTwoColumn)
            {
                LoadTwoColumnWindow(Status, StatusElement, Body);
            }
            else
            {
                LoadSingleColumnWindow(PageTitle, PageDescription, Body);
            }

            if (Body != null)
            {
            }
        }

        public void LoadSingleColumnWindow(String pageTitle, String pageDescription, FrameworkElement body)
        {
            if (currentContent != null)
            {
                mainStackPanel.Children.Remove(currentContent);
            }

            Layout_SingleColumn cd = new Layout_SingleColumn();
            cd.PageTitle = pageTitle;
            cd.PageDescription = pageDescription;
            cd.Body = body;

            mainStackPanel.Children.Add(cd);
            currentContent = cd;
        }

        public void LoadTwoColumnWindow(String status, FrameworkElement statusElement, FrameworkElement body)
        {
            if (currentContent != null)
            {
                mainStackPanel.Children.Remove(currentContent);
            }

            Layout_TwoColumn cd = new Layout_TwoColumn();
            cd.Status = status;
            cd.StatusElement = statusElement;
            cd.Body = body;

            mainStackPanel.Children.Add(cd);
            currentContent = cd;
        }
    }
}