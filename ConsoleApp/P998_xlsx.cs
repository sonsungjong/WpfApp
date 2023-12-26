using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;                           // Microsoft Excel 16.0 Object Library (COM 느림)


namespace ConsoleApp
{
    public class P998_xlsx
    {
        ObservableCollection<string> m_xlsx_content;
        public P998_xlsx()
        {
            InitExcel();
            foreach (string str in m_xlsx_content)
            {
                Console.WriteLine(str);
            }
        }

        public static void Main()
        {
            P998_xlsx app = new P998_xlsx();

        }

        public void InitExcel()
        {
            m_xlsx_content = new ObservableCollection<string>();

            string excel_path = "C:\\UITCC\\Data\\UITCC_UIText.xlsx";
            Microsoft.Office.Interop.Excel.Application excel_app = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excel_app.Workbooks.Open(excel_path);               // 열기
            Worksheet worksheet = workbook.Sheets[1];               // 첫번째 시트
            Range range = worksheet.UsedRange;
            int rowCount = range.Rows.Count;
            int columnCount = 1;

            for (int i = 1; i <= rowCount; i++)
            {
                string cellValue = (range.Cells[i, columnCount] as Range).Value2?.ToString();
                if (!string.IsNullOrEmpty(cellValue))
                {
                    m_xlsx_content.Add(cellValue);
                }
            }
            workbook.Close();
            excel_app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel_app);

        }


    }
}
