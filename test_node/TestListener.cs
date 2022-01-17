using System;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;

using ROS2;

//Test

namespace ConsoleApplication
{ //needs to be changed right 
    public class TestListener
    {
        public static void Main(string[] args)
        {
            RCLdotnet.Init();

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
