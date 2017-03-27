using Hex.DataTypes.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.DataTypes.Concrete.MySQLEntity
{
    public class Payment : IEntity
    {
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string UserId { get; set; }
        [JsonProperty]
        public string UserType { get; set; }
        [JsonProperty]
        public decimal Balance { get; set; }
        [JsonProperty]
        public DateTime ExpiredDate { get; set; }
        public User user { get; set; }
    }
}
