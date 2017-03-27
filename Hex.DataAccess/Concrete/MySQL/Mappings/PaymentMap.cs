using Hex.DataTypes.Concrete.MySQLEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.DataAccess.Concrete.MySQL.Mappings
{
    public class PaymentMap: EntityTypeConfiguration<Payment>
    {
        public PaymentMap()
        {
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Payments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UserType).HasColumnName("UserType");
            this.Property(t => t.ExpiredDate).HasColumnName("ExpiredDate");

            HasOptional(t => t.user).WithMany(t => t.Payments).HasForeignKey(d => d.UserId);
        }
    }
}
