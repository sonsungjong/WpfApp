using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_RJ.Model
{
    public class OrderModel
    {
        public RangeObservableCollection<ET_Row> TableET { get; set; }
        public RangeObservableCollection<EE_Row> TableEE { get; set; }
        public RangeObservableCollection<IT_Row> TableIT { get; set; }
        public RangeObservableCollection<IE_Row> TableIE { get; set; }
    }

    public class ET_Row
    {
        public string ET_No { get; set; }                          // 1 + 글자색(하양/빨강)
        public string ET_Column1 { get; set; }             // FA001
        public string ET_Column2 { get; set; }              // H, W
        public string ET_Column3 { get; set; }              // 1, 2, 3
        public string ET_Column4 { get; set; }              // WF
        public string ET_Column5 { get; set; }              // NS
        public string ET_Column6 { get; set; }              // NS
        public string ET_Row_Color { get; set; }            // 전체 행의 글자색
    }
    public class EE_Row
    {
        public string EE_No { get; set; }                              // 1
        public string EE_Column1 { get; set; }                  // FA001
        public string EE_Column2 { get; set; }                  // 5/1
        public string EE_Column3 { get; set; }                  // 5/2
        public string EE_Column4 { get; set; }                  // TR,AS,FR,EF + 배경색
        public string EE_Column5 { get; set; }                  // 50
        public string EE_Column4_Percentage { get; set; }           // 배경색 비율
        public string EE_Column4_Bk { get; set; }           // EE_Column4의 배경색
    }
    public class IT_Row
    {
        public string IT_No { get; set; }                          // 1
        public string IT_Column1 { get; set; }          // KA001
        public string IT_Column2 { get; set; }          // 1
        public string IT_Column3 { get; set; }          // H
        public string IT_Column4 { get; set; }          // WF
        public string IT_Column5 { get; set; }          // FA
        public string IT_Column6 { get; set; }          // FD
        public string IT_Column7 { get; set; }          // FD
        public string IT_Row_Color { get; set; }        // 행의 글자색
    }
    public class IE_Row
    {
        public string IE_No { get; set; }                      // 1 + 글자색
        public string IE_Column1 { get; set; }          // KA001
        public string IE_Column2 { get; set; }          // FA000:W
        public string IE_Column3 { get; set; }          // W
        public string IE_Column4 { get; set; }          // AS + 배경색
        public string IE_Column4_Percentage { get; set; }          // 비율
        public string IE_Column4_Bk { get; set; }           // Column4의 배경색
    }
}
