using System;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;

using ROS2;
using ROS2.Utils;

namespace ConsoleApplication
{
    public class RCLDotnetTalker
    {
        public static void Main(string[] args)
        {
            RCLdotnet.Init();

            INode node = RCLdotnet.CreateNode("talker");

            IPublisher<girbal_msgs.msg.State> chatter_pub = node.CreatePublisher<girbal_msgs.msg.State>("chatter");

            girbal_msgs.msg.State msg = new girbal_msgs.msg.State();

            int i = 1;

            while (RCLdotnet.Ok())
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(msg))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(msg);
                    Console.WriteLine("{0}={1}", name, value);
                }
                msg.X = i;
                i++;
                Console.WriteLine("Publishing: \"" + msg.X + "\"");
                chatter_pub.Publish(msg);

                // Sleep a little bit between each message
                Thread.Sleep(1000);
            }
        }
    }
}
