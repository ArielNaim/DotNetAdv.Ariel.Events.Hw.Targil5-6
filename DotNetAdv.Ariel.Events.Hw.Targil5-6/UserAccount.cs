using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdv.Ariel.Events.Hw.Targil5_6
{
    public delegate void Deposit(User user, int amount);
    public delegate void Withrawal(User user, int amount);

    class UserAccount
    {
        public static event Deposit UserDeposit;
        public static event Withrawal UserWithrawal;
        
        public int Account { get; set; }

    }
}
