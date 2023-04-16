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
        delegate void AddDataDelegate(int NumberOfRecord);
        static event AddDataDelegate NotifyAboutAddData;
        public static void ShowAllDataFromTable(List<string[]> DataFromTable, ObjectOfSystem ChoseTable)
        {
            Console.Clear();
            if(ChoseTable is not null)
            {
                ShowDataFromTable Shower = new ShowDataFromTable(DataFromTable, ChoseTable);
                Shower.DrawTablePart();
                Shower.DrawDataPartTable();
            }
        }
        public static void AddDataInTable(List<string[]> DataFromTable, ObjectOfSystem ChoseTable)
        {
            Console.Clear();
            if (ChoseTable is not null)
            {
                ShowAllDataFromTable(DataFromTable, ChoseTable);
                Console.WriteLine("\n\nВведите номер записи, которую желаете удалить:");
                int NumberOfRecord = -1;
                while(NumberOfRecord < 1 && NumberOfRecord > DataFromTable.Count)
                {
                    NumberOfRecord = Convert.ToInt32(Console.ReadLine());
                    if(NumberOfRecord < 1 && NumberOfRecord > DataFromTable.Count)
                    {
                        Console.WriteLine("Запись с таким номером отсутствует, повторите ввод:");
                    }
                }
                NotifyAboutAddData?.Invoke(NumberOfRecord);
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
