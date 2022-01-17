using System;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;

using ROS2;

//Test

namespace ConsoleApplication
{ //needs to be changed right 
    public class RCLDotnetListener
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
            Console.WriteLine("Recieved new positions");
            while (msg.StateArray.Count >= 4)
            {
                arrayLength = msg.StateArray.Count;
                Console.WriteLine("DroneID: " + msg.StateArray[arrayLength - 1]);
                Console.Writeline("x: " + msg.StateArray[arrayLength - 4]);
                Console.Writeline("y: " + msg.StateArray[arrayLength - 3]);
                Console.Writeline("t: " + msg.StateArray[arrayLength - 2]);
            }
        }
    }
}
