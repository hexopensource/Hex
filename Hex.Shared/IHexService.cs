using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Hex.DataTypes.Concrete;
using System.Linq.Expressions;
using Hex.DataTypes.Abstract;

namespace Hex.Shared
{
    [ServiceContract()]
    public interface IHexService
    {
        
        [OperationContract()]        
        Node Get(Node node);

        [OperationContract()]
        List<Node> GetList(Node node);

        [OperationContract()]
        void Add(Node node);

        [OperationContract()]
        void Update(Node node);

        [OperationContract()]
        void Delete(Node node);


    }
}
