using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrationLibrary;
using BookMagazinConsoleVersion.ViewController;

namespace BookMagazinConsoleVersion.Model
{
    /// <summary>
    /// Класс описывающий бизнес-логику и взаимодействие с данными на экране авторизации
    /// </summary>
    public class AuthPageModel
    {
        /// <summary>
        /// Делегат основа для события NotifyAboutSuccessfulLogin
        /// </summary>
        /// <param name="CurrentUser">Данные авторизированного пользователя</param>
        delegate void UserIsLoggedIn(User CurrentUser);
        /// <summary>
        /// Событие сообщающее об успешном прохождении авторизации
        /// </summary>
        static event UserIsLoggedIn NotifyAboutSuccessfullLogin = AuthPageViewController.SuccessfullLogin;
        /// <summary>
        /// Делегат основа для события NotifyAboutFailedLogin
        /// </summary>
        delegate void UserIsNotLoggedIn();
        /// <summary>
        /// Событие сообщающее об провале авторизации
        /// </summary>
        static event UserIsNotLoggedIn NotifyAboutFailedLogin = AuthPageViewController.FailedLogin;
        /// <summary>
        /// Поле хранящее информацию об авторизировавшемся пользователе
        /// </summary>
        static User? currentUser;
        /// <summary>
        /// Свойство обрабатывающее ифнормацию о пользователе, полученную после авторизации
        /// </summary>
        /// <remarks>
        /// Вызывает событие NotifyAboutSuccessfulLogin, при успешной авторизации или событие NotifyAboutFailedLogin при проваленной авторизации
        /// </remarks>
        static User? CurrentUser
        { 
            get
            {
                return currentUser;
            }
            set
            {
                if(value is not null)
                {
                    currentUser = value;
                    NotifyAboutSuccessfullLogin += ObjectSelectionMenuModel.DefiningObjectsForTheUser;
                    NotifyAboutSuccessfullLogin((User)currentUser);
                }
                else
                {
                    NotifyAboutFailedLogin();
                }
            }
        }
        /// <summary>
        /// Метод производящий аутентификацию пользователя в системе
        /// </summary>
        /// <param name="Login">Логин пользователя</param>
        /// <param name="Password">Пароль пользователя</param>
        public static void Autorization(string Login, string Password)
        {
            AuthenticationInSystem.PathToFileWithAuth = "AuthFile.csv";
            CurrentUser = AuthenticationInSystem.Authentication(Login, Password);
        }
    }
}
