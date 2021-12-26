using System;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;

using ROS2;
using ROS2.Utils;
using ROS2.Interfaces;

namespace ConsoleApplication
{
    public class RCLDotnetTalker
    {
        public static void Main(string[] args)
        {
            RCLdotnet.Init();

            INode node = RCLdotnet.CreateNode("talker");

            IPublisher<girbal_msgs.msg.StateArray> chatter_pub = node.CreatePublisher<girbal_msgs.msg.StateArray>("current_positions");

            girbal_msgs.msg.StateArray msg = new girbal_msgs.msg.StateArray();

            girbal_msgs.msg.State[] states = new girbal_msgs.msg.State[5];

            uint[] droneids = new uint[] { 4582, 1067, 2063, 7028, 3962 };

            uint j = 1;

            while (RCLdotnet.Ok())
            {
                Array.Clear(states, 0, states.Length);
                Random rnd = new Random();

                for (int i = 0; i < 5; i++)
                {
                    girbal_msgs.msg.State newState = new girbal_msgs.msg.State();
                    newState.X = rnd.Next(1000);
                    newState.Y = rnd.Next(1000);
                    newState.T = j;
                    newState.Droneid = droneids[i];
                    states[i] = newState;
                }
                Console.WriteLine("Am I working?");
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(msg))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(msg);
                    Console.WriteLine("{0}={1}", name, value);
                }
                //msg.States = states;
                j++;
                chatter_pub.Publish(msg);

                // Sleep a little bit between each message
                Thread.Sleep(1000);
            }
        }
    }
}
