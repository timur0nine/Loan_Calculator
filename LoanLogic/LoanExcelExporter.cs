using System;
using System.IO;
using ClosedXML.Excel;

namespace LoanLogic
{
    public static class LoanExcelExporter
    {
        public static void Export(Loan loan, string filePath, (string, string, string, string, string, string) language)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("График платежей");

            // Заголовки
            worksheet.Cell(1, 1).Value = language.Item1;
            worksheet.Cell(1, 2).Value = language.Item2;
            worksheet.Cell(1, 3).Value = language.Item3;
            worksheet.Cell(1, 4).Value = language.Item4;
            worksheet.Cell(1, 5).Value = language.Item5;

            // Стиль заголовков
            var headerRange = worksheet.Range(1, 1, 1, 5);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.CornflowerBlue;
            headerRange.Style.Font.FontColor = XLColor.White;
            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            decimal totalPayment = 0;
            decimal totalInterest = 0;

            // Данные
            bool stop = false;
            int iteration = 0;
            while (iteration < loan.TermMonths && !stop)
            {
                var row = iteration + 2;
                worksheet.Cell(row, 1).Value = (int)loan.Payouts[iteration, 0];
                worksheet.Cell(row, 2).Value = loan.Payouts[iteration, 1];
                worksheet.Cell(row, 3).Value = loan.Payouts[iteration, 2];
                worksheet.Cell(row, 4).Value = loan.Payouts[iteration, 3];
                worksheet.Cell(row, 5).Value = loan.Payouts[iteration, 4];
                if (loan.Payouts[iteration, 4] == 0)
                {
                    stop = true;
                }

                totalPayment += loan.Payouts[iteration, 1];
                totalInterest += loan.Payouts[iteration, 2];
                iteration++;
            }

            // Итоги внизу
            int totalRow = iteration + 3;
            worksheet.Cell(totalRow, 1).Value = language.Item6;
            worksheet.Cell(totalRow, 2).Value = totalPayment;
            worksheet.Cell(totalRow, 3).Value = totalInterest;
            worksheet.Range(totalRow, 1, totalRow, 3).Style.Font.Bold = true;

            // Числовой формат
            worksheet.Columns(2, 5).Style.NumberFormat.Format = "#,##0.00";

            // Границы
            var usedRange = worksheet.RangeUsed();
            usedRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            usedRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // Автоширина
            worksheet.Columns().AdjustToContents();

            worksheet.SheetView.FreezeRows(1);
            // Сохранение
            workbook.SaveAs(filePath);
        }

    }
}
