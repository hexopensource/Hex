using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hex.DataTypes.Abstract
{  
    
    public class Node:INode
    {
        public Node()
        {
            LastUpdated = DateTime.UtcNow;
        }
      
        public string Label { get;  set; }    
        public DateTimeOffset LastUpdated { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        //Skill
        public string Sector { get; set; }
        public string Count { get; set; }       
        //Person
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string UserType { get; set; }
        //Company
    }
}
