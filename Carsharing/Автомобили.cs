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
    
    public partial class Автомобили
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Автомобили()
        {
            this.ДТП = new HashSet<ДТП>();
            this.Поездки = new HashSet<Поездки>();
            this.Страховые_Данные = new HashSet<Страховые_Данные>();
            this.Техническое_Обслуживание = new HashSet<Техническое_Обслуживание>();
        }
    
        public int ID_Автомобиля { get; set; }
        public string Модель { get; set; }
        public Nullable<int> Год_Выпуска { get; set; }
        public string VIN_Номер { get; set; }
        public string Описание { get; set; }
        public string Номер { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ДТП> ДТП { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Поездки> Поездки { get; set; }
        public virtual Статус_Автомобиля Статус_Автомобиля { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Страховые_Данные> Страховые_Данные { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Техническое_Обслуживание> Техническое_Обслуживание { get; set; }
    }
}
