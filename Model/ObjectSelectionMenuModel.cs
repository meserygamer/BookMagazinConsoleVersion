using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMagazinConsoleVersion.Objects;
using BookMagazinConsoleVersion.ViewController;
using RegistrationLibrary;

namespace BookMagazinConsoleVersion.Model
{
    /// <summary>
    /// Перечисление описывающее объекты, которые может выбрать пользователь
    /// </summary>
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
    public enum ChoseOfInteraction
    {
        ShowAllData,
        DeleteDataFromFile,
        AddDataInfile,
        FormReport
    }
    /// <summary>
    /// Класс описывающий меню выбора объектов (получение данных и алгоритмы обработки)
    /// </summary>
    static class ObjectSelectionMenuModel
    {
        /// <summary>
        /// Делегат основа для NotifyAboutInteractionObjectDefined
        /// </summary>
        delegate void InteractionObjectDefined();
        /// <summary>
        /// Событие сообщающее об определении объекта с которым будет взаимодействовать пользователь
        /// </summary>
        static event InteractionObjectDefined NotifyAboutInteractionObjectDefined;
        /// <summary>
        /// Поле содержащее в себе экземпляр объекта с которым взаимодйствует пользователь
        /// </summary>
        static ObjectOfSystem CurrentObject;
        delegate void EndOfChose(ObjectOfSystem ObjectForInteraction, ChoseOfInteraction IdIteraction);
        static event EndOfChose NotifyAboutChoseIsOver = IteractionWithObjectModel.IdentifyObjectAndMethodOfWorkingWith;
        public static User CurrentUser {get; private set;}
        /// <summary>
        /// Метод определяющий вариант меню выбора объекта, который будет отрисован пользователю
        /// </summary>
        /// <param name="CurrentUser">Структура User, определящая пользователя</param>
        public static void DefiningObjectsForTheUser(User CurrentUser)
        {
            ObjectSelectionMenuModel.CurrentUser = CurrentUser;
            switch (CurrentUser.RoleInSystem) 
            {
                case User.Doljenost.Administrator: ObjectSelectionMenuViewController.DrawInterfaceForAdmin(); break;
                case User.Doljenost.Salesman: ObjectSelectionMenuViewController.DrawInterfaceForSalesman(); break;
                case User.Doljenost.Accountant: ObjectSelectionMenuViewController.DrawInterfaceForAccountant(); break;
                case User.Doljenost.Warehouse_Worker: ObjectSelectionMenuViewController.DrawInterfaceForWarehouse_Worker(); break;
                case User.Doljenost.None: ObjectSelectionMenuViewController.DrawInterfaceForNone(); break;
            }
        }
        /// <summary>
        /// Метод создающий экземпляр объекта для взаимодействия с пользователем
        /// </summary>
        /// <param name="ChoseObject"> </param>
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
                NotifyAboutInteractionObjectDefined -= ObjectSelectionMenuViewController.DrawMenuOfChoseInteractionWithTable;
                NotifyAboutInteractionObjectDefined -= ObjectSelectionMenuViewController.DrawMenuOfChoseInteractionWithReport;
                NotifyAboutInteractionObjectDefined += ObjectSelectionMenuViewController.DrawMenuOfChoseInteractionWithTable;
            }
            if (CurrentObject is Objects.Report)
            {
                NotifyAboutInteractionObjectDefined -= ObjectSelectionMenuViewController.DrawMenuOfChoseInteractionWithTable;
                NotifyAboutInteractionObjectDefined -= ObjectSelectionMenuViewController.DrawMenuOfChoseInteractionWithReport;
                NotifyAboutInteractionObjectDefined += ObjectSelectionMenuViewController.DrawMenuOfChoseInteractionWithReport;
            }
            NotifyAboutInteractionObjectDefined?.Invoke();
        }
        public static void NextPage(ChoseOfInteraction ChoseIteraction) => NotifyAboutChoseIsOver(CurrentObject, ChoseIteraction);
    }
}
