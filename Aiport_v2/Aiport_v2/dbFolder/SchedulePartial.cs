using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiport_v2.dbFolder
{
    public partial class Schedule
    {
        public string getDate
        {
            get 
            {
                return Date.Value.ToShortDateString();
            }
        }
        public string getFrom
        {
            get
            {
                var test = classFolder.dbClass.entities.Airport.FirstOrDefault(x => x.Id == Route.IdDepartureAirport);
                return test.IATACode;
            }
        }
        public string getTo
        {
            get
            {
                var test = classFolder.dbClass.entities.Airport.FirstOrDefault(x => x.Id == Route.IdArrivalAirport);
                return test.IATACode;
            }
        }

        public string getEc
        {
            get
            {
                return $"${Math.Round((double)EconomyPrice)}";
            }
        }

        public string getBus
        {
            get
            {
                return $"${Math.Round((double)EconomyPrice * (double)1.35)}";
            }
        }
        public double getBusi
        {
            get
            {
                return Math.Round((double)EconomyPrice * (double)1.35);
            }
        }
        public string getFir
        {
            get
            {
                return $"${Math.Round((double)getBusi * (double)1.30)}";
            }
        }
        public string getBackg
        {
            get
            {
                if (Confirmed == true) { return "White"; } else return "Red";
            }
        }
        public string getForeg
        {
            get
            {
                if (Confirmed == true) { return "Black"; } else return "White";
            }
        }
    }
}
