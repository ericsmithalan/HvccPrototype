using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Ghost.Controls
{
    public class Button : System.Windows.Controls.Button, INotifyPropertyChanged
    {
        public static readonly DependencyProperty IsDropdownProperty = DependencyProperty.Register("IsDropdown", typeof(bool), typeof(Ghost.Controls.Button), new PropertyMetadata(false));
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(Ghost.Controls.Button), new PropertyMetadata(null));
        public static readonly RoutedEvent SelectedChangedEvent = EventManager.RegisterRoutedEvent("SelectedChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Ghost.Controls.Button));

        private bool _allowSelect;
        private ImageSource _icon;
        private ImageSource _hoverIcon;
        private ImageSource _selectedIcon;

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageSource Icon { get { return _icon; } set { _icon = value; } }
        public ImageSource HoverIcon { get { return _hoverIcon; } set { _hoverIcon = value; } }
        public ImageSource SelectedIcon { get { return _selectedIcon; } set { _selectedIcon = value; } }
        public bool AllowSelect { get { return _allowSelect; } set { _allowSelect = value; } }
        public bool IsDropdown { get { return (bool)GetValue(IsDropdownProperty); } set { SetValue(IsDropdownProperty, value); } }

        public bool IsSelected
        {
            get
            {
                if (!AllowSelect)
                {
                    return false;
                }
                else
                {
                    return (bool)GetValue(IsSelectedProperty);
                }
            }
            set
            {
                if (!AllowSelect)
                {
                    value = false;
                }
                else
                {
                    SetValue(IsSelectedProperty, value);
                }

                OnPropertyChanged("IsSelected");
            }
        }

        #region Constructors

        static Button()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Ghost.Controls.Button), new FrameworkPropertyMetadata(typeof(Ghost.Controls.Button)));
        }

        public Button()
        {
            PropertyChanged += new PropertyChangedEventHandler(Button_PropertyChanged);
            Click += new RoutedEventHandler(Button_Click);
        }

        #endregion Constructors

        private void Button_Click(object sender, RoutedEventArgs args)
        {
            if (AllowSelect)
            {
                if (IsSelected)
                {
                    IsSelected = false;
                }
                else
                {
                    IsSelected = true;
                }
            }
        }

        #region SelectedChanged

        public event RoutedEventHandler SelectedChanged
        {
            add { AddHandler(SelectedChangedEvent, value); }
            remove { RemoveHandler(SelectedChangedEvent, value); }
        }

        private void RaiseSelectedChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(SelectedChangedEvent);
            RaiseEvent(newEventArgs);
        }

        private void Button_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            RaiseSelectedChangedEvent();
        }

        #endregion SelectedChanged

        #region OnPropertyChanged

        protected void OnPropertyChanged(String isSelected)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(isSelected));
            }
        }

        #endregion OnPropertyChanged
    }
}