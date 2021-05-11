using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiport_v2.dbFolder
{
    public partial class Schedule
    {
        public string getDate //Получение даты
        {
            get 
            {
                return Date.Value.ToShortDateString();
            }
        }
        public string getFrom //Получение откуда вылетаем
        {
            get
            {
                var test = classFolder.dbClass.entities.Airport.FirstOrDefault(x => x.Id == Route.IdDepartureAirport);
                return test.IATACode;
            }
        }
        public string getTo //Полученте куда прилетаем
        {
            get
            {
                var test = classFolder.dbClass.entities.Airport.FirstOrDefault(x => x.Id == Route.IdArrivalAirport);
                return test.IATACode;
            }
        }

        public string getEc //Получение эконом цены
        {
            get
            {
                return $"${Math.Round((double)EconomyPrice)}";
            }
        }

        public string getBus //Получение бизнес цены
        {
            get
            {
                return $"${Math.Round((double)EconomyPrice * (double)1.35)}";
            }
        }
        public double getBusi //Костыль
        {
            get
            {
                return Math.Round((double)EconomyPrice * (double)1.35);
            }
        }
        public string getFir //Получение вип цены
        {
            get
            {
                return $"${Math.Round((double)getBusi * (double)1.30)}";
            }
        }
        public string getBackg //Получение цвета заднего фона строки
        {
            get
            {
                if (Confirmed == true) { return "White"; } else return "Red";
            }
        }
        public string getForeg //Получение цвета шрифта строки
        {
            get
            {
                if (Confirmed == true) { return "Black"; } else return "White";
            }
        }
    }
}
