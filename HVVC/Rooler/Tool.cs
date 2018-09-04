using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Rooler
{
    public class Tool : ContentControl, IScreenService
    {
        public Tool()
        {
        }

        public Tool(IScreenServiceHost host)
        {
            Host = host;
            Focusable = true;

            HorizontalContentAlignment = HorizontalAlignment.Stretch;
            VerticalContentAlignment = VerticalAlignment.Stretch;

            Loaded += delegate
            {
                Focus();
            };
        }

        protected IScreenServiceHost Host { get; set; }

        public FrameworkElement Visual
        {
            get { return this; }
        }

        public event EventHandler ServiceClosed;

        public void CloseService()
        {
            OnClosing();

            if (ServiceClosed != null)
            {
                ServiceClosed(this, EventArgs.Empty);
            }
        }

        public virtual void Update()
        {
        }

        private bool isFrozen = false;

        public bool IsFrozen
        {
            get { return isFrozen; }
            private set { isFrozen = value; }
        }

        protected virtual void Freeze()
        {
            IsFrozen = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    {
                        IntPoint cursorPos = NativeMethods.GetCursorPos();
                        cursorPos.X -= 1;
                        NativeMethods.SetCursorPos(cursorPos);
                    }
                    e.Handled = true;
                    break;

                case Key.Right:
                    {
                        IntPoint cursorPos = NativeMethods.GetCursorPos();
                        cursorPos.X += 1;
                        NativeMethods.SetCursorPos(cursorPos);
                    }
                    e.Handled = true;
                    break;

                case Key.Up:
                    {
                        IntPoint cursorPos = NativeMethods.GetCursorPos();
                        cursorPos.Y -= 1;
                        NativeMethods.SetCursorPos(cursorPos);
                    }
                    e.Handled = true;
                    break;

                case Key.Down:
                    {
                        IntPoint cursorPos = NativeMethods.GetCursorPos();
                        cursorPos.Y += 1;
                        NativeMethods.SetCursorPos(cursorPos);
                    }
                    e.Handled = true;
                    break;
            }
            base.OnKeyDown(e);
        }

        protected virtual void OnClosing()
        {
        }
    }
}