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
    
    public partial class Категории_Тех_Обслуживания
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Категории_Тех_Обслуживания()
        {
            this.Техническое_Обслуживание = new HashSet<Техническое_Обслуживание>();
        }
    
        public int ID_Категории_Тех_Обслуживание { get; set; }
        public string Наименование { get; set; }
        public string Описание { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Техническое_Обслуживание> Техническое_Обслуживание { get; set; }
    }
}
