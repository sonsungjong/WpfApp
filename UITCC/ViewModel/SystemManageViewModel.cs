using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UITCC.Model;

namespace UITCC.ViewModel
{
    public class SystemManageViewModel : ViewModelBase
    {
        // 멤버변수
        public SelectModeModel m_select_mode_model => SelectModeModel.Instance;
        private bool _for_uncheck_radio_button;

        public bool ForUncheckRadioButton
        {
            get
            {
                return _for_uncheck_radio_button;
            }
            set
            {
                _for_uncheck_radio_button = value;
                OnPropertyChanged(nameof(ForUncheckRadioButton));
            }
        }

        public ICommand UncheckRadioButtonCommand { get; set; }

        // 생성자
        public SystemManageViewModel()
        {
            UncheckRadioButtonCommand = new ViewModelCommand(UncheckRadioButton);
            ForUncheckRadioButton = false;              // 메뉴버튼 체크불가능
        }

        private void UncheckRadioButton(object obj)
        {
            ForUncheckRadioButton = false;              // 메뉴버튼 체크불가능

            // 기타 메뉴버튼 작동구현
            MessageBox.Show("메뉴버튼이 눌렸습니다.", "제목", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
