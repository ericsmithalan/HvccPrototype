using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HVCC.Prototype1
{
    /// <summary>
    /// Interaction logic for Layout_SingleColumn.xaml
    /// </summary>
    public partial class Layout_SingleColumn : UserControl
    {
        private String _pageTitle;
        private String _pageDescription;
        private FrameworkElement _body;

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

        public FrameworkElement Body
        {
            get { return _body; }
            set { _body = value; }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (!String.IsNullOrEmpty(PageTitle))
            {
                tb_pageTitle.Text = PageTitle;
            }
            else
            {
                tb_pageTitle.Visibility = Visibility.Collapsed;
            }
            if (!String.IsNullOrEmpty(PageDescription))
            {
                tb_pageDescription.Text = PageDescription;
            }
            else
            {
                tb_pageDescription.Visibility = Visibility.Collapsed;
            }

            base.OnRender(drawingContext);
        }

        public override void OnApplyTemplate()
        {
            if (Body != null)
            {
                grid_main.Children.Add(Body);
                Grid.SetColumn(Body, 0);
                Grid.SetRow(Body, 1);
            }
            base.OnApplyTemplate();
        }

        public Layout_SingleColumn()
        {
            InitializeComponent();
        }
    }
}