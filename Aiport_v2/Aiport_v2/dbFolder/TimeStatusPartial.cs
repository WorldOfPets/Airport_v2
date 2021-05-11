using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiport_v2.dbFolder
{
    public partial class TimeStatus
    {
        public string getDate //Получение даты
        {
            get 
            {
                return TimeEnter.Value.ToShortDateString();
            }
        }

        public string getLoginTime //Получение времени (полный формат)
        {
            get 
            {
                return TimeEnter.Value.ToShortTimeString();
            }
        }
        public string getExitTime //Получение времени выхода
        {
            get
            {
                return TimeExit.Value.ToShortTimeString();
            }
        }
        public DateTime getInSys //Получение времени проведенного в системе
        {
            get 
            {
                return Convert.ToDateTime((TimeExit.Value.TimeOfDay - TimeEnter.Value.TimeOfDay).ToString());
            }
        }
        public string getTimeInSys //Преобразование в строку (костыль)
        {
            get
            {
                return getInSys.ToShortTimeString();
            }
        }

        public string getErrorColour //Получение цвет строки
        {
            get
            {
                if (idStatus != null)
                {
                    return "Red";
                }
                else 
                    return "White";
            }
        }
        public string getErrorFore //Получение цвета шрифта
        {
            get
            {
                if (idStatus != null)
                {
                    return "White";
                }
                else
                    return "Black";
            }
        }
    }
}
