using System;
using System.Windows.Controls;

namespace HVCC.Prototype2
{
    public class ControlBase : UserControl
    {
        private bool _isDialog;
        private bool _isMenusVisible;
        private String _windowName;
        private String _description;
        private bool _isDeviceRelatedPage;

        public bool IsDeviceRelatedPage
        {
            get { return _isDeviceRelatedPage; }
            set { _isDeviceRelatedPage = value; }
        }

        public bool IsDialog
        {
            get { return _isDialog; }
            set { _isDialog = value; }
        }

        public bool IsMenusVisible
        {
            get { return _isMenusVisible; }
            set { _isMenusVisible = value; }
        }

        public String WindowName
        {
            get { return _windowName; }
            set { _windowName = value; }
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}