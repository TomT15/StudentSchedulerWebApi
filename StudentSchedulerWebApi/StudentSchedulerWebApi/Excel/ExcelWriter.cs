using System;
using Microsoft.Office.Interop.Excel;

namespace StudentSchedulerWebApi.Excel
{
    public class ExcelWriter
    {
        public Application oXL;
        public _Workbook oWB;
        public _Worksheet oSheet;
        public Microsoft.Office.Interop.Excel.Range oRng;

        public ExcelWriter()
        {
            oXL = new Microsoft.Office.Interop.Excel.Application();
        }
        public void DemoWriteToExcel()
        {
            try
            {
                object misvalue = System.Reflection.Missing.Value;

                //oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "First Name";
                oSheet.Cells[1, 2] = "Last Name";
                oSheet.Cells[1, 3] = "Full Name";
                oSheet.Cells[1, 4] = "Salary";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "D1").Font.Bold = true;
                oSheet.get_Range("A1", "D1").VerticalAlignment =
                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                // Create an array to multiple values at once.
                string[,] saNames = new string[5, 2];

                saNames[0, 0] = "John";
                saNames[0, 1] = "Smith";
                saNames[1, 0] = "Tom";

                saNames[4, 1] = "Johnson";

                //Fill A2:B6 with an array of values (First and Last Names).
                oSheet.get_Range("A2", "B6").Value2 = saNames;

                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                oRng = oSheet.get_Range("C2", "C6");
                oRng.Formula = "=A2 & \" \" & B2";

                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                oRng = oSheet.get_Range("D2", "D6");
                oRng.Formula = "=RAND()*100000";
                oRng.NumberFormat = "$0.00";

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "D1");
                oRng.EntireColumn.AutoFit();

                oXL.Visible = false;
                oXL.UserControl = false;
                oWB.SaveAs("c:\\test\\test505.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.Close();
                oXL.Quit();
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error {ex}");
            }
        }

        /// <summary>
        /// TODO: There will incoming parameters that will need to be set
        /// </summary>
        /// <returns></returns>
        public bool WriteToExcel()
        {
            oXL.Visible = true;

            //Get a new workbook.
            oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
            oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

            //Add table headers going cell by cell.
            oSheet.Cells[1, 1] = "";
            oSheet.Cells[1, 2] = "Day";

            var timeIncrements = 15;
            //var timeIncrementCount = 0;
            for (var i = 0; i < 9; i++)
            {
                for (var timeCount = 0; timeCount < 4; timeCount++)
                {
                    if (i > 4)
                    {
                        if (timeCount == 0)
                            oSheet.Cells[i + 1, 1] = $"{i - 3} PM";
                        else
                            oSheet.Cells[i + 1, 1] = $"{i - 3}:{timeCount * timeIncrements} PM";
                    }
                    else
                    {
                        if (timeCount == 0)
                            oSheet.Cells[i + 1, 1] = $"{(i + 7)} AM";
                        else
                            oSheet.Cells[i + 1, 1] = $"{(i + 7)}:{timeCount * timeIncrements} AM";
                    }
                }
            }

            return false;
        }
    }
}


