using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMagazinConsoleVersion.Model;
using Microsoft.VisualBasic;


namespace BookMagazinConsoleVersion.ViewController
{
    static class ObjectSelectionMenuViewController
    {
        delegate void UserSelectedObject(ChoseOfUser ChoseObject);
        static event UserSelectedObject NotifyAboutUserSelectedObject = ObjectSelectionMenuModel.DefiningAnObjectForUserInteraction;
        delegate void TheMethodOfInteractionIsSelected(int MethodOfIteraction);
        static event TheMethodOfInteractionIsSelected NotifyAboutTheMethodOfInteractionIsSelected;
        public static void DrawInterfaceForAdmin()
        {
            Console.WriteLine("Выберите объект, с которым желаете взаимодейтсвовать:");
            Console.WriteLine("1)Таблица поставщиков");
            Console.WriteLine("2)Таблица деклариций поступления");
            Console.WriteLine("3)Таблица состава поступлений");
            Console.WriteLine("4)Таблица книг");
            Console.WriteLine("5)Таблица сведений о реализации товара");
            Console.WriteLine("6)Отчет о продажах книг");
            Console.WriteLine("7)Отчет о прибыли от книг");
            int ChoseOfUser = Convert.ToInt32(Console.ReadLine());
            switch (ChoseOfUser)
            {
                case 1: NotifyAboutUserSelectedObject(Model.ChoseOfUser.TableOfSuppliers); break;
                case 2: NotifyAboutUserSelectedObject(Model.ChoseOfUser.TableOfDeclarations); break;
                case 3: NotifyAboutUserSelectedObject(Model.ChoseOfUser.TableOfCompositionIncome); break;
                case 4: NotifyAboutUserSelectedObject(Model.ChoseOfUser.TableOfBooks); break;
                case 5: NotifyAboutUserSelectedObject(Model.ChoseOfUser.TableOfRealization); break;
                case 6: NotifyAboutUserSelectedObject(Model.ChoseOfUser.ReportOfBookSales); break;
                case 7: NotifyAboutUserSelectedObject(Model.ChoseOfUser.ReportOfIncomePerBook); break;
                default: Console.Clear(); Console.WriteLine("Неправильный выбор объекта, повторите попытку"); DrawInterfaceForAdmin();break;
            }
        }
        public static void DrawInterfaceForSalesman()
        {
            Console.WriteLine("1)Таблица книг");
            Console.WriteLine("2)Таблица сведений о реализации товара");
            Console.WriteLine("3)Отчет о продажах книг");
            int ChoseOfUser = Convert.ToInt32(Console.ReadLine());
            switch (ChoseOfUser)
            {
                case 1: NotifyAboutUserSelectedObject(Model.ChoseOfUser.TableOfBooks); break;
                case 2: NotifyAboutUserSelectedObject(Model.ChoseOfUser.TableOfRealization); break;
                case 3: NotifyAboutUserSelectedObject(Model.ChoseOfUser.ReportOfBookSales); break;
                default: Console.Clear(); Console.WriteLine("Неправильный выбор объекта, повторите попытку"); DrawInterfaceForSalesman(); break;
            }
        }
        public static void DrawInterfaceForWarehouse_Worker()
        {
            Console.WriteLine("1)Таблица поставщиков");
            Console.WriteLine("2)Таблица деклариций поступления");
            Console.WriteLine("3)Таблица состава поступлений");
            int ChoseOfUser = Convert.ToInt32(Console.ReadLine());
            switch (ChoseOfUser)
            {
                case 1: NotifyAboutUserSelectedObject(Model.ChoseOfUser.TableOfSuppliers); break;
                case 2: NotifyAboutUserSelectedObject(Model.ChoseOfUser.TableOfDeclarations); break;
                case 3: NotifyAboutUserSelectedObject(Model.ChoseOfUser.TableOfCompositionIncome); break;
                default: Console.Clear(); Console.WriteLine("Неправильный выбор объекта, повторите попытку"); DrawInterfaceForWarehouse_Worker(); break;
            }
        }
        public static void DrawInterfaceForAccountant()
        {
            Console.WriteLine("1)Отчет о продажах книг");
            Console.WriteLine("2)Отчет о прибыли от книг");
            int ChoseOfUser = Convert.ToInt32(Console.ReadLine());
            switch (ChoseOfUser)
            {
                case 1: NotifyAboutUserSelectedObject(Model.ChoseOfUser.ReportOfBookSales); break;
                case 2: NotifyAboutUserSelectedObject(Model.ChoseOfUser.ReportOfIncomePerBook); break;
                default: Console.Clear(); Console.WriteLine("Неправильный выбор объекта, повторите попытку"); DrawInterfaceForAccountant(); break;
            }
        }
        public static void DrawInterfaceForNone()
        {
            Console.WriteLine("Обратитесь к администратору за помощью, ваша роль в системе не распознана");
        }
        public static void DrawMenuOfChoseInteractionWithTable()
        {
            Console.Clear();
            Console.WriteLine("Выберите функцию для взаимодействия с таблицей:");
            Console.WriteLine("1) Просмотреть таблицу");
            Console.WriteLine("2) Удалить запись из таблицы");
            Console.WriteLine("3) Добавить запись в таблицу");
            int choseIteraction = int.Parse(Console.ReadLine());
            if(choseIteraction >= 1 && choseIteraction <= 3)
            {
                NotifyAboutTheMethodOfInteractionIsSelected += ObjectSelectionMenuModel.InteractionWithTable;
                NotifyAboutTheMethodOfInteractionIsSelected(choseIteraction);
            }
            else
            {
                DrawMenuOfChoseInteractionWithTable();
            }
        }
        public static void DrawMenuOfChoseInteractionWithReport()
        {
            Console.Clear();
            Console.WriteLine("Выберите функцию для взаимодействия с отчетом:");
            Console.WriteLine("1) Сформировать отчет");
            int choseIteraction = int.Parse(Console.ReadLine());
            if (choseIteraction >= 1 && choseIteraction <= 1)
            {
                NotifyAboutTheMethodOfInteractionIsSelected += ObjectSelectionMenuModel.InteractionWithReport;
                NotifyAboutTheMethodOfInteractionIsSelected(choseIteraction);
            }
            else
            {
                DrawMenuOfChoseInteractionWithReport();
            }
        }
    }
}
