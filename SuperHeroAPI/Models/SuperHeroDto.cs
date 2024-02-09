namespace SuperHeroAPI.Models
{
    public class SuperHeroDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirtsName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
