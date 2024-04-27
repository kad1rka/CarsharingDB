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
    
    public partial class Trips
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trips()
        {
            this.Payments = new HashSet<Payments>();
        }
    
        public int trip_id { get; set; }
        public Nullable<System.DateTime> start_datetime { get; set; }
        public Nullable<System.DateTime> end_datetime { get; set; }
        public string location { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<int> client_id { get; set; }
        public Nullable<int> vehicle_id { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Fleet Fleet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
