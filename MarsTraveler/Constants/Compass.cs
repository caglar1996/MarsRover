using MarsTraveler.Models;
using System.Collections.Generic;

namespace MarsTraveler.Constants
{
    public static class Compass
    {
        public static List<CompassDirectionsModel> DirectionsList = new List<CompassDirectionsModel>()
        {
            // Nort
            new CompassDirectionsModel(){
                CurrentlyDirection='N',
                LeftShift='W',
                RightShift='E'
            },
            // East
            new CompassDirectionsModel(){
                CurrentlyDirection='E',
                LeftShift='N',
                RightShift='S'
            },
            // South
            new CompassDirectionsModel(){
                CurrentlyDirection='S',
                LeftShift='E',
                RightShift='W'
            },
            // West
            new CompassDirectionsModel(){
                CurrentlyDirection='W',
                LeftShift='S',
                RightShift='N'
            }
        };
    }
}
