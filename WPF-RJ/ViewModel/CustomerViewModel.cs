using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<TableDataModel> m_table_data_list;

        public ObservableCollection<TableDataModel> TableDataList
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
            TableDataList = new ObservableCollection<TableDataModel>();

            // 빈 행 20개
            for(int i = 0; i < 20; i++)
            {
                TableDataList.Add(new TableDataModel { A = "안녕", B = "하세요", C = "반갑" });
            }
        }

        private void ExecuteImageButtonCommand(object obj)
        {
            TableDataModel newData = new TableDataModel { A = "에이", B = "삐", C = "씨" };

            TableDataList.Add(newData);
        }
    }
}
