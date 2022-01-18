using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;
using ROS2;
using ROS2.Interfaces;
using ROS2.Utils;

//Test

namespace GirbalPathfinding
{ //needs to be changed right 
    public class CBSCaller
    {

        private ExecutiveController executiveController;
        private const int mapWidth = 60;
        private const int mapHeight = 20;
        private const int noOfAgents = 4;

        private List<State> startStates = new List<State>()
        {
            new State() { x = 15, y = 10},
            new State() { x = 0, y = 25},
            new State() {x = 40, y = 25 },
            new State() {x = 15, y = 40 }

        };

        private List<State> goalStates = new List<State>()
        {
            new State() { x = 55, y= 45},
            new State() { x = 10, y = 8},
            new State() { x = 20, y = 30},
            new State() {x = 40, y = 30 }

        };

        public static void Main(string[] args)
        {
            RCLdotnet.Init();

            executiveController = new ExecutiveController(300, noOfAgents, mapWidth, mapHeight);

            INode node = RCLdotnet.CreateNode("listener");

            ISubscription<girbal_msgs.msg.StateArray> chatter_sub = node.CreateSubscription<girbal_msgs.msg.StateArray>(
              "current_positions", msg => ProccessData(msg));

            RCLdotnet.Spin(node);
        }

        public static void ProccessData(girbal_msgs.msg.StateArray msg)
        {
            int dronesLeft = msg.Number_of_drones;
            Console.WriteLine("Recieved new positions");
            while (dronesLeft > 0)
            {
                Console.WriteLine("DroneID: " + msg.States[dronesLeft * 4 - 1]);
                Console.WriteLine("x: " + msg.States[dronesLeft * 4 - 4]);
                Console.WriteLine("y: " + msg.States[dronesLeft * 4 - 3]);
                Console.WriteLine("t: " + msg.States[dronesLeft * 4 - 2]);
                dronesLeft--;
            }
        }
    }
}
