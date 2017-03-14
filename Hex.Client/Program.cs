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
            
            //GetRelated();
            //DeleteRelation();
            //AddRelation();
            //UpdateNode();
            //DeleteNode();
            //GetNode();
            //AddNode2();
            //AddNode();
            //ShowNodes();
            Console.WriteLine("Oldu Canımm");
            Console.ReadLine();
        }

        private static void GetRelated()
        {
            Node node1 = WcfProxy<IHexService>.CreateChannel().Get(
                new Node { Label = "Person", Id = "Bar" }
                );
            node1.Label = "Person";
            Node node2 = new Node() { Label = "Person" };
            node2.Label = "Person";
           
            List<Node> list=WcfProxy<IHexService>.CreateChannel().GetRelated(
               node1, node2, new Relation() { Name = "KNOWS" });

            list.ForEach(x=>{

                Console.WriteLine(x.Name);
            });
            


        }

        private static void DeleteRelation()
        {

            Node node1 = WcfProxy<IHexService>.CreateChannel().Get(
                new Node { Label = "Person", Id = "Can" }
                );
            node1.Label = "Person";       
            Node node2 = WcfProxy<IHexService>.CreateChannel().Get(
                new Node { Label = "Person", Id = "JUL" }
                );
            node2.Label = "Person";       
            WcfProxy<IHexService>.CreateChannel().DeleteRelation(
               node1, node2, new Relation() { Name = "HUGS" });

            Console.WriteLine();

        }

        private static void AddRelation()
        {
            Node node1= WcfProxy<IHexService>.CreateChannel().Get(
                new Node { Label = "Person", Id = "Can" }
                );
            node1.Label = "Person";
            Node node2 =WcfProxy<IHexService>.CreateChannel().Get(
                new Node { Label = "Person", Id = "JUL" }
                );
            node2.Label = "Person";
            WcfProxy<IHexService>.CreateChannel().AddRelation(
               node1, node2, new Relation() { Name = "HUGS" });

            Console.WriteLine("Oldu da bitti maşalllah");
        }

        private static void UpdateNode()
        {
            Node oldNode = WcfProxy<IHexService>.CreateChannel().Get(
                new Node { Label ="Person",Id="Can" }
                );
            oldNode.Label = "Person";
            WcfProxy<IHexService>.CreateChannel().Update(
                oldNode ,
                new Node() {Label="Person",Id="Can",Surname="Kaya"}
                );

            Console.WriteLine("Node Deleted is successful.");
        }

        private static void DeleteNode()
        {
            WcfProxy<IHexService>.CreateChannel().Delete(new Node() {Label="Person" ,Id = "Can"});

            Console.WriteLine("Node Deleted is successful.");
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
