

namespace GameZone.Models
{
    public class Game: baseentity
    {
        [MaxLength(length: 2500)]
        public string description { get; set; } = string.Empty;


        [MaxLength(length: 500)]
        public string cover { get; set; } = string.Empty;

        public int categoryid { get; set; }

        public Category category { get; set; } = default!;
        public ICollection<Gamedevices> devices { get; set; } = new List<Gamedevices>();


    }
}
