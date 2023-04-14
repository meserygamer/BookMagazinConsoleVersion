using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrationLibrary;
using BookMagazinConsoleVersion.ViewController;

namespace BookMagazinConsoleVersion.Model
{
    public class AuthPageModel
    {
        delegate void UserIsLoggedIn(User CurrentUser);
        static event UserIsLoggedIn NotifyAboutSuccessfulLogin = AuthPageViewController.SuccessfulLogin;
        delegate void UserIsNotLoggedIn();
        static event UserIsNotLoggedIn NotifyAboutFailedLogin = AuthPageViewController.FailedLogin;
        static User? currentUser;
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
                    NotifyAboutSuccessfulLogin((User)currentUser);
                }
                else
                {
                    NotifyAboutFailedLogin();
                }
            }
        }
        public static void Autorization(string Login, string Password)
        {
            AuthenticationInSystem.PathToFileWithAuth = "AuthFile.csv";
            CurrentUser = AuthenticationInSystem.Authentication(Login, Password);
        }
    }
}
