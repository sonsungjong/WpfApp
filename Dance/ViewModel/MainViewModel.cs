using Dance.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dance.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        MainModel m_main_model;
        ExcelModel m_excel_model;
        public ObservableCollection<ExcelModel> ExcelDataCollection {get;set;}
        string m_file_path = "C:\\Dance\\표.xlsx";

        public MainViewModel()
        {
            m_main_model = new MainModel();

            LoadExcelFile();
        }

        public void LoadExcelFile()
        {
            

        }


        public ObservableCollection<string> NameList
        {
            get => m_main_model.NameList;
            set
            {
                m_main_model.NameList = value;
                OnPropertyChanged(nameof(NameList));
            }
        }

        public ObservableCollection<string> SingList
        {
            get => m_main_model.SingList;
            set
            {
                m_main_model.SingList = value;
                OnPropertyChanged(nameof(SingList));
            }
        }


    }
}
