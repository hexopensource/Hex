using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.DataTypes.Abstract;

namespace Hex.DataTypes.Concrete.MySQLEntity
{
    public class User:IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserType { get; set; }
        public string LinkedinId { get; set; }
        
    }
}
