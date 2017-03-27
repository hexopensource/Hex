using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.DataTypes.Abstract;
using Newtonsoft.Json;

namespace Hex.DataTypes.Concrete.MySQLEntity
{

    public class User:IEntity
    {
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string UserName { get; set; }
        [JsonProperty]
        public string Email { get; set; }
        [JsonProperty]
        public string Password { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Surname { get; set; }        
        [JsonProperty]
        public byte[] Photo { get; set; }
        [JsonProperty]
        public bool Status { get; set; }
        [JsonProperty]
        public string LinkedinId { get; set; }
        [JsonProperty]
        public DateTime RegistrationDate { get; set; }        
        public List<Payment> Payments { get; set; }

        
    }
}
