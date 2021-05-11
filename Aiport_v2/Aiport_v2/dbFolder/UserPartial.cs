using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiport_v2.dbFolder
{
    public partial class User
    {
        public string getAge //Получение возраста из даты рождения
        {
            get
            {
                var now = DateTime.Today;
                return Convert.ToString(now.Year - Birthdate.Value.Year - 1 + ((now.Month > Birthdate.Value.Month || now.Month == Birthdate.Value.Month && now.Day >= Birthdate.Value.Day) ? 1 : 0));
            }
        }
        public string getBack //Получение цвета фона строки
        {
            get
            {
                if (Active == true && IdRole == 2) { return "White"; } else if (Active == true && IdRole == 1) { return "Green"; } else return "Red";
            }
        }
        public string getFore //Получение цвета шрифта строки
        {
            get
            {
                if (Active == true && IdRole == 2) { return "Black"; } else return "White";
            }
        }
    }
}
