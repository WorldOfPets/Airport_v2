using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiport_v2.dbFolder
{
    public partial class TimeStatus
    {
        public string getDate 
        {
            get 
            {
                return TimeEnter.Value.ToShortDateString();
            }
        }

        public string getLoginTime
        {
            get 
            {
                return TimeEnter.Value.ToShortTimeString();
            }
        }
        public string getExitTime
        {
            get
            {
                return TimeExit.Value.ToShortTimeString();
            }
        }
        public DateTime getInSys
        {
            get 
            {
                return Convert.ToDateTime((TimeExit.Value.TimeOfDay - TimeEnter.Value.TimeOfDay).ToString());
            }
        }
        public string getTimeInSys
        {
            get
            {
                return getInSys.ToShortTimeString();
            }
        }

        public string getErrorColour
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
        public string getErrorFore
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
