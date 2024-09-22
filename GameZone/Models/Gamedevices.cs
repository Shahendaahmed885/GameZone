

namespace GameZone.Models
{
    public class Gamedevices 
        
    {


        public int gameid { get; set; }
        public Game game { get; set; } = default!;

        public int devicesid { get; set; }
        public Devices devices { get; set; } = default!;


       

    }
}
