using Hex.DataTypes.Concrete.MySQLEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.DataAccess.Abstract.MySQL
{
    public interface IUserRepository:IEntityRepository<User>
    {
    }
}
