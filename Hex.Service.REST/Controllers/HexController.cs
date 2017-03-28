using Hex.DataTypes.Abstract;
using Hex.DataTypes.Concrete;
using Hex.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft;
using Newtonsoft.Json;
using Hex.Service.REST.Models;
using Newtonsoft.Json.Linq;
using System.Data;
using Hex.DataTypes.Concrete.MySQLEntity;

namespace Hex.Service.REST.Controllers
{
    public class HexController : ApiController
    {
        HexService _session;
        public HexController()
        {
            _session = new HexService();
        }
            

        [HttpPost]
        public Node Get([FromBody]object nodeJson)
        {           
           Node node =JsonConvert.DeserializeObject<Node>(nodeJson.ToString());
           return _session.Get(node);

        }
        [HttpPost]
        public List<Node> GetList([FromBody]object nodeJson)
        {
            
            Node node = JsonConvert.DeserializeObject<Node>(nodeJson.ToString());
            return _session.GetList(node);
        }

        [HttpPost]
        public void Add([FromBody] object nodeJson)
            {
            Node node = JsonConvert.DeserializeObject<Node>(nodeJson.ToString());
            _session.Add(node);
        }

        [HttpPost]
        public void AddBatch([FromBody] List<Node> nodes)
        {
            _session.AddBatch(nodes);
        }

        [HttpPost]
        public void Update([FromBody] object jsonBodyObject)
        {
            UpdateModel model= JsonConvert.DeserializeObject<UpdateModel>(jsonBodyObject.ToString());
            _session.Update(model.oldNode, model.newNode);
        }

        [HttpPost]
        public void Delete([FromBody]object nodeJson)
        {
            Node node = JsonConvert.DeserializeObject<Node>(nodeJson.ToString());
            _session.Delete(node);
        }
        [HttpPost]
        public void AddRelation([FromBody] object jsonBodyObject)
        {

            RelationModel model = JsonConvert.DeserializeObject<RelationModel>(jsonBodyObject.ToString());
            _session.AddRelation(model.node1, model.node2, model.relation);
            
        }
        [HttpPost]
        public void DeleteRelation([FromBody]object jsonBodyObject)
        {

            RelationModel model = JsonConvert.DeserializeObject<RelationModel>(jsonBodyObject.ToString());
            _session.DeleteRelation(model.node1, model.node2, model.relation);
        }
        [HttpPost]
        public List<Node> GetRelated([FromBody] object jsonBodyObject)
        {           
            RelationModel model = JsonConvert.DeserializeObject<RelationModel>(jsonBodyObject.ToString());            
            return _session.GetRelated(model.node1, model.node2, model.relation);
        }

        [HttpGet]
        public DataTable GetQuery(string query)
        {
            return null;
        }

        [HttpGet]
        public List<User> GetUserList()
        {
            return _session.GetUserList();
        }
        [HttpGet]
        public User GetUser(string linkedinId)
        {
            return _session.GetUser(linkedinId);
        }
        [HttpGet]
        public bool IsRegistered(string linkedinId)
        {
            return _session.IsRegistered(linkedinId);
        }
        [HttpPost]
        public void Registration([FromBody]User user)
        {
            _session.Registration(user);
        }

    }
}
