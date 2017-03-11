using Hex.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.DataTypes.Concrete;
using Hex.DataAccess.Abstract;
using Hex.DataAccess.Concrete;
using Hex.DataTypes.Abstract;
using System.Linq.Expressions;

namespace Hex.Server
{
    public class HexService : IHexService
    {        
        private readonly INodeRepository _session;
        public HexService()
        {            
            _session = new NodeRepository();
        }      

        public Node Get(Node node)
        {
            return _session.Get(n => (n.Id == node.Id),node);
        }
        public List<Node> GetList(Node node)
        {
            return _session.GetAll(node);
        }
        public void Add(Node node)
        {
            _session.Add(node);
        }

        public void Update(Node oldNode,Node newNode)
        {
            _session.Update(oldNode,newNode);
        }

        public void Delete(Node node)
        {
            _session.Delete(node);
        }
        public void AddRelation(Node node1, Node node2, Relation relation)
        {
            _session.AddRelation(node1,node2,relation);
        }
    }
}
