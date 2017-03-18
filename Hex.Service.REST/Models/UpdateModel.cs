using Hex.DataTypes.Concrete;
using Newtonsoft.Json;

namespace Hex.Service.REST.Models
{
    class UpdateModel
    {
        [JsonProperty]
        public Node newNode { get; internal set; }
        [JsonProperty]
        public Node oldNode { get; internal set; }
    }
}