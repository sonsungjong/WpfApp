using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

public class RangeObservableCollection<T> : ObservableCollection<T>
{
    private bool m_suppressNotification = false;
    public void AddRange(IEnumerable<T> items)
    {
        if (items != null)
        {
            m_suppressNotification = true;
            foreach (var item in items)
            {
                Items.Add(item);
            }
            m_suppressNotification = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }

    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        if (!m_suppressNotification)
        {
            base.OnCollectionChanged(e);
        }
    }
}

