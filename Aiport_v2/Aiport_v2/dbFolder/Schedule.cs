//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aiport_v2.dbFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public Nullable<int> IdAircraft { get; set; }
        public Nullable<int> IdRoute { get; set; }
        public Nullable<decimal> EconomyPrice { get; set; }
        public Nullable<bool> Confirmed { get; set; }
        public string FlightNumber { get; set; }
    
        public virtual Aircraft Aircraft { get; set; }
        public virtual Route Route { get; set; }
    }
}