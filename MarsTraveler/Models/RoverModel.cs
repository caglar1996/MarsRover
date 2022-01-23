using System.Collections.Generic;

namespace MarsTraveler.Models
{
    public class RoverModel
    {
        public RoverLocationModel location { get; set; }
        public List<char> RouteList { get; set; }
    }
}
