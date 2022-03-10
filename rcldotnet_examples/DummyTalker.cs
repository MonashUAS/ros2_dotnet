using System;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;

using ROS2;
using ROS2.Utils;


// This Talker is intened to act as a tester as the thread network is likely not going to be completely ready  for testing*/ 
namespace ConsoleApplication
{
    public class DummyTalker
    {
        private bool start = true;
        private const int numDrones = 5;
        private int[,] startSet = new int[3, numDrones];
        public int mapHieght = 60;
        public int mapWidth = 50;
        Random rnd = new Random();

        for(int i=0; i<numDrones; i++) 
            {
           startSet[1, i] = rnd.Next(1,mapHieght);
                startSet[2, i] = rnd.Next(1,mapWidth);
            }
            
            
                
            
        public static void Main(string[] args)
        {
            RCLdotnet.Init();

            INode node = RCLdotnet.CreateNode("talker");

            IPublisher<girbal_msgs.msg.StateArray> chatter_pub = node.CreatePublisher<girbal_msgs.msg.StateArray>("chatter");

            girbal_msgs.msg.StateArray msg = new girbal_msgs.msg.StateArray(); //create the data 

            int i = 1;

            while (RCLdotnet.Ok()) {
                if (start) 
                {
                    string name = descriptor.Name;
                //set random start states
                 }
            
            else { 

                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(msg)) { 
             
                string name = descriptor.Name; //what does this do?
                object value = descriptor.GetValue(msg);
                Console.WriteLine("{0}={1}", name, value); //not needed?
                }
            }
          msg.X = i; //raw data needs to be entered here 
          i++;
          Console.WriteLine("Publishing: \"" + msg.X + "\"");
          chatter_pub.Publish(msg); //publishing here

          // Sleep a little bit between each message
          Thread.Sleep(1000);
            }
      
        }
    }
}