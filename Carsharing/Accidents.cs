//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Carsharing
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accidents
    {
        public int accident_id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string description { get; set; }
        public Nullable<int> vehicle_id { get; set; }
    
        public virtual Fleet Fleet { get; set; }
    }
}