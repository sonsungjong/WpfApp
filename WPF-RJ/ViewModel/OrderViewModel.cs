using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_RJ.Model;
using WPF_RJ.Repositories;

namespace WPF_RJ.ViewModel
{
    public class OrderViewModel : ViewModelBase
    {
        // 생성자
        public OrderViewModel()
        {
            m_model = new OrderModel();
            TableETList = new RangeObservableCollection<ET_Row>();
            TableEEList = new RangeObservableCollection<EE_Row>();
            TableITList = new RangeObservableCollection<IT_Row>();
            TableIEList = new RangeObservableCollection<IE_Row>();

            ChangeETButtonCommand = new ViewModelCommand(ExecuteChangeETButtonCommand);
            ChangeEEButtonCommand = new ViewModelCommand(ExecuteChangeEEButtonCommand);
            ChangeITButtonCommand = new ViewModelCommand(ExecuteChangeITButtonCommand);
            ChangeIEButtonCommand = new ViewModelCommand(ExecuteChangeIEButtonCommand);
            ChangeAllButtonCommand = new ViewModelCommand(ExecuteChangeAllButtonCommand);

            for(int i=0; i < 30; i++)
            {
                TableETList.Add(new ET_Row
                {
                    ET_No = "",
                    ET_Column1 = "",
                    ET_Column2 = "",
                    ET_Column3 = "",
                    ET_Column4 = "",
                    ET_Column5 = "",
                    ET_Column6 = "",
                    ET_Row_Color = "",
                });
            }

            for (int i = 0; i < 30; i++)
            {
                TableEEList.Add(new EE_Row
                {
                    EE_No = "",
                    EE_Column1 = "",
                    EE_Column2 = "",
                    EE_Column3 = "",
                    EE_Column4 = "",
                    EE_Column5 = "",
                    EE_Column4_Percentage = "",
                    EE_Column4_Bk = "",
                });
            }

            for (int i = 0; i < 30; i++)
            {
                TableITList.Add(new IT_Row
                {
                    IT_No = "",
                    IT_Column1 = "",
                    IT_Column2 = "",
                    IT_Column3 = "",
                    IT_Column4 = "",
                    IT_Column5 = "",
                    IT_Column6 = "",
                    IT_Column7 = "",
                    IT_Row_Color = "",
                });
            }

            for (int i = 0; i < 30; i++)
            {
                TableIEList.Add(new IE_Row
                {
                    IE_No = "",
                    IE_Column1 = "",
                    IE_Column2 = "",
                    IE_Column3 = "",
                    IE_Column4 = "",
                    IE_Column4_Percentage = "",
                    IE_Column4_Bk = "",
                });
            }



        }

        private OrderModel m_model;
        public int test_count1 = 0;
        public int test_count2 = 0;
        public int test_count3 = 0;
        public int test_count4 = 0;
        public int test_count5 = 0;

        public RangeObservableCollection<ET_Row> TableETList
        {
            get { return m_model.TableET; }
            set
            {
                if(m_model != null && m_model.TableET != value)
                {
                    m_model.TableET = value;
                    OnPropertyChanged(nameof(TableETList));
                }
            }
        }
        public RangeObservableCollection<EE_Row> TableEEList
        {
            get { return m_model.TableEE; }
            set
            {
                if (m_model != null && m_model.TableEE != value)
                {
                    m_model.TableEE = value;
                    OnPropertyChanged(nameof(TableEEList));
                }
            }
        }
        public RangeObservableCollection<IT_Row> TableITList
        {
            get { return m_model.TableIT; }
            set
            {
                if (m_model != null && m_model.TableIT != value)
                {
                    m_model.TableIT = value;
                    OnPropertyChanged(nameof(TableITList));
                }
            }
        }
        public RangeObservableCollection<IE_Row> TableIEList
        {
            get { return m_model.TableIE; }
            set
            {
                if (m_model != null && m_model.TableIE != value)
                {
                    m_model.TableIE = value;
                    OnPropertyChanged(nameof(TableIEList));
                }
            }
        }

        public ICommand ChangeETButtonCommand { get; set; }
        public ICommand ChangeEEButtonCommand { get; set; }
        public ICommand ChangeITButtonCommand { get; set; }
        public ICommand ChangeIEButtonCommand { get; set; }
        public ICommand ChangeAllButtonCommand { get; set; }

        private void ExecuteChangeETButtonCommand(object obj)
        {
            test_count1++;

            var newDict = new Dictionary<int, ET_Row>();
            var newSortedList = new SortedList<int, ET_Row>();
            int total = 999;
            string et_no = "";
            string et_column1 = "";
            string et_column2 = "";
            string et_column3 = "";
            string et_column4 = "";
            string et_column5 = "";
            string et_column6 = "";
            string et_row_color = "";
            for(int i=1; i<=total; i++)
            {
                et_no = i.ToString();
                et_column1 = "FA" + i.ToString("D3");
                et_column3 = ((total % 3) + 1).ToString();
                if(test_count1 % 2 == 0)
                {
                    et_column2 = "H";
                    et_column4 = "WS";
                    et_column5 = "NS";
                    et_column6 = "더블유"+ et_no;
                    et_row_color = "#FF0000";
                }
                else
                {
                    et_column2 = "U";
                    et_column4 = "NS";
                    et_column5 = "WF";
                    et_column6 = "WF"+ et_no;
                    et_row_color = "#FFFFFF";
                }

                newDict[i] = new ET_Row
                {
                    ET_No = et_no,
                    ET_Column1 = et_column1,
                    ET_Column2 = et_column2,
                    ET_Column3 = et_column3,
                    ET_Column4 = et_column4,
                    ET_Column5 = et_column5,
                    ET_Column6 = et_column6,
                    ET_Row_Color = et_row_color,
                };
            }

            TableETList.ChangeRange(newDict);
        }
        private void ExecuteChangeEEButtonCommand(object obj)
        {
            test_count2++;

            var newDict = new Dictionary<int, EE_Row>();
            var newSortedList = new SortedList<int, EE_Row>();
            int total = 999;
            string ee_no = "";
            string ee_column1 = "";
            string ee_column2 = "";
            string ee_column3 = "";
            string ee_column4 = "";
            string ee_column5 = "";
            string ee_column4_percentage = "";
            string ee_column4_bk = "";
            
            for (int i = 1; i <= total; i++)
            {
                ee_no = i.ToString();
                ee_column1 = "FA" + i.ToString("D3");
                if (test_count2 % 2 == 0)
                {
                    ee_column2 = "5/1";
                    ee_column3 = "5/2";
                    ee_column4 = "FR";
                    ee_column4_percentage = "80";
                    ee_column4_bk = "#FF0000";
                    ee_column5 = "50";
                }
                else
                {
                    ee_column2 = "8/2";
                    ee_column3 = "1/5";
                    ee_column4 = "격추";
                    ee_column4_percentage = "100";
                    ee_column4_bk = "#00FF00";
                    ee_column5 = "88";
                }

                newDict[i] = new EE_Row
                {
                    EE_No = ee_no,
                    EE_Column1 = ee_column1,
                    EE_Column2 = ee_column2,
                    EE_Column3 = ee_column3,
                    EE_Column4 = ee_column4,
                    EE_Column5 = ee_column5,
                    EE_Column4_Percentage = ee_column4_percentage,
                    EE_Column4_Bk = ee_column4_bk,
                };
            }

            TableEEList.ChangeRange(newDict);
        }
        private void ExecuteChangeITButtonCommand(object obj)
        {
            test_count3++;

            var newDict = new Dictionary<int, IT_Row>();
            var newSortedList = new SortedList<int, IT_Row>();
            int total = 999;
            string it_no = "";
            string it_column1 = "";
            string it_column2 = "";
            string it_column3 = "";
            string it_column4 = "";
            string it_column5 = "";
            string it_column6 = "";
            string it_column7 = "";
            string it_row_color = "";
            for (int i = 1; i <= total; i++)
            {
                it_no = i.ToString();
                it_column1 = "KA" + i.ToString("D3");
                it_column2 = ((total % 3) + 1).ToString();
                it_column3 = "H";
                if (test_count3 % 2 == 0)
                {
                    it_column4 = "WF";
                    it_column5 = "FA";
                    it_column6 = "FD";
                    it_column7 = "FD"+ it_no;
                    it_row_color = "#FF0000";
                }
                else
                {
                    it_column4 = "NS";
                    it_column5 = "FD";
                    it_column6 = "FA";
                    it_column7 = "에프디"+ it_no;
                    it_row_color = "#FFFFFF";
                }

                newDict[i] = new IT_Row
                {
                    IT_No = it_no,
                    IT_Column1 = it_column1,
                    IT_Column2 = it_column2,
                    IT_Column3 = it_column3,
                    IT_Column4 = it_column4,
                    IT_Column5 = it_column5,
                    IT_Column6 = it_column6,
                    IT_Column7 = it_column7,
                    IT_Row_Color = it_row_color,
                };
            }

            TableITList.ChangeRange(newDict);
        }
        private void ExecuteChangeIEButtonCommand(object obj)
        {
            test_count4++;

            var newDict = new Dictionary<int, IE_Row>();
            var newSortedList = new SortedList<int, IE_Row>();
            int total = 999;
            string ie_no = "";
            string ie_column1 = "";
            string ie_column2 = "";
            string ie_column3 = "";
            string ie_column4 = "";
            string ie_column4_percentage = "";
            string ie_column4_bk = "";

            for (int i = 1; i <= total; i++)
            {
                ie_no = i.ToString();
                ie_column1 = "KA" + i.ToString("D3");
                if (test_count4 % 2 == 0)
                {
                    ie_column3 = "W";
                    ie_column2 = "FA" + i.ToString("D3") + ie_column3;
                    ie_column4 = "FR";
                    ie_column4_percentage = "80";
                    ie_column4_bk = "#FF0000";
                }
                else
                {
                    ie_column3 = "H";
                    ie_column2 = "FA" + i.ToString("D3") + ie_column3;
                    ie_column4 = "격추";
                    ie_column4_percentage = "100";
                    ie_column4_bk = "#00FF00";
                }

                newDict[i] = new IE_Row
                {
                    IE_No = ie_no,
                    IE_Column1 = ie_column1,
                    IE_Column2 = ie_column2,
                    IE_Column3 = ie_column3,
                    IE_Column4 = ie_column4,
                    IE_Column4_Percentage = ie_column4_percentage,
                    IE_Column4_Bk = ie_column4_bk,
                };
            }

            TableIEList.ChangeRange(newDict);

        }
        private void ExecuteChangeAllButtonCommand(object obj)
        {
            ExecuteChangeETButtonCommand(null);
            ExecuteChangeEEButtonCommand(null);
            ExecuteChangeITButtonCommand(null);
            ExecuteChangeIEButtonCommand(null);

        }
    }
}
