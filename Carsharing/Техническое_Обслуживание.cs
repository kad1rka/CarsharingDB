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
    
    public partial class Техническое_Обслуживание
    {
        public int ID_Тех_Обслуживания { get; set; }
        public Nullable<int> ID_Автомобиля { get; set; }
        public Nullable<int> ID_Категории_Тех_Обслуживания { get; set; }
        public Nullable<System.DateTime> Дата { get; set; }
        public string Описание { get; set; }
    
        public virtual Автомобили Автомобили { get; set; }
        public virtual Категории_Тех_Обслуживания Категории_Тех_Обслуживания { get; set; }
    }
}
