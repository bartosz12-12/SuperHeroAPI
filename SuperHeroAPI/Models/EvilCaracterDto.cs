namespace SuperHeroAPI.Models
{
    public class EvilCaracterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; } = string.Empty;
        public int? SuperHeroId { get; set; }

    }
}
