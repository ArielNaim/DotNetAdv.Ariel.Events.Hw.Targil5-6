using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdv.Ariel.Events.Hw.Targil5_6
{
    public delegate void SuccesfullLogin(User user);
    public delegate void UnsuccesfullLogin(FailedLoginReasons failedLoginReasons);

    public enum FailedLoginReasons
    {
        UserNameDoesNotExist, WrongPassword
    }
    public class Managament
    {
        public static List<User> users = new List<User>();
        User ariel = new User() { UserName = "Ariel", UserPassword = "A123" };
        User dvora = new User() { UserName = "Dvora", UserPassword = "D123" };
        User noa = new User() { UserName = "Noa", UserPassword = "N123" };
        User moshe = new User() { UserName = "Moshe", UserPassword = "M123" };

        public static event SuccesfullLogin SuccesfullLogin;
        public static event UnsuccesfullLogin UnsuccesfullLogin;
        public static void OnSuccesfullLogin(User user)
        {
            if(SuccesfullLogin != null)
            {
                SuccesfullLogin(user);
            }
        }
        public static void OnUnsuccesfullLogin(FailedLoginReasons failedLoginReasons)
        {
            if (UnsuccesfullLogin != null)
            {
                UnsuccesfullLogin(failedLoginReasons);
            }
        }
        public static bool Login(string userName, string userPassword)
        {
            foreach (var user in users)
            {
                if(user.UserName == userName)
                {
                    if(user.UserPassword != userPassword)
                    {
                        OnUnsuccesfullLogin(FailedLoginReasons.WrongPassword);
                        return false;
                    }
                    else
                    {
                        OnSuccesfullLogin(user);
                        return true;
                    }
                }
            }
                OnUnsuccesfullLogin(FailedLoginReasons.UserNameDoesNotExist);
                return false;
        }
    }
}
