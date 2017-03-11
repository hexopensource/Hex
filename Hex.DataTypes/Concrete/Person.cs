using Hex.DataTypes.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Hex.DataTypes.Concrete
{
    
    public class Person:Node
    {       
        public Person()
        {
            Label = "Person";
            LastUpdated = DateTime.UtcNow;
        }
        //[DataMember]
        public string Name { get; set; }
        //[DataMember]
        public string Surname { get; set; }
        //[DataMember]
        public string Id { get; set; }
        //[DataMember]
        public bool Status { get; set; }
        //[DataMember]
        public string BirthDate { get; set; }
       // [DataMember]
        public string UserType { get; set; }    

    }
}
