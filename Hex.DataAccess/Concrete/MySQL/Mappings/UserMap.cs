using Hex.DataTypes.Concrete.MySQLEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.DataAccess.Concrete.MySQL.Mappings
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Email).IsRequired().HasMaxLength(100);
            Property(t => t.LinkedinId).IsRequired().HasMaxLength(20);
            Property(t => t.Password).IsRequired();
            Property(t => t.Id).HasMaxLength(50);

            ToTable("Users");
            Property(t => t.Id).HasColumnName("UserId");
            Property(t => t.UserName).HasColumnName("UserName");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.LinkedinId).HasColumnName("LinkedinId");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.Password).HasColumnName("Password");
            Property(t => t.Photo).HasColumnName("Photo");
            Property(t => t.RegistrationDate).HasColumnName("RegistrationDate");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.Surname).HasColumnName("Surname");         

           

        }
    }
}
