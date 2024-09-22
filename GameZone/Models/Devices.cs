

namespace GameZone.Models
{
    public class Devices: baseentity
    {
        [MaxLength(length: 50)]
        public string icon { get; set; }

    }
}
