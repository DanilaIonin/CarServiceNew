﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarService.Classes
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarServiceEntities : DbContext
    {
        public static CarServiceEntities _context;
        public CarServiceEntities()
            : base("name=CarServiceEntities")
        {
        }
        public static CarServiceEntities GetContext()
        {
            if (_context == null)
                _context = new CarServiceEntities();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
