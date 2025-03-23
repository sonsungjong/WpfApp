using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_RJ.Model;

namespace WPF_RJ.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        //private ObservableCollection<TableDataModel> m_table_data_list;                             // 450 ~ 500ms (100000개)
        private RangeObservableCollection<TableDataModel> m_table_data_list;                    // 30 ~ 50ms (100000개), 약 10배

        //public ObservableCollection<TableDataModel> TableDataList
        public RangeObservableCollection<TableDataModel> TableDataList
        {
            get { return m_table_data_list; }
            set
            {
                if(m_table_data_list != value)
                {
                    m_table_data_list = value;
                    OnPropertyChanged(nameof(TableDataList));
                }
            }
        }

        // 버튼 ICommand 생성
        public ICommand ImageButtonCommand { get; set; }

        // 생성자
        public CustomerViewModel()
        {
            // ICommand 적용
            ImageButtonCommand = new ViewModelCommand(ExecuteImageButtonCommand);           // 다이아몬드 버튼 (임시)

            // 데이터그리드 생성
            //TableDataList = new ObservableCollection<TableDataModel>();
            TableDataList = new RangeObservableCollection<TableDataModel>();

            // 빈 행 30개
            for(int i = 0; i < 30; i++)
            {
                TableDataList.Add(new TableDataModel { No = "", Name = "", Info = "" });
            }
        }

        private void ExecuteImageButtonCommand(object obj)
        {
            if(TableDataList.Count > 0)
            {
                TableDataList.Clear();
            }
            else
            {
                TableDataList.Clear();

                //Stopwatch sw = Stopwatch.StartNew();                // 디버깅 : Stopwatch 시작

                var newList = new List<TableDataModel>();
                for (int i = 1; i <= 100000; i++)
                {
                    string no = i.ToString();
                    string name = "데이터 " + no;
                    string info = "샘플 " + no;
                    //TableDataModel newData = new TableDataModel { No = no, Name = name, Info = info };
                    //TableDataList.Add(newData);
                    newList.Add(new TableDataModel { No = no, Name = name, Info = info });              // 테이블에 담아놓고
                }

                // 일괄 적용한다
                TableDataList.AddRange(newList);

                //sw.Stop();                // 디버깅 : Stopwatch 정지

                // 소요 시간 출력
                //MessageBox.Show($"데이터 추가에 걸린 시간: {sw.ElapsedMilliseconds} ms", "성능 측정");                // 디버깅 : 성능 측정
            }
        }
    }


    /*
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
    */
}
