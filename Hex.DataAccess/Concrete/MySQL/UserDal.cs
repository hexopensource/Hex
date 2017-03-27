using Hex.DataAccess.Abstract.MySQL;
using Hex.DataTypes.Concrete.MySQLEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.DataAccess.Concrete.MySQL
{
    public class UserDal:EfEntityRepository<HexContext,User>,IUserRepository
    {

    }
}
