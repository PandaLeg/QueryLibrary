using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace QueryLibrary
{
    public class Account
    {
        public int idAccount;
        public string nickName;
        [Obsolete]
        public string photo;
        public string login;
        public string password;
        public string phoneNumber;
        public string email;
        public DateTime birthDay;
        public decimal amountOfMoney;
        public string geoInf;
        public AccType accountType;
        public AccountState accountState;
    }
}
