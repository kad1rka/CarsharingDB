﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbCarsharing : DbContext
    {
        private static dbCarsharing _context;
        public dbCarsharing()
            : base("name=dbCarsharing")
        {
        }
        public static dbCarsharing GetContext()
        {
            if (_context == null) 
                _context = new dbCarsharing();
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Автомобили> Автомобили { get; set; }
        public virtual DbSet<ДТП> ДТП { get; set; }
        public virtual DbSet<Категории_Тех_Обслуживания> Категории_Тех_Обслуживания { get; set; }
        public virtual DbSet<Клиенты> Клиенты { get; set; }
        public virtual DbSet<Локации_Парковочных_Мест> Локации_Парковочных_Мест { get; set; }
        public virtual DbSet<Оплата> Оплата { get; set; }
        public virtual DbSet<Поездки> Поездки { get; set; }
        public virtual DbSet<Статус_Автомобиля> Статус_Автомобиля { get; set; }
        public virtual DbSet<Страховые_Данные> Страховые_Данные { get; set; }
        public virtual DbSet<Тарифы> Тарифы { get; set; }
        public virtual DbSet<Техническое_Обслуживание> Техническое_Обслуживание { get; set; }
    }
}
