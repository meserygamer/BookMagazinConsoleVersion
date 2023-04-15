using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMagazinConsoleVersion.Model;
using Microsoft.VisualBasic;


namespace BookMagazinConsoleVersion.ViewController
{
    /// <summary>
    /// Класс описывающий меню выбора объектов (отрисовка данных пользователю)
    /// </summary>
    static class ObjectSelectionMenuViewController
    {
        /// <summary>
        /// Делегат основа для NotifyAboutUserSelectedObject
        /// </summary>
        /// <param name="ChoseObject">Перечисление идентифицирующее объект выбранный пользователем</param>
        delegate void UserSelectedObject(ChoseOfUser ChoseObject);
        /// <summary>
        /// Событие сообщающее о том, что пользователь выбрал объект взаимодействия
        /// </summary>
        static event UserSelectedObject NotifyAboutUserSelectedObject = ObjectSelectionMenuModel.DefiningAnObjectForUserInteraction;
        /// <summary>
        /// Делегат основа для NotifyAboutTheMethodOfInteractionIsSelected
        /// </summary>
        /// <param name="MethodOfIteraction">Числовой номер идентифицирующий способ взаимодействия пользователя с объектом</param>
        delegate void TheMethodOfInteractionIsSelected(ChoseOfInteraction MethodOfIteraction);
        /// <summary>
        /// Событие сообщающее о том, что пользователь выбрал способ взаимодействия с объектом
        /// </summary>
        static event TheMethodOfInteractionIsSelected NotifyAboutTheMethodOfInteractionIsSelected = ObjectSelectionMenuModel.NextPage;
        /// <summary>
        /// Отрисовка интерфейса выбора объекта для админа
        /// </summary>
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
        /// <summary>
        /// Отрисовка интерфейса выбора объекта для продавца
        /// </summary>
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
        /// <summary>
        /// Отрисовка интерфейса выбора объекта для работника склада
        /// </summary>
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
        /// <summary>
        /// Отрисовка интерфейса выбора объекта для бухгалтера
        /// </summary>
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
        /// <summary>
        /// Отрисовка интерфейса выбора объекта для неизвестного пользователя
        /// </summary>
        public static void DrawInterfaceForNone()
        {
            Console.WriteLine("Обратитесь к администратору за помощью, ваша роль в системе не распознана");
        }
        /// <summary>
        /// Отрисовка меню взаимодействия с таблицей
        /// </summary>
        public static void DrawMenuOfChoseInteractionWithTable()
        {
            Console.Clear();
            Console.WriteLine("Выберите функцию для взаимодействия с таблицей:");
            Console.WriteLine("1) Просмотреть таблицу");
            Console.WriteLine("2) Удалить запись из таблицы");
            Console.WriteLine("3) Добавить запись в таблицу");
            int choseIteraction = int.Parse(Console.ReadLine());
            switch (choseIteraction)
            {
                case 1: NotifyAboutTheMethodOfInteractionIsSelected?.Invoke(ChoseOfInteraction.ShowAllData); break;
                case 2: NotifyAboutTheMethodOfInteractionIsSelected?.Invoke(ChoseOfInteraction.DeleteDataFromFile); break;
                case 3: NotifyAboutTheMethodOfInteractionIsSelected?.Invoke(ChoseOfInteraction.AddDataInfile); break;
                default: DrawMenuOfChoseInteractionWithTable(); break;
            }
        }
        /// <summary>
        /// Отрисовка меню взаимодействия с отчетом
        /// </summary>
        public static void DrawMenuOfChoseInteractionWithReport()
        {
            Console.Clear();
            Console.WriteLine("Выберите функцию для взаимодействия с отчетом:");
            Console.WriteLine("1) Сформировать отчет");
            int choseIteraction = int.Parse(Console.ReadLine());
            switch (choseIteraction)
            {
                case 1: NotifyAboutTheMethodOfInteractionIsSelected?.Invoke(ChoseOfInteraction.FormReport); break;
                default : DrawMenuOfChoseInteractionWithReport(); break;
            }
        }
    }
}
