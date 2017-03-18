using Hex.DataTypes.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hex.DataTypes.Concrete
{  
    
    public class Node:INode
    {
        public Node()
        {
            LastUpdated = DateTime.UtcNow;
        }
      [JsonProperty]
        public string Label { get;  set; }
        [JsonProperty]
        public DateTimeOffset LastUpdated { get; set; }
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public bool Status { get; set; }

        //Skill
        [JsonProperty]
        public string Sector { get; set; }
        [JsonProperty]
        public string Count { get; set; }
        //Person
        [JsonProperty]
        public string Surname { get; set; }
        [JsonProperty]
        public string Birthday { get; set; }
        [JsonProperty]
        public string UserType { get; set; }
        //Company
    }
}
