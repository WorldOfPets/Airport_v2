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
    
    public partial class TimeStatus
    {
        public int Id { get; set; }
        public Nullable<int> IdUser { get; set; }
        public Nullable<System.DateTime> TimeEnter { get; set; }
        public Nullable<System.DateTime> TimeExit { get; set; }
        public Nullable<int> idStatus { get; set; }
    
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
    }
}
