using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SuperHeroAPI.Data
{
    public class EvilCarater
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        [ForeignKey("SuperHero")]
        public int? SuperHeroId { get; set; }
        [JsonIgnore]
        public SuperHero SuperHero { get; set; }
    }
}
