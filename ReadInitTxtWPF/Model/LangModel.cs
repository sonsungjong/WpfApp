using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReadInitTxtWPF.Model
{
    public class LangModel
    {
        private static readonly LangModel m_instance = new LangModel();
        public int Num {get; set;}
        public static LangModel Instance
        {
            get { return m_instance; }
        }
        private LangModel() 
        {
            Num = 1;
        }

        /*
        설정파일에서 언어를 읽어 변수에 저장하는 함수
        0: 영어 / 1: 한글
         */
        public void langFile(int a_num = 1)
        {
            Num = a_num;
            string langTxt = Num == 0 ? "C:\\UITCC\\Data\\Eng.txt" : "C:\\UITCC\\Data\\Kor.txt";

            try
            {
                string[] lines = File.ReadAllLines(langTxt);
                int lineCount = lines.Length;

                Normal = lineCount > 0 ? lines[0] : string.Empty;
                AbNormal = lineCount > 1 ? lines[1] : string.Empty;
                PowerOff = lineCount > 2 ? lines[2] : string.Empty;
                ConnectionDisconnected = lineCount > 3 ? lines[3] : string.Empty;
                SystemManager = lineCount > 4 ? lines[4] : string.Empty;
                ScenarioManager = lineCount > 5 ? lines[5] : string.Empty;
                UserManager = lineCount > 6 ? lines[6] : string.Empty;
                TrainingManager = lineCount > 7 ? lines[7] : string.Empty;
                VideoSignDistribution = lineCount > 8 ? lines[8] : string.Empty;
                Teacher1CH1 = lineCount > 9 ? lines[9] : string.Empty;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "langFile Read Error");
            }
        }

        // 정상
        public string Normal { get; set; }
        // 고장
        public string AbNormal { get; set; }
        // 전원OFF
        public string PowerOff { get; set; }
        // 연결끊김
        public string ConnectionDisconnected { get; set; }
        // 시스템관리
        public string SystemManager { get; set; }
        // 시나리오관리
        public string ScenarioManager { get; set; }

        //사용자관리
        public string UserManager { get; set; }
        // 훈련수행
        public string TrainingManager { get; set; }
        // 영상신호분배기
        public string VideoSignDistribution { get; set; }

        // 교관1 채널1
        public string Teacher1CH1 { get; set; }
        
    }
}
