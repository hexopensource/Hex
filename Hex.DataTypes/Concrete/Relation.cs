using Newtonsoft.Json;

namespace Hex.DataTypes.Concrete
{
    public class Relation
    {
        public Relation()
        {
        }
        [JsonIgnore]
        string Name { get; set; }
    }
}