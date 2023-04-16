using BookMagazinConsoleVersion.ViewController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMagazinConsoleVersion.Objects;

namespace BookMagazinConsoleVersion.Model
{
    static class IteractionWithObjectModel
    {
        delegate void ExtractingDataFromATable(List<string[]> DataFromTable, ObjectOfSystem ChoseTable);
        static event ExtractingDataFromATable NotifyAboutTheDataHasBeenCured = IteractionWithObjectViewController.ShowAllDataFromTable;
        static event ExtractingDataFromATable NotifyAboutDeletingDataInTable = IteractionWithObjectViewController.DelDataInTable;
        static event ExtractingDataFromATable NotifyAboutAddingDataInTable = IteractionWithObjectViewController.AddDataInTable;
        static public void IdentifyObjectAndMethodOfWorkingWith(ObjectOfSystem CurrentObject, ChoseOfInteraction MethodOfWorkWith)
        {
            if (CurrentObject is Objects.Table)
            {
                InteractionWithTable((Objects.Table)CurrentObject, MethodOfWorkWith);
            }
            if (CurrentObject is Objects.Report)
            {
                InteractionWithReport((Objects.Report)CurrentObject, MethodOfWorkWith);
            }
        }
        public static void InteractionWithTable(Objects.Table TableforWork, ChoseOfInteraction MethodOfWorkWith)
        {
            switch(MethodOfWorkWith)
            {
                case ChoseOfInteraction.ShowAllData:
                    {
                        NotifyAboutTheDataHasBeenCured(TableforWork.ShowAllFromTable(), TableforWork);
                        break;
                    }
                case ChoseOfInteraction.AddDataInfile:
                    {
                        NotifyAboutAddingDataInTable(TableforWork.ShowAllFromTable(), TableforWork);
                        break;
                    }
                case ChoseOfInteraction.DeleteDataFromFile:
                    {
                        NotifyAboutDeletingDataInTable(TableforWork.ShowAllFromTable(), TableforWork);
                        break;
                    }
            }
        }
        public static void InteractionWithReport(Objects.Report TableforWork, ChoseOfInteraction MethodOfWorkWith)
        {
            switch (MethodOfWorkWith)
            {
                case ChoseOfInteraction.FormReport:
                    {
                        break;
                    }
            }
        }
        //private static ChoseOfUser? ReturnTypeOfObjectOfSystem(ObjectOfSystem CurrentObject)
        //{
        //    switch (CurrentObject.GetType().Name)
        //    {
        //        case "TableOfBooks": return ChoseOfUser.TableOfBooks;
        //        case "TableOfSuppliers": return ChoseOfUser.TableOfSuppliers;
        //        case "TableOfDeclarations": return ChoseOfUser.TableOfDeclarations;
        //        case "TableOfCompositionIncome": return ChoseOfUser.TableOfCompositionIncome;
        //        case "TableOfRealization": return ChoseOfUser.TableOfRealization;
        //        case "ReportOfBookSales": return ChoseOfUser.ReportOfBookSales;
        //        case "ReportOfIncomePerBook": return ChoseOfUser.ReportOfIncomePerBook;
        //        default: return null;
        //    }
        //}
    }
}
