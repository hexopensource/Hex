using Hex.Shared;
using System.Collections.Generic;
using Hex.DataTypes.Concrete;
using Hex.DataAccess.Abstract;
using Hex.DataAccess.Concrete;
using System;
using System.Transactions;
using Hex.DataAccess.Abstract.MySQL;
using Hex.DataAccess.Concrete.MySQL;
using Hex.DataTypes.Concrete.MySQLEntity;
using Hex.DataAccess.Concrete.Neo4j;
using Hex.DataAccess.Abstract.Neo4j;

namespace Hex.Server
{
    public class HexService : IHexService
    {
        private readonly INodeRepository _session;
        private readonly IUserRepository _userDal;
        private readonly IPaymentRepository _paymentDal;
        public HexService()
        {
            _session = new NodeRepository();
            _userDal = new UserDal();
        }
        #region NEO4J
        public Node Get(Node node)
        {
            return _session.Get(n => (n.Id == node.Id), node);

        }
        public List<Node> GetList(Node node)
        {
            return _session.GetAll(node);
        }
        public void Add(Node node)
        {
            _session.Add(node);
        }

        public void Update(Node oldNode, Node newNode)
        {
            _session.Update(oldNode, newNode);
        }

        public void Delete(Node node)
        {
            _session.Delete(node);
        }
        public void AddRelation(Node node1, Node node2, Relation relation)
        {
            _session.AddRelation(node1, node2, relation);
        }
        public void DeleteRelation(Node node1, Node node2, Relation relation)
        {
            _session.DeleteRelation(node1, node2, relation);
        }
        public List<Node> GetRelated(Node node1, Node node2, Relation relation)
        {
            return _session.GetRelated(node1, node2, relation);
        }

        public void AddBatch(List<Node> nodes)
        {
            try
            {
                using (var transactionScope = new TransactionScope())
                {
                    nodes.ForEach(x => { _session.Add(x); });
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {

            }
        }
#endregion
        #region MySQL
        public List<User> GetUserList()
        {
           return _userDal.GetAll();
        }
        public User GetUser(string linkedinId)
        {
            return _userDal.Get(x => x.LinkedinId == linkedinId);
        }

        public bool IsRegistered(string linkedinId)
        {
            return _userDal.Get(x => x.LinkedinId == linkedinId) == null ? false : true;
        }
        public void Registration(User user)
        {
            _userDal.Add(user);
        }
        #endregion
    }
}
