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

namespace Hex.Service.REST.Controllers
{
    public class HexController : ApiController
    {
        HexService _session;
        public HexController()
        {
            _session = new HexService();
        }
            

        [HttpGet]
        public Node Get(string  json)
        {
            Node node =JsonConvert.DeserializeObject<Node>(json);
            return _session.Get(node);

        }
        [HttpGet]
        public List<Node> GetList(string json)
        {
            Node node = JsonConvert.DeserializeObject<Node>(json);
            return _session.GetList(node);
        }

        [HttpPost]
        public void Add([FromBody] string json)
        {
            Node node = JsonConvert.DeserializeObject<Node>(json);
            _session.Add(node);
        }

        [HttpPatch]
        public void Update([FromBody] string oldNodeString, [FromBody]string newNodeString)
        {
            Node oldNode = JsonConvert.DeserializeObject<Node>(oldNodeString);
            Node newNode = JsonConvert.DeserializeObject<Node>(newNodeString);
            _session.Update(oldNode, newNode);
        }

        [HttpDelete]
        public void Delete([FromBody]string json)
        {
            Node node = JsonConvert.DeserializeObject<Node>(json);
            _session.Delete(node);
        }
        [HttpPost]
        public void AddRelation([FromBody] string node1Json, [FromBody] string node2Json, [FromBody] string relationJson)
        {
            Node node1 = JsonConvert.DeserializeObject<Node>(node1Json);
            Node node2 = JsonConvert.DeserializeObject<Node>(node2Json);
            Relation relation = JsonConvert.DeserializeObject<Relation>(relationJson);
            _session.AddRelation(node1, node2, relation);
        }
        [HttpDelete]
        public void DeleteRelation([FromBody]string node1Json, [FromBody]string node2Json, [FromBody] string relationJson)
        {
            Node node1 = JsonConvert.DeserializeObject<Node>(node1Json);
            Node node2 = JsonConvert.DeserializeObject<Node>(node2Json);
            Relation relation = JsonConvert.DeserializeObject<Relation>(relationJson);
            _session.DeleteRelation(node1, node2, relation);
        }
        [HttpGet]
        public List<Node> GetRelated(string node1Json, string node2Json, string relationJson)
        {
            Node node1 = JsonConvert.DeserializeObject<Node>(node1Json);
            Node node2 = JsonConvert.DeserializeObject<Node>(node2Json);
            Relation relation = JsonConvert.DeserializeObject<Relation>(relationJson);
            return _session.GetRelated(node1, node2, relation);
        }


    }
}
