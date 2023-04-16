using System;
using System.Collections.Generic;
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
    }
    abstract class Report : ObjectOfSystem
    {
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
    }
    class TableOfBooks : Table
    {
        public TableOfBooks()
        {
            TablePart = new string[] { "Номер книги", "Название", "Жанр",
            "Автор", "Издательство", "Год издания", "Место издания", "Количество страниц", "Цена" };
            PathToFile = "Books.csv";
            KolStlb = 9;
        }
    }
    class TableOfRealization : Table
    {
        public TableOfRealization()
        {
            TablePart = new string[] { "Номер книги", "Дата реализации"
            , "Количество", "Стоимость" };
            PathToFile = "Realize.csv";
            KolStlb = 4;
        }
    }
    class ReportOfBookSales : Report
    {
        public ReportOfBookSales()
        {
            TablePart = new string[] { "Номер книги", "Название книги"
            , "Количество продаж" };
            KolStlb = 3;
        }
    }
    class ReportOfIncomePerBook : Report
    {
        public ReportOfIncomePerBook()
        {
            TablePart = new string[] { "Номер книги", "Название книги"
            , "Прибыль от продаж" };
            KolStlb = 3;
        }
    }
}
