using Hex.DataAccess.Abstract;
using Hex.DataTypes.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.DataTypes.Concrete;
using Neo4jClient;
using System.Linq.Expressions;

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

            return _client.Cypher
                .Match("(n:" + node.Label + ")")
                .Where(query)
                .Return(n => n.As<Node>())
                .Results.SingleOrDefault();
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
        public void Update(Node node)
        {

        }

        public void Delete(Node node)
        {
            throw new NotImplementedException();
        }





        public List<Node> GetRelated(System.Linq.Expressions.Expression<Func<Node, bool>> query1, System.Linq.Expressions.Expression<Func<Node, bool>> query2, Relation relation)
        {
            throw new NotImplementedException();
        }

        public Tuple<Node, Node> GetRelations(System.Linq.Expressions.Expression<Func<Node, bool>> query1, System.Linq.Expressions.Expression<Func<Node, bool>> query2, Relation relation)
        {
            throw new NotImplementedException();
        }

        public void AddRelation(System.Linq.Expressions.Expression<Func<Node, bool>> query1, System.Linq.Expressions.Expression<Func<Node, bool>> query2, Relation relation)
        {
            throw new NotImplementedException();
        }
        public void DeleteRelation(System.Linq.Expressions.Expression<Func<Node, bool>> query1, System.Linq.Expressions.Expression<Func<Node, bool>> query2, Relation relation)
        {
            throw new NotImplementedException();
        }
    }
}
