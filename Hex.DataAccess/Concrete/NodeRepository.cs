using Hex.DataAccess.Abstract;
using Hex.DataTypes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Neo4jClient;
using System.Linq.Expressions;
using Hex.DataAccess.Helper;

using Newtonsoft;
using Neo4jClient.Transactions;
using System.Transactions;

namespace Hex.DataAccess.Concrete
{
    public class NodeRepository : INodeRepository       
    {
        protected readonly GraphClient _client;
        public NodeRepository()
        {
            _client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "fermat68");           
            _client.Connect();
        }

        public Node Get(Expression<Func<Node, bool>> query,Node node)
        {
            
                IEnumerable<Node> listNode= _client.Cypher
                .Match("(n:" + node.Label + ")")
                .Where(query)
                .Return(n => n.As<Node>())
                .Results;
            return listNode.FirstOrDefault(); 
        }

        public List<Node> GetAll(Node node,Expression<Func<Node, bool>> query = null)
        {            
            return _client.Cypher
                .Match("(n:" + node.Label + ")")
                .Return(n => n.As<Node>())
                .Results.ToList();
        }

        public void Add(Node node)
        {
            if (node == null) return;   
            _client.Cypher
               .Create("(n:" + node.Label + " {node})")
               .WithParam("node", node)
               .ExecuteWithoutResults();
        }
        public void Update(Node oldNode,Node newNode)
        {

            DataHelper.CopyValues(oldNode, newNode);              
            _client.Cypher
               .Match("(n:" + oldNode.Label + ")")
               .Where((Node n)=>n.Id==oldNode.Id)
               .Set("n"+" = {item}")
               .WithParam("item", oldNode)
               .ExecuteWithoutResults();

        }

        public void Delete(Node node)
        {           
            _client.Cypher
                .Match("(n:" + node.Label + ")")
                .Where((Node n)=>n.Id==node.Id)
                .Delete("n")
                .ExecuteWithoutResults();
        }

        
        public List<Node> GetRelated(Node node1,Node node2,Relation relation)
        {
            try
            {
                return _client.Cypher
               .Match("(n1:" + node1.Label + ") -[:" + relation.Name + "]->(n2:"+node2.Label+")")
                 .Where((Node n1) => n1.Id == node1.Id)           
                 .Return(n2 => n2.As<Node>())
                 .Results.ToList();
            }
            catch (Exception ex)
            {
               
                throw;
            }
           
        }

        public Tuple<Node, Node> GetRelations(System.Linq.Expressions.Expression<Func<Node, bool>> query1, System.Linq.Expressions.Expression<Func<Node, bool>> query2, Relation relation)
        {
            throw new NotImplementedException();
        }

        public void AddRelation(Node node1, Node node2,  Relation relation)
        {           
            _client.Cypher
                .Match("(n:" + node1.Label + ")", "(o:" + node2.Label + ")")
                .Where((Node n)=>n.Id==node1.Id)
                .AndWhere((Node o)=>o.Id==node2.Id)
                .CreateUnique("(n)" + "-[:" + relation.Name + " {r}]->" + "(o)")
                .WithParam("r", relation)
                .ExecuteWithoutResults();
        }
        public void DeleteRelation(Node node1, Node node2, Relation relation)
        {
            
                 _client.Cypher
                .Match("(n1:" + node1.Label + ")-[r:" + relation.Name + "]->(n2:" + node2.Label + ")")
                .Where((Node n1) => n1.Id == node1.Id)
                .AndWhere((Node n2) => n2.Id == node2.Id)
                .Delete("r")
                .ExecuteWithoutResults();
           
           
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
