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
            //OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));               // 자체리셋하지말고 대입형식으로
        }
    }

    // 딕셔너리를 매개변수로 사용할 때 (키값 중복 금지)
    public void AddRange<TKey>(IEnumerable<KeyValuePair<TKey, T>> items)
    {
        if (items != null)
        {
            m_suppressNotification = true;

            // 고유 키에 해당하는 항목들을 그룹화해서 순서대로 추가
            foreach (var item in items)
            {
                Items.Add(item.Value);
            }
        }

        m_suppressNotification = false;
        //OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));               // 자체리셋하지말고 대입형식으로
    }

    // 딕셔너리<int, List>를 매개변수로 할 때 : 동일한 키에 여러개 넣어야할 때
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
            //OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }

    // 리스트를 매개변수로 할 때
    public void ChangeRange(IEnumerable<T> items)
    {
        if (items != null)
        {
            m_suppressNotification = true;
            Items.Clear();
            foreach (var item in items)
            {
                Items.Add(item);
            }
            m_suppressNotification = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }

    // 딕셔너리를 매개변수로 사용할 때 (키값 중복 금지)
    public void ChangeRange<TKey>(IEnumerable<KeyValuePair<TKey, T>> items)
    {
        if (items != null)
        {
            m_suppressNotification = true;
            Items.Clear();

            // 고유 키에 해당하는 항목들을 그룹화해서 순서대로 추가
            foreach (var item in items)
            {
                Items.Add(item.Value);
            }
        }

        m_suppressNotification = false;
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    // 딕셔너리<int, List>를 매개변수로 할 때 : 동일한 키에 여러개 넣어야할 때
    public void ChangeRange<TKey>(IEnumerable<KeyValuePair<TKey, List<T>>> items)
    {
        if (items != null)
        {
            m_suppressNotification = true;
            Items.Clear();
            foreach (var group in items)
            {
                foreach (var item in group.Value)
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

