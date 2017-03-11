using Hex.DataTypes.Abstract;
using Hex.DataTypes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hex.DataAccess.Abstract
{
    public interface INodeRepository
    {
        List<Node> GetAll(Node node,Expression<Func<Node, bool>> query=null);
        Node Get(Expression<Func<Node, bool>> query, Node node);
        void Add(Node node);
        void Update(Node node);
        void Delete(Node node );
        void AddRelation(Expression<Func<Node, bool>> query1, Expression<Func<Node, bool>> query2, Relation relation);
        void DeleteRelation(Expression<Func<Node, bool>> query1, Expression<Func<Node, bool>> query2, Relation relation);
        List<Node> GetRelated(Expression<Func<Node, bool>> query1, Expression<Func<Node, bool>> query2, Relation relation);
        Tuple<Node, Node> GetRelations(Expression<Func<Node, bool>> query1, Expression<Func<Node, bool>> query2, Relation relation);    


    }
}
