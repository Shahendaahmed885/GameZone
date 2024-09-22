namespace GameZone.Models
{
    public class Category:baseentity
    {
        public ICollection<Game> games { get; set; } = new List<Game>();
    }
}
