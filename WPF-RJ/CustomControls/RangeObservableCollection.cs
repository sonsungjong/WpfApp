using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

public class RangeObservableCollection<T> : ObservableCollection<T>
{
    private bool m_suppressNotification = false;

    // 리스트를 매개변수로 할 때
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

    // 딕셔너리를 매개변수로 할 때
    public void AddRange<TKey>(IEnumerable<KeyValuePair<TKey, List<T>>> items)
    {
        if(items != null)
        {
            m_suppressNotification = true;

            foreach(var group in items)
            {
                foreach(var item in group.Value)
                {
                    Items.Add(item);
                }
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

