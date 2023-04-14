using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMagazinConsoleVersion.ViewController;
using RegistrationLibrary;

namespace BookMagazinConsoleVersion.Model
{
    public enum ChoseOfUser
    {
        TableOfSuppliers,
        TableOfDeclarations,
        TableOfCompositionIncome,
        TableOfBooks,
        TableOfRealization,
        ReportOfBookSales,
        ReportOfIncomePerBook
    }
    static class ObjectSelectionMenuModel
    {
        delegate void InteractionObjectDefined();
        static event InteractionObjectDefined NotifyAboutInteractionObjectDefined;
        static Object? CurrentObject;
        public static void DefiningObjectsForTheUser(User CurrentUser)
        {
            switch (CurrentUser.RoleInSystem) 
            {
                case User.Doljenost.Administrator: ObjectSelectionMenuViewController.DrawInterfaceForAdmin(); break;
                case User.Doljenost.Salesman: ObjectSelectionMenuViewController.DrawInterfaceForSalesman(); break;
                case User.Doljenost.Accountant: ObjectSelectionMenuViewController.DrawInterfaceForAccountant(); break;
                case User.Doljenost.Warehouse_Worker: ObjectSelectionMenuViewController.DrawInterfaceForWarehouse_Worker(); break;
                case User.Doljenost.None: ObjectSelectionMenuViewController.DrawInterfaceForNone(); break;
            }
        }
        public static void DefiningAnObjectForUserInteraction(ChoseOfUser ChoseObject)
        {
            switch (ChoseObject)
            {
                case ChoseOfUser.TableOfSuppliers: CurrentObject = new Objects.TableOfSuppliers(); break;
                case ChoseOfUser.TableOfDeclarations: CurrentObject = new Objects.TableOfDeclarations(); break;
                case ChoseOfUser.TableOfCompositionIncome: CurrentObject = new Objects.TableOfCompositionIncome(); break;
                case ChoseOfUser.TableOfBooks: CurrentObject = new Objects.TableOfBooks(); break;
                case ChoseOfUser.TableOfRealization: CurrentObject = new Objects.TableOfRealization(); break;
                case ChoseOfUser.ReportOfBookSales: CurrentObject = new Objects.ReportOfBookSales(); break;
                case ChoseOfUser.ReportOfIncomePerBook: CurrentObject = new Objects.ReportOfIncomePerBook(); break;
            }
            if (CurrentObject is Objects.Table)
            {
                NotifyAboutInteractionObjectDefined += ObjectSelectionMenuViewController.DrawMenuOfChoseInteractionWithTable;
            }
            else
            {
                NotifyAboutInteractionObjectDefined += ObjectSelectionMenuViewController.DrawMenuOfChoseInteractionWithReport;
            }
            NotifyAboutInteractionObjectDefined?.Invoke();
        }
        public static void InteractionWithTable(int MethodOfInteraction)
        {

        }
        public static void InteractionWithReport(int MethodOfInteraction)
        {

        }
    }
}
