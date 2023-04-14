using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BookMagazinConsoleVersion.Model;
using RegistrationLibrary;

namespace BookMagazinConsoleVersion.ViewController
{
    /// <summary>
    /// Класс описывающий визуальную состовляющую и состовляющую взаимодействия с пользователем
    /// </summary>
    public class AuthPageViewController
    {
        /// <summary>
        /// Делегат основа для события NotifyAboutAuthorization, запускает процесс авторизации
        /// </summary>
        /// <param name="Login">Логин пользователя</param>
        /// <param name="Password">Пароль пользователя</param>
        public delegate void LoginController(string Login, string Password);
        /// <summary>
        /// Событие сообщающее о начале процесса авторизации
        /// </summary>
        public static event LoginController NotifyAboutAuthorization = AuthPageModel.Autorization;
        /// <summary>
        /// Конструктор страницы авторизации
        /// </summary>
        public AuthPageViewController()
        {
            Console.Clear();
            Console.WriteLine("Вас приветствует система КиУКМ!");
            LoginInSystem();
        }
        /// <summary>
        /// Метод для ввода данных пользователя и запуска процесса авторизации
        /// </summary>
        private static void LoginInSystem()
        {
            Console.WriteLine("Введите Логин и Пароль:");
            NotifyAboutAuthorization(Console.ReadLine(), Console.ReadLine());
        }
        /// <summary>
        /// Метод отрисовывающий приветственный экран после успешной авторизации
        /// </summary>
        /// <param name="UserData">Структура описывающая данные пользователя</param>
        public static void SuccessfulLogin(User UserData)
        {
            Console.Clear();
            Console.WriteLine($"Добро пожаловать {UserData.Surname} {UserData.Name}!");
            Thread.Sleep(1000);
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
        }
        /// <summary>
        /// Метод отрисовывающий экран проваленной авторизации
        /// </summary>
        public static void FailedLogin()
        {
            Console.Clear();
            Console.WriteLine("Неверный логин или пароль, повторите попытку ввода:");
            LoginInSystem();
        }
    }
}
