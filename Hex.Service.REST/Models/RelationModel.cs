using Hex.DataTypes.Abstract;
using Hex.DataTypes.Concrete;
using Newtonsoft.Json;

namespace Hex.Service.REST.Models
{
    class RelationModel
    {
        [JsonProperty]
        public Node node1 { get; internal set; }
        [JsonProperty("node2")]// if you want you can give name to 
        public Node node2 { get; internal set; }
        [JsonProperty("relation")]
        public Relation relation { get; internal set; }
    }
}