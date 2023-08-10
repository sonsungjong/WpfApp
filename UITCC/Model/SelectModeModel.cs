using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITCC.Model
{
    public class SelectModeModel
    {
        // 0: 개인훈련 교전통제소, 1: 개인훈련 작전통제소, 2: 팀 훈련
        public int TrainMode { get; set; }

        // 언어 (0:한국어, 1:영어)
        public int LanguageMode { get; set; }

        // 해상도 (0: 1920x1080, )
        public int DisplayResolution { get; set; }

        // 모드설정 유지를 위해 싱글턴으로 관리
        private static SelectModeModel m_mode;
        public static SelectModeModel Instance => m_mode ?? (m_mode = new SelectModeModel());
        private SelectModeModel() { }
    }
}
