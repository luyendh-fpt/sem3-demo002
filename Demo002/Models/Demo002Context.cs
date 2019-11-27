using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Demo002.Models
{

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class Demo002Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Demo002Context() : base("name=MyContext")
        {
        }

        public System.Data.Entity.DbSet<Demo002.Models.Category> Categories { get; set; }
        public System.Data.Entity.DbSet<Demo002.Models.Product> Products { get; set; }
        public System.Data.Entity.DbSet<Demo002.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<Demo002.Models.OrderDetail> OrderDetails { get; set; }
    }
}
