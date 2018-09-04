using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Prototype2
{
    public class ObservableUIElementCollection : UIElementCollection, INotifyCollectionChanged
    {
        public ObservableUIElementCollection(UIElement visualParent, FrameworkElement logicalElement) :
            base(visualParent, logicalElement)
        {
        }

        public override int Add(UIElement element)
        {
            int index = base.Add(element);
            OnCollectionChanged(NotifyCollectionChangedAction.Add, element, index);
            return index;
        }

        public override void Remove(UIElement element)
        {
            int index = IndexOf(element);
            base.Remove(element);
            OnCollectionChanged(NotifyCollectionChangedAction.Add, element, index);
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler collectionChanged = CollectionChanged;

            if (collectionChanged != null)
            {
                collectionChanged(this, e);
            }
        }

        private void OnCollectionChanged(NotifyCollectionChangedAction action, object item, int index)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, item, index));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}