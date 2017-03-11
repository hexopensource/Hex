using Hex.DataTypes.Abstract;
using Hex.DataTypes.Concrete;
using Hex.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            GetNode();
            //AddNode2();
            //AddNode();
            //ShowNodes();

            Console.ReadLine();
        }

        private static void AddNode2()
        {
           
            WcfProxy<IHexService>.CreateChannel().Add(
               new Node()
               {
                   Label = "Person",
                   LastUpdated = DateTime.UtcNow,
                   Name="Julia",
                   Surname="Siik",
                   Id="JUL"                                     
                    
               });
        }

        private static void GetNode()
        {
            Node p = WcfProxy<IHexService>.CreateChannel().Get(new Node() { Id ="Onu" ,Name = "Onur",Label="Person"});

            Console.WriteLine(string.Format("Name: {0} , Surname : {1} Birth Date : {2} User Type {3} \n ", p.Name, p.Surname, p.Birthday, p.UserType));
        }

        private static void ShowNodes()
        {
            List<Node> persons = WcfProxy<IHexService>.CreateChannel().GetList(new Node() { Label = "Person" });
            persons.ForEach(p =>
            {
                Console.WriteLine(string.Format("Name: {0} , Surname : {1} Birth Date : {2} User Type {3} \n ", p.Name, p.Surname, p.Birthday, p.UserType));
            });
        }

        private static void AddNode()
        {
            //WcfProxy<IHexService>.CreateChannel().AddPerson(
            //    new Person()
            //    {
            //        Name = "Mehmet Can",
            //        BirthDate = "19.07.1990",
            //        Id = "MC",
            //        Status = false,
            //        Surname = "Kılınç",
            //        UserType = "user"

            //    });
           
        }
    }
}
