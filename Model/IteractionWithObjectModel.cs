using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMagazinConsoleVersion.Model
{
    static class IteractionWithObjectModel
    {
        delegate void ExtractingDataFromATable(List<string[]> DataFromTable, ChoseOfUser ChoseTable);
        static event ExtractingDataFromATable NotifyAboutTheDataHasBeenCured;
        static public void IdentifyObjectAndMethodOfWorkingWith(object CurrentObject, ChoseOfInteraction MethodOfWorkWith)
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
                        TableforWork.ShowAllFromTable();
                        break;
                    }
                case ChoseOfInteraction.AddDataInfile: break;
                case ChoseOfInteraction.DeleteDataFromFile: break;
            }
        }
        public static void InteractionWithReport(Objects.Report TableforWork, ChoseOfInteraction MethodOfWorkWith)
        {
            switch (MethodOfWorkWith)
            {
                case ChoseOfInteraction.FormReport: break;
            }
        }
    }
}
