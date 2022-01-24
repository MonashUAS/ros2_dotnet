using System;
using System.Collections.Generic;
using System.Linq;

namespace GirbalPathfinding
{
    public static class Globals// global variables for accessing acrross the program
    {
        public static int droneRadius = 1;
        //public static List<State> goalStates = new List<State>(); //droneId: {x, y, time}
        public static Dictionary<int, State> goalStates = new Dictionary<int, State>(); //droneId: State

        public const int mapWidth = 100;
        public const int mapHeight = 50;
        public static int noOfAgents = 4;

    }
}