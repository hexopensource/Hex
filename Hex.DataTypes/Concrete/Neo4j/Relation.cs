using Newtonsoft.Json;

namespace Hex.DataTypes.Concrete
{
    public class Relation
    {
        public Relation()
        {
        }
        [JsonProperty]
        public string Name { get; set; }
    }
}