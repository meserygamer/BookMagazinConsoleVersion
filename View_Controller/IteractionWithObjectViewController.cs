using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMagazinConsoleVersion.Model;
using BookMagazinConsoleVersion.Objects;

namespace BookMagazinConsoleVersion.ViewController
{
    static class IteractionWithObjectViewController
    {
        delegate void DelDataDelegate(int NumberOfRecord);
        static event DelDataDelegate NotifyAboutDelData;
        delegate void AddDataDelegate();
        static event AddDataDelegate NotifyAboutAddData;
        delegate void ExportReport(Report ReportForExport);
        static event ExportReport NotifyAboutExportingReport = IteractionWithObjectModel.ExportReport;
        public static void ShowAllDataFromTable(List<string[]> DataFromTable, ObjectOfSystem ChoseTable)
        {
            Console.Clear();
            if(ChoseTable is not null)
            {
                ShowDataFromTable Shower = new ShowDataFromTable(DataFromTable, ChoseTable);
                Shower.DrawTablePart();
                Shower.DrawDataPartTable();
                if(ChoseTable is Report)
                {
                    ScreenOfExtractingReport(DataFromTable, (Report)ChoseTable);
                }
            }
        }
        public static void DelDataInTable(List<string[]> DataFromTable, ObjectOfSystem ChoseTable)
        {
            Console.Clear();
            NotifyAboutDelData += ((Table)ChoseTable).DelDataInTable;
            if (ChoseTable is not null)
            {
                ShowAllDataFromTable(DataFromTable, ChoseTable);
                Console.WriteLine("\n\nВведите номер записи, которую желаете удалить:");
                int NumberOfRecord = -1;
                while(NumberOfRecord < 1 || NumberOfRecord > DataFromTable.Count)
                {
                    NumberOfRecord = Convert.ToInt32(Console.ReadLine());
                    if(NumberOfRecord < 1 && NumberOfRecord > DataFromTable.Count)
                    {
                        Console.WriteLine("Запись с таким номером отсутствует, повторите ввод:");
                    }
                }
                NotifyAboutDelData?.Invoke(NumberOfRecord);
                ShowAllDataFromTable(((Table)ChoseTable).ShowAllFromTable(), ChoseTable);
            }
        }
        public static void AddDataInTable(List<string[]> DataFromTable, ObjectOfSystem ChoseTable)
        {
            Console.Clear();
            NotifyAboutAddData += ((Table)ChoseTable).AddDataInTable;
            if (ChoseTable is not null)
            {
                ShowAllDataFromTable(DataFromTable, ChoseTable);
                NotifyAboutAddData?.Invoke();
                Console.Clear();
                ShowAllDataFromTable(((Table)ChoseTable).ShowAllFromTable(), ChoseTable);
            }
        }
        public static void ScreenOfExtractingReport(List<string[]> DataFromTable, Report ChoseReport)
        {
            string? userAnswer = null;
            while(userAnswer is null)
            {
                Console.WriteLine("Желаете экспортировать отчет? (Да\\Нет)");
                userAnswer = Console.ReadLine();
                if (userAnswer is not null &&
                    (userAnswer.ToLower() == "да" || userAnswer.ToLower() == "д" || userAnswer.ToLower() == "yes"))
                {
                    NotifyAboutExportingReport(ChoseReport);
                }
                else if(userAnswer is not null &&
                    (userAnswer.ToLower() == "нет" || userAnswer.ToLower() == "н" || userAnswer.ToLower() == "no"))
                {

                }
                else
                {
                    userAnswer = null;
                }
            }
        }
    }
    class ShowDataFromTable
    {
        ObjectOfSystem currentTable;
        List<string[]> dataFromTable;
        int KolSt;
        List<int> FormatOfOutput = new List<int>();
        string[] TablePart;
        public ShowDataFromTable(List<string[]> DataFormTable, ObjectOfSystem ChoseTable)
        {
            currentTable = ChoseTable;
            dataFromTable = DataFormTable;
            KolSt = ChoseTable.KolStlb;
            TablePart = ChoseTable.TablePart;
        }
        public void DrawTablePart()
        {
            if(FormatOfOutput.Count == 0)
            {
                DefineFormatOfOutput();
            }
            PrintStringWithFormat(TablePart);
        }
        public void DrawDataPartTable()
        {
            if (FormatOfOutput.Count == 0)
            {
                DefineFormatOfOutput();
            }
            foreach(var str in dataFromTable)
            {
                PrintStringWithFormat(str);
            }
        }
        private void DefineFormatOfOutput()
        {
            while(FormatOfOutput.Count < KolSt)
            {
                List<string> stringsOfCurrentColumn = new List<string>{TablePart[FormatOfOutput.Count]};
                for(int i = 0; i < dataFromTable.Count; i++)
                {
                    stringsOfCurrentColumn.Add((dataFromTable[i])[FormatOfOutput.Count]);
                }
                FormatOfOutput.Add(stringsOfCurrentColumn.Max(a => a.Length));
            }
        }
        private void PrintStringWithFormat(string[] str)
        {
            for(int i = 0; i < str.Length; i++)
            {
                Console.Write(string.Format("{{0, -{0}}}|", FormatOfOutput[i]), str[i]);
            }
            Console.WriteLine();
        }
    }
}
