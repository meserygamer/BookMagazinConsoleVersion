using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMagazinConsoleVersion.Objects
{
    abstract class ObjectOfSystem
    {
        public string[] TablePart;
        public int KolStlb;
    }
    abstract class Table : ObjectOfSystem
    {
        protected string PathToFile;
        public virtual List<string[]> ShowAllFromTable()
        {
            using (StreamReader file = new StreamReader(PathToFile))
            {
                List<string[]> result = new List<string[]>();
                while (!file.EndOfStream)
                {
                    string? CurrentStringFromFile = file.ReadLine();
                    if (CurrentStringFromFile is not null) result.Add(CurrentStringFromFile.Split(";"));
                }
                return result;
            }
        }
        public virtual void DelDataInTable(int NumberOfRecord)
        {
            List<string[]> DataInTable = ShowAllFromTable();
            DataInTable.RemoveAt(NumberOfRecord - 1);
            using(StreamWriter file = new StreamWriter(File.Open(PathToFile, FileMode.Create)))
            {
                foreach (var str in DataInTable)
                {
                    string StrForRecord = "";
                    for(int i = 0; i < str.Length; i++)
                    {
                        StrForRecord += "" + str[i] + ";";
                    }
                    StrForRecord = StrForRecord[0..(StrForRecord.Length - 1)];
                    file.WriteLine(StrForRecord);
                }
            }
        }
        public abstract void AddDataInTable();
    }
    abstract class Report : ObjectOfSystem
    {
        public abstract List<string[]> FormReport();
        public string NameOfReport;
        public virtual void Export()
        {
            using (StreamWriter file = new StreamWriter(File.Open($"{NameOfReport}.csv", FileMode.Create),Encoding.UTF8))
            {
                List<string[]> DatafromReport = new List<string[]>(FormReport());
                foreach (var dataString in DatafromReport)
                {
                    string exportString = "";
                    for (int i = 0; i < KolStlb; i++)
                    {
                        exportString += dataString[i] + ";";
                    }
                    exportString = exportString[0..(exportString.Length - 1)];
                    file.WriteLine(exportString);
                }
            }
        }
    }
    class TableOfSuppliers : Table
    {
        public TableOfSuppliers()
        {
            TablePart = new string[] { "Номер постащика", "Название"
            , "Информация о поставщике" };
            PathToFile = "Suppliers.csv";
            KolStlb = 3;
        }
        public override void AddDataInTable()
        {
            List<string[]> DataInTable = ShowAllFromTable();
            string Record = "";
            Console.WriteLine("Введите номер поставщика:");
            Record += "" + Convert.ToInt32(Console.ReadLine()) + ";";
            Console.WriteLine("Введите название поставщика:");
            Record += "" + Console.ReadLine() + ";";
            Console.WriteLine("Введите информацию о поставщике:");
            Record += "" + Console.ReadLine();
            using (StreamWriter file = new StreamWriter(File.Open(PathToFile, FileMode.Create)))
            {
                foreach (var str in DataInTable)
                {
                    string StrForRecord = "";
                    for (int i = 0; i < str.Length; i++)
                    {
                        StrForRecord += "" + str[i] + ";";
                    }
                    StrForRecord = StrForRecord[0..(StrForRecord.Length - 1)];
                    file.WriteLine(StrForRecord);
                }
                file.WriteLine(Record);
            }
        }
    }
    class TableOfDeclarations : Table
    {
        public TableOfDeclarations()
        {
            TablePart = new string[] {"Номер документа", "Номер поставщика"
            , "Дата поступления"};
            PathToFile = "Declaration.csv";
            KolStlb = 3;
        }
        public override void AddDataInTable()
        {
            List<string[]> DataInTable = ShowAllFromTable();
            string Record = "";
            Console.WriteLine("Введите номер документа:");
            Record += "" + Convert.ToInt32(Console.ReadLine()) + ";";
            Console.WriteLine("Введите номер поставщика:");
            Record += "" + Convert.ToInt32(Console.ReadLine()) + ";";
            Console.WriteLine("Введите дату поступления:");
            Record += "" + Console.ReadLine();
            using (StreamWriter file = new StreamWriter(File.Open(PathToFile, FileMode.Create)))
            {
                foreach (var str in DataInTable)
                {
                    string StrForRecord = "";
                    for (int i = 0; i < str.Length; i++)
                    {
                        StrForRecord += "" + str[i] + ";";
                    }
                    StrForRecord = StrForRecord[0..(StrForRecord.Length - 1)];
                    file.WriteLine(StrForRecord);
                }
                file.WriteLine(Record);
            }
        }
    }
    class TableOfCompositionIncome : Table
    {
        public TableOfCompositionIncome()
        {
            TablePart = new string[] { "Номер документа", "Номер книги"
            , "Количество" };
            PathToFile = "CompositionIncome.csv";
            KolStlb = 3;
        }
        public override void AddDataInTable()
        {
            List<string[]> DataInTable = ShowAllFromTable();
            string Record = "";
            Console.WriteLine("Введите номер документа:");
            Record += "" + Convert.ToInt32(Console.ReadLine()) + ";";
            Console.WriteLine("Введите номер книги:");
            Record += "" + Convert.ToInt32(Console.ReadLine()) + ";";
            Console.WriteLine("Введите количество:");
            Record += "" + Convert.ToInt32(Console.ReadLine());
            using (StreamWriter file = new StreamWriter(File.Open(PathToFile, FileMode.Create)))
            {
                foreach (var str in DataInTable)
                {
                    string StrForRecord = "";
                    for (int i = 0; i < str.Length; i++)
                    {
                        StrForRecord += "" + str[i] + ";";
                    }
                    StrForRecord = StrForRecord[0..(StrForRecord.Length - 1)];
                    file.WriteLine(StrForRecord);
                }
                file.WriteLine(Record);
            }
        }
    }
    class TableOfBooks : Table
    {
        public struct RecordTableOfBooks
        {
            public int NumberObBook;
            public string NameOfBook;
            public string janr;
            public string Author;
            public string Izdat;
            public int GodIzdanija;
            public string MestoIzdanija;
            public int KolPages;
            public int cost;
            public RecordTableOfBooks(string[] StrFromTable)
            {
                NumberObBook = Convert.ToInt32(StrFromTable[0]);
                NameOfBook = StrFromTable[1];
                janr = StrFromTable[2];
                Author = StrFromTable[3];
                Izdat = StrFromTable[4];
                GodIzdanija = Convert.ToInt32(StrFromTable[5]);
                MestoIzdanija = StrFromTable[6];
                KolPages = Convert.ToInt32(StrFromTable[7]);
                cost = Convert.ToInt32(StrFromTable[8]);
            }
        }
        public TableOfBooks()
        {
            TablePart = new string[] { "Номер книги", "Название", "Жанр",
            "Автор", "Издательство", "Год издания", "Место издания", "Количество страниц", "Цена" };
            PathToFile = "Books.csv";
            KolStlb = 9;
        }
        public override void AddDataInTable()
        {
            List<string[]> DataInTable = ShowAllFromTable();
            string Record = "";
            Console.WriteLine("Введите номер книги:");
            Record += "" + Convert.ToInt32(Console.ReadLine()) + ";";
            Console.WriteLine("Введите название:");
            Record += "" + Console.ReadLine() + ";";
            Console.WriteLine("Введите жанр:");
            Record += "" + Console.ReadLine() + ";";
            Console.WriteLine("Введите автора:");
            Record += "" + Console.ReadLine() + ";";
            Console.WriteLine("Введите издательство:");
            Record += "" + Console.ReadLine() + ";";
            Console.WriteLine("Введите год издания:");
            Record += "" + Convert.ToInt32(Console.ReadLine()) + ";";
            Console.WriteLine("Введите место издания:");
            Record += "" + Console.ReadLine() + ";";
            Console.WriteLine("Введите количество страниц:");
            Record += "" + Convert.ToInt32(Console.ReadLine()) + ";";
            Console.WriteLine("Введите цену:");
            Record += "" + Convert.ToInt32(Console.ReadLine());
            using (StreamWriter file = new StreamWriter(File.Open(PathToFile, FileMode.Create)))
            {
                foreach (var str in DataInTable)
                {
                    string StrForRecord = "";
                    for (int i = 0; i < str.Length; i++)
                    {
                        StrForRecord += "" + str[i] + ";";
                    }
                    StrForRecord = StrForRecord[0..(StrForRecord.Length - 1)];
                    file.WriteLine(StrForRecord);
                }
                file.WriteLine(Record);
            }
        }
    }
    class TableOfRealization : Table
    {
        public struct RecordTableOfRealization
        {
            public int NumberObBook;
            public string DataRealise;
            public int Kol; 
            public int cost;
            public RecordTableOfRealization(string[] StrFromTable)
            {
                NumberObBook = Convert.ToInt32(StrFromTable[0]);
                DataRealise = StrFromTable[1];
                Kol = Convert.ToInt32(StrFromTable[2]);
                cost = Convert.ToInt32(StrFromTable[3]);
            }
        }
        public TableOfRealization()
        {
            TablePart = new string[] { "Номер книги", "Дата реализации"
            , "Количество", "Стоимость" };
            PathToFile = "Realize.csv";
            KolStlb = 4;
        }
        public override void AddDataInTable()
        {
            List<string[]> DataInTable = ShowAllFromTable();
            string Record = "";
            Console.WriteLine("Введите номер книги:");
            Record += "" + Convert.ToInt32(Console.ReadLine()) + ";";
            Console.WriteLine("Введите дату реализации:");
            Record += "" + Console.ReadLine() + ";";
            Console.WriteLine("Введите количество:");
            Record += "" + Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите стоимость:");
            Record += "" + Convert.ToInt32(Console.ReadLine());
            using (StreamWriter file = new StreamWriter(File.Open(PathToFile, FileMode.Create)))
            {
                foreach (var str in DataInTable)
                {
                    string StrForRecord = "";
                    for (int i = 0; i < str.Length; i++)
                    {
                        StrForRecord += "" + str[i] + ";";
                    }
                    StrForRecord = StrForRecord[0..(StrForRecord.Length - 1)];
                    file.WriteLine(StrForRecord);
                }
                file.WriteLine(Record);
            }
        }
    }
    class ReportOfBookSales : Report
    {
        public ReportOfBookSales()
        {
            TablePart = new string[] { "Номер книги", "Название книги"
            , "Количество продаж" };
            KolStlb = 3;
            NameOfReport = "ReportOfBookSales";
        }
        public override List<string[]> FormReport()
        {
            List<TableOfBooks.RecordTableOfBooks> DataFromBookTable = new List<TableOfBooks.RecordTableOfBooks>();
            foreach (var i in (new TableOfBooks()).ShowAllFromTable()) DataFromBookTable.Add(new TableOfBooks.RecordTableOfBooks(i));
            List<TableOfRealization.RecordTableOfRealization> DataFromRealizationTable = new List<TableOfRealization.RecordTableOfRealization>();
            foreach (var i in (new TableOfRealization()).ShowAllFromTable()) DataFromRealizationTable.Add(new TableOfRealization.RecordTableOfRealization(i));
            var Group = from t1 in DataFromRealizationTable
                        group t1.Kol by t1.NumberObBook into t2
                        select new
                        {
                            ID_Book = t2.Key,
                            SumOFRealize = t2.Sum()
                        };
            var CrossJoin = from t1 in DataFromBookTable
                            from t2 in Group
                            where t1.NumberObBook == t2.ID_Book
                            select new
                            {
                                NumberOfBook = t1.NumberObBook,
                                NameOfBook = t1.NameOfBook,
                                Kol = t2.SumOFRealize
                            };
            List<string[]> stringOfReport = new List<string[]>();
            foreach (var i in CrossJoin)
            {
                stringOfReport.Add(new string[] {Convert.ToString(i.NumberOfBook), i.NameOfBook, Convert.ToString(i.Kol)});
            }
            return stringOfReport;
        }
    }
    class ReportOfIncomePerBook : Report
    {
        public ReportOfIncomePerBook()
        {
            TablePart = new string[] { "Номер книги", "Название книги"
            , "Прибыль от продаж" };
            KolStlb = 3;
            NameOfReport = "ReportOfIncomePerBook";
        }
        public override List<string[]> FormReport()
        {
            List<TableOfBooks.RecordTableOfBooks> DataFromBookTable = new List<TableOfBooks.RecordTableOfBooks>();
            foreach (var i in (new TableOfBooks()).ShowAllFromTable()) DataFromBookTable.Add(new TableOfBooks.RecordTableOfBooks(i));
            List<TableOfRealization.RecordTableOfRealization> DataFromRealizationTable = new List<TableOfRealization.RecordTableOfRealization>();
            foreach (var i in (new TableOfRealization()).ShowAllFromTable()) DataFromRealizationTable.Add(new TableOfRealization.RecordTableOfRealization(i));
            var Group = from t1 in DataFromRealizationTable
                        group t1.cost by t1.NumberObBook into t2
                        select new
                        {
                            ID_Book = t2.Key,
                            SumOFRealize = t2.Sum()
                        };
            var CrossJoin = from t1 in DataFromBookTable
                            from t2 in Group
                            where t1.NumberObBook == t2.ID_Book
                            select new
                            {
                                NumberOfBook = t1.NumberObBook,
                                NameOfBook = t1.NameOfBook,
                                SumCost = t2.SumOFRealize
                            };
            List<string[]> stringOfReport = new List<string[]>();
            foreach (var i in CrossJoin)
            {
                stringOfReport.Add(new string[] { Convert.ToString(i.NumberOfBook), i.NameOfBook, Convert.ToString(i.SumCost)});
            }
            return stringOfReport;
        }
    }
}