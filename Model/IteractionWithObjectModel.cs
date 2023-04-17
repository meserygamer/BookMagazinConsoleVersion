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
        delegate void ExtractingDataFromATable(List<string[]> DataFromTable, ObjectOfSystem ChoseTable,
            IteractionWithObjectViewController.ModeOfUseShowDataFromtable ModeOfUsing = IteractionWithObjectViewController.ModeOfUseShowDataFromtable.AloneMethod);
        delegate void ManepulatedOnDataFromATable(List<string[]> DataFromTable, ObjectOfSystem ChoseTable);
        static event ExtractingDataFromATable NotifyAboutTheDataHasBeenCured = IteractionWithObjectViewController.ShowAllDataFromTable;
        static event ManepulatedOnDataFromATable NotifyAboutDeletingDataInTable = IteractionWithObjectViewController.DelDataInTable;
        static event ManepulatedOnDataFromATable NotifyAboutAddingDataInTable = IteractionWithObjectViewController.AddDataInTable;
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
                        NotifyAboutTheDataHasBeenCured(TableforWork.FormReport(), TableforWork, IteractionWithObjectViewController.ModeOfUseShowDataFromtable.FromOtherMethod);
                        break;
                    }
            }
        }
        public static void ExportReport(Report ReportForExport) => ReportForExport.Export();
    }
}
