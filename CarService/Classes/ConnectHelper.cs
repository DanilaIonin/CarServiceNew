using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Classes
{
    public class ConnectHelper : DbContext
    {
        public static CarServiceEntities db = new CarServiceEntities();
        public DbSet<Employees> employees { get; set; }
        public ConnectHelper() : base("DefaultConnection")
        { }
    }
}
