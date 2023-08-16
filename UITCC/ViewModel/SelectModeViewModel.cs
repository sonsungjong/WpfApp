using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UITCC.Model;
using UITCC.View;

namespace UITCC.ViewModel
{
    public class SelectModeViewModel : ViewModelBase
    {
        // 멤버변수
        public SelectModeModel m_select_mode_model => SelectModeModel.Instance;
        public string m_engagement_text;            // 개인교전 버튼글자
        public string m_operation_text;                 // 개인작전 버튼글자
        public string m_team_text;                      // 팀훈련 버튼글자

        // 프로퍼티
        public int SelectMode
        {
            get
            {
                return m_select_mode_model.TrainMode;
            }
            set
            {
                m_select_mode_model.TrainMode = value;
                OnPropertyChanged(nameof(SelectMode));
            }
        }

        // 프로퍼티
        public int SelectLanguage
        {
            get
            {
                return m_select_mode_model.LanguageMode;
            }
            set
            {
                m_select_mode_model.LanguageMode = value;
                OnPropertyChanged(nameof(SelectLanguage));
            }
        }

        public string EngagementText
        {
            get => m_engagement_text;
            set
            {
                m_engagement_text = value;
                OnPropertyChanged(nameof(EngagementText));
            }
        }
        public string OperationText
        {
            get => m_operation_text;
            set
            {
                m_operation_text = value;
                OnPropertyChanged(nameof(OperationText));
            }
        }
        public string TeamText
        {
            get => m_team_text;
            set
            {
                m_team_text = value;
                OnPropertyChanged(nameof(TeamText));
            }
        }

        // Command
        public ICommand EngagementControlCommand { get; set; }
        public ICommand OperationControlCommand { get; set; }
        public ICommand TeamTrainingCommand { get; set; }

        // 생성자
        public SelectModeViewModel()
        {
            EngagementControlCommand = new ViewModelCommand(ExecuteEngagementControlCommand);
            OperationControlCommand = new ViewModelCommand(ExecuteOperationControlCommand);
            TeamTrainingCommand = new ViewModelCommand(ExecuteTeamTrainingCommand);
            
            m_select_mode_model.LanguageMode = 1;           // 기본은 영어

            if(m_select_mode_model.LanguageMode == 0)
            {
                // 한국어
                m_engagement_text = "개인 훈련\n교전통제소";
                m_operation_text = "개인 훈련\n작전통제소";
                m_team_text = "팀 훈련";
            }
            else
            {
                // 영어
                m_engagement_text = "Engagement\nControl";
                m_operation_text = "Operation\nControl";
                m_team_text = "Team\nTraining";
            }
        }

        private void ExecuteEngagementControlCommand(object obj)
        {
            // 이미 열려 있는 SystemManageView 창을 찾는다
            var main_view = Application.Current.Windows.OfType<SystemManageView>().FirstOrDefault();

            if(main_view == null)
            {
                SelectMode = 0;             // 개인 교전
                main_view = new SystemManageView();
                main_view.Show();
            }
            else
            {
                // 이미 열리있으면 활성화
                main_view.Activate();
            }
        }

        private void ExecuteOperationControlCommand(object obj)
        {
            // 이미 열려 있는 SystemManageView 창을 찾는다
            var main_view = Application.Current.Windows.OfType<SystemManageView>().FirstOrDefault();

            if (main_view == null)
            {
                SelectMode = 1;         // 개인 작전
                main_view = new SystemManageView();
                main_view.Show();
            }
            else
            {
                // 이미 열리있으면 활성화
                main_view.Activate();
            }
        }
        private void ExecuteTeamTrainingCommand(object obj)
        {
            // 이미 열려 있는 SystemManageView 창을 찾는다
            var main_view = Application.Current.Windows.OfType<SystemManageView>().FirstOrDefault();

            if (main_view == null)
            {
                SelectMode = 2;             // 팀
                main_view = new SystemManageView();
                main_view.Show();
            }
            else
            {
                // 이미 열리있으면 활성화
                main_view.Activate();
            }
        }
    }
}
