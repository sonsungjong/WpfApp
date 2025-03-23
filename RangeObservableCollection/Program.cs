using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections;
using System.Xml.Linq;

namespace RangeObservableCollection
{
    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        // AddRange를 사용할 때, 이벤트 발생을 일시 중지 시키기 위한 플래그
        private bool m_suppressNotification = false;

        public void AddRange(IEnumerable<T> collection)
        {
            if(collection != null)
            {
                m_suppressNotification = true;
                foreach(var item in collection)
                {
                    Items.Add(item);
                }
                m_suppressNotification = false;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if(!m_suppressNotification)
            {
                base.OnCollectionChanged(e);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
