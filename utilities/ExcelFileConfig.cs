using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;

namespace iCargoUIAutomation.utilities
{
    public class ExcelFileConfig
    {
        public void AppendDataToExcel(string filePath, string date, string time, string screenName, string awbNumber)
        {
            // Set the license context for EPPlus 5.x or later
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo file = new FileInfo(filePath);

            // Check if the file exists
            if (!file.Exists)
            {
                // File does not exist, create new Excel file                
                using (ExcelPackage package = new ExcelPackage())
                {
                    // Create a worksheet
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    // Add headers
                    worksheet.Cells["A1"].Value = "Date";
                    worksheet.Cells["B1"].Value = "Time";
                    worksheet.Cells["C1"].Value = "Screen Name";
                    worksheet.Cells["D1"].Value = "AWB Number";

                    // Append new row with data
                    worksheet.Cells[2, 1].Value = date;
                    worksheet.Cells[2, 2].Value = time;
                    worksheet.Cells[2, 3].Value = screenName;
                    worksheet.Cells[2, 4].Value = awbNumber;

                    // Save the package to the file
                    package.SaveAs(file);
                }
            }
            else
            {
                // File already exists, open and append data
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                    if (worksheet == null)
                    {
                        throw new Exception("Worksheet could not be found in the Excel file.");
                    }

                    int rowCount = worksheet.Dimension?.Rows ?? 0;

                    // Append new row with data
                    worksheet.Cells[rowCount + 1, 1].Value = date;
                    worksheet.Cells[rowCount + 1, 2].Value = time;
                    worksheet.Cells[rowCount + 1, 3].Value = screenName;
                    worksheet.Cells[rowCount + 1, 4].Value = awbNumber;

                    package.Save();
                }
            }
        }

    }
}
