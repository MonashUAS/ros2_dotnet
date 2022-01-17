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

            ISubscription<girbal_msgs.msg.State> chatter_sub = node.CreateSubscription<girbal_msgs.msg.State>(
              "chatter", msg => Console.WriteLine("I heard: [" + msg.X + "]")); //replace console.Writeline with RecieveNewValues
                                                                                //uses chatter channel

            RCLdotnet.Spin(node);
        }

        /*    public void RecieveNewValues (int data [,])
                {
                    for (int i = 0, i< Globals.noOfAgents, i++) // assigns data
                    {
                        //Globals.droneLocations[i].x = data[i,0];
                        //Globals.droneLocations[i].y = data[i,1];
                        //Gloabls.droneLocations[i].z = data[i,3];
                        //Globals.droneLocations[i].time = data[i,2]; // needed to keep swarm in sync
                    }
                    //call run program method (is there a file for this?)
                    //at end of this the access RCLDotnetTalker.Main to publish data out to nodes 
                }
                */
    }
}
