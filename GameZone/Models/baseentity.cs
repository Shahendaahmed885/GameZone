using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class baseentity
    {
        public int Id { get; set; }

        [MaxLength(length: 250)]
        public string Name { get; set; } = string.Empty;
    }
}
