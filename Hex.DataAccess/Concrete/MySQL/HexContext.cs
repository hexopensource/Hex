using Hex.DataAccess.Concrete.MySQL.Mappings;
using Hex.DataTypes.Concrete.MySQLEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.DataAccess.Concrete.MySQL
{
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class HexContext:DbContext
    {
        public HexContext() : base("Name=SexConnection")
        {
            //DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
       


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new UserMap());
            //modelBuilder.Configurations.Add(new PaymentMap());
            
        }
    }
}
