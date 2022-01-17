using System;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;

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
            msg.States = new List<int>();

            List<int> droneIds = new List<int>();
            droneIds.Add(4731);
            droneIds.Add(2332);
            droneIds.Add(2901);
            droneIds.Add(8230);
            droneIds.Add(1402);

            int j = 1;

            while (RCLdotnet.Ok())
            {
                msg.States.Clear();  //clear states
                Random rnd = new Random();
                for (int i = 0; i < 5; i++)
                {
                    int x = rnd.Next(1000);
                    msg.States.Add(x);
                    int y = rnd.Next(1000);
                    msg.States.Add(y);
                    int t = j;
                    msg.States.Add(t);
                    int droneId = droneIds[i];
                    msg.States.Add(droneId);
                }
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(msg))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(msg);
                    Console.WriteLine("{0}={1}", name, value);
                }
                j++;
                chatter_pub.Publish(msg);

                // Sleep a little bit between each message
                Thread.Sleep(1000);
            }
        }
    }
}
