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
    
    public partial class Поездки
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Поездки()
        {
            this.Оплата = new HashSet<Оплата>();
        }
    
        public int ID_Поездки { get; set; }
        public Nullable<int> ID_Клиента { get; set; }
        public Nullable<int> ID_Автомобиля { get; set; }
        public Nullable<int> ID_Тарифа { get; set; }
        public Nullable<System.DateTime> ДатаВремя_Начала { get; set; }
        public Nullable<System.DateTime> ДатаВремя_Конца { get; set; }
        public Nullable<int> ID_Локации_Начала { get; set; }
        public Nullable<int> ID_Локации_Конца { get; set; }
        public Nullable<decimal> Стоимость { get; set; }
    
        public virtual Автомобили Автомобили { get; set; }
        public virtual Клиенты Клиенты { get; set; }
        public virtual Локации_Парковочных_Мест Локации_Парковочных_Мест { get; set; }
        public virtual Локации_Парковочных_Мест Локации_Парковочных_Мест1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Оплата> Оплата { get; set; }
        public virtual Тарифы Тарифы { get; set; }
    }
}
