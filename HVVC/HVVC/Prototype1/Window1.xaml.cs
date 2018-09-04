using System;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Prototype1
{
    public partial class Window1 : Window
    {
        private static Grid mainGrid;
        private static FrameworkElement currentContent;
        private static Window wndw;

        public Window1()
        {
            InitializeComponent();
            wndw = this;
            mainGrid = grid_main;
            LoadTwoColumnWindow(null, new Controls.RecordPicker2(), null);
        }

        public static void SetWindowHeight(int height)
        {
            wndw.Height = height;
        }

        public static void LoadSingleColumnWindow(String pageTitle, String pageDescription, FrameworkElement body)
        {
            if (currentContent != null)
            {
                mainGrid.Children.Remove(currentContent);
            }

            Layout_SingleColumn cd = new Layout_SingleColumn();
            cd.PageTitle = pageTitle;
            cd.PageDescription = pageDescription;
            cd.Body = body;

            mainGrid.Children.Add(cd);
            Grid.SetColumn(cd, 0);
            Grid.SetRow(cd, 1);

            currentContent = cd;
        }

        public static void LoadTwoColumnWindow(String status, FrameworkElement statusElement, FrameworkElement body)
        {
            if (currentContent != null)
            {
                mainGrid.Children.Remove(currentContent);
            }

            Layout_TwoColumn cd = new Layout_TwoColumn();
            cd.Status = status;
            cd.StatusElement = statusElement;
            cd.Body = body;

            mainGrid.Children.Add(cd);
            Grid.SetColumn(cd, 0);
            Grid.SetRow(cd, 1);

            currentContent = cd;
        }
    }
}