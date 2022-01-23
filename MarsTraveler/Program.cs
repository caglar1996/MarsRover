using MarsRover.Models;
using MarsTraveler.Constants;
using MarsTraveler.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Input:");
            List<RoverModel> roverList = new List<RoverModel>();
            int[,] plateuMatris = CreatePlateuMatris(Console.ReadLine().Trim());

            if (plateuMatris == null)
                return;

            while (true)
            {
                RoverLocationModel locationModel = ParseRoverLocation(Console.ReadLine().Trim());

                List<char> routeList = ParseRoute(Console.ReadLine().Trim().ToUpper());

                roverList.Add(new RoverModel() { location = locationModel, RouteList = routeList });

                // 2 rover ekledikten sonra, başka eklemek istiyor musunuz diye soruyor
                if (roverList.Count >= 2 && roverList.Count % 2 == 0)
                {
                    Console.WriteLine("Do you want to add another rover ? Y/N");
                    char otherInput = Console.ReadLine().Trim().ToUpper()[0];
                    if (otherInput == 'N')
                        break;
                }
            }

            Console.WriteLine("Output:");
            foreach (var rover in roverList)
            {
                RoverDiscovery(rover);
                Console.WriteLine(rover.location.X + " " + rover.location.Y + " " + rover.location.Direction);
            }
            Console.Read();
        }

        /// <summary>
        /// Plato Matrisini gelen input string verisini pars ederek oluşturur
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[,] CreatePlateuMatris(string input)
        {
            if (input.Length == 3)
            {
                var matrisModel = new PlateauMatrisModel();
                matrisModel.EndX = Convert.ToInt16(input.Split(' ')[0]);
                matrisModel.EndY = Convert.ToInt16(input.Split(' ')[1]);

                return new int[matrisModel.EndX, matrisModel.EndY];
            }
            return null;
        }

        /// <summary>
        /// Rover konumunu X  Y N gelen string input verisini modele parse eder
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static RoverLocationModel ParseRoverLocation(string input)
        {
            if (input.Length == 5)
            {
                var locationModel = new RoverLocationModel();
                locationModel.X = Convert.ToInt16(input.Split(' ')[0]);
                locationModel.Y = Convert.ToInt16(input.Split(' ')[1]);
                locationModel.Direction = input.Split(' ')[2].ToCharArray()[0];

                return locationModel;
            }
            return default;
        }

        /// <summary>
        /// Input olarak gelen gezgin route, char listesine çevirir
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<char> ParseRoute(string input)
        {
            List<char> routeList = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                routeList.Add(input[i]);
            }
            return routeList;
        }

        /// <summary>
        /// Gezginin bulunduğu konum ve Rote Listesini alır ver keşif işlemi yapılır.
        /// *List pointer üzerinden işlem yaptığı için tekrar modeli dönmemize gerek yok. O yüzden RoverDiscovery fonsiyonu void
        /// </summary>
        /// <param name="locationModel"></param>
        /// <param name="roteList"></param>
        public static void RoverDiscovery(RoverModel rover)
        {
            foreach (char route in rover.RouteList)
            {
                switch (route)
                {
                    case 'L':
                        rover.location.Direction = Compass.DirectionsList.First(x => x.CurrentlyDirection == rover.location.Direction).LeftShift;
                        break;
                    case 'R':
                        rover.location.Direction = Compass.DirectionsList.First(x => x.CurrentlyDirection == rover.location.Direction).RightShift;
                        break;
                    case 'M':
                        rover.location = RoverMove(rover.location);
                        break;
                }
            }            
        }
        /// <summary>
        /// Rover Move
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private static RoverLocationModel RoverMove(RoverLocationModel location)
        {
            switch (location.Direction)
            {
                case 'N':
                    location.Y += 1;
                    break;
                case 'W':
                    location.X -= 1;
                    break;
                case 'S':
                    location.Y -= 1;
                    break;
                case 'E':
                    location.X += 1;
                    break;
            }
            return location;
        }
    }
}
