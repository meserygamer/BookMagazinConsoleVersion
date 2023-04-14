using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMagazinConsoleVersion.Objects
{
    abstract class Table
    {
        protected string PathToFile;
    }
    class TableOfSuppliers : Table
    {
        public TableOfSuppliers()
        {
            PathToFile = "Suppliers.csv";
        }
    }
    class TableOfDeclarations : Table
    {
        public TableOfDeclarations()
        {
            PathToFile = "Declaration.csv";
        }
    }
    class TableOfCompositionIncome : Table
    {
        public TableOfCompositionIncome()
        {
            PathToFile = "CompositionIncome.csv";
        }
    }
    class TableOfBooks : Table
    {
        public TableOfBooks()
        {
            PathToFile = "Books.csv";
        }
    }
    class TableOfRealization : Table
    {
        public TableOfRealization()
        {
            PathToFile = "Realize.csv";
        }
    }
    class ReportOfBookSales
    {

    }
    class ReportOfIncomePerBook
    {

    }
}
