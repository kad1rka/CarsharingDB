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
    
    public partial class Payments
    {
        public int payment_id { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<System.DateTime> payment_datetime { get; set; }
        public string payment_method { get; set; }
        public Nullable<int> trip_id { get; set; }
        public Nullable<int> client_id { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Trips Trips { get; set; }
    }
}
