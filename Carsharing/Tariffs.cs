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
    
    public partial class Tariffs
    {
        public int tariff_id { get; set; }
        public string name { get; set; }
        public Nullable<decimal> cost { get; set; }
        public string conditions { get; set; }
    }
}