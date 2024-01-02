using ReadInitTxtWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReadInitTxtWPF.ViewModel
{
    public class LangViewModel : ViewModelBase
    {
        public LangViewModel()
        {
            ExchangeLangCommand = new ViewModelCommand(ExecuteExchangeLangCommand);
        }

        public ICommand ExchangeLangCommand { get; }

        private void ExecuteExchangeLangCommand(object obj)
        {
            if(LangModel.Instance.Num == 0)
            {
                LangModel.Instance.langFile(1);
            }
            else if(LangModel.Instance.Num == 1)
            {
                LangModel.Instance.langFile(0);
            }
            else
            {
                /* no actions */
            }

            // 화면의 바인딩된 모든 속성의 재평가가 필요하다
            OnPropertyChanged(string.Empty);
        }

        public string Normal 
        {
            get=>LangModel.Instance.Normal;
        }

        public string AbNormal
        {
            get=> LangModel.Instance.AbNormal;
        }
        public string PowerOff
        {
            get => LangModel.Instance.PowerOff;
        }

        public string ConnectionDisconnected
        {
            get => LangModel.Instance.ConnectionDisconnected;
        }

        public string SystemManager
        {
            get => LangModel.Instance.SystemManager;
        }

        public string ScenarioManager
        {
            get => LangModel.Instance.ScenarioManager;
        }

        public string UserManager
        {
            get=> LangModel.Instance.UserManager;
        }

        public string TrainingManager
        {
            get => LangModel.Instance.TrainingManager;
        }

        public string VideoSignDistribution
        {
            get => LangModel.Instance.VideoSignDistribution;
        }

        public string Teacher1CH1
        {
            get => LangModel.Instance.Teacher1CH1;
        }
    }
}
