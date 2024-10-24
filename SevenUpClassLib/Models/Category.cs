using System.Text.Json.Serialization;

namespace SevenUpClassLib.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        // Relationship one to many
        public List<Product>? Products { get; set; }
    }
}
