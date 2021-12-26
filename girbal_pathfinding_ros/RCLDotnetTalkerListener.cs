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

namespace GirbalPathfinding
{
    public class RCLDotnetTalkerListener
    {

        //private ExecutiveController executiveController = new ExecutiveController(300, Globals.noOfAgents, Globals.mapWidth, Globals.mapHeight);

        //need to also input obstacle positions --> do this in Globals?

        public static void Main(string[] args)
        {
            RCLdotnet.Init();

            //-------Publisher------

            INode node_pub = RCLdotnet.CreateNode("publisher");
            IPublisher<girbal_msgs.msg.StateArray> publisher = node_pub.CreatePublisher<girbal_msgs.msg.StateArray>("paths");


            //-------Subscriber------
            //Receive drone starting positions

            INode node_sub = RCLdotnet.CreateNode("subscriber");

            //use StateArray.msg type
            ISubscription<girbal_msgs.msg.StateArray> chatter_sub = node_sub.CreateSubscription<girbal_msgs.msg.StateArray>(
              "current_positions", msg => SubscriberCallback(msg));

            RCLdotnet.Spin(node_sub);
        }

        public void PublishPaths(girbal_msgs.msg.StateArray paths) //how to define msg type?
        {
            //Publish a list of paths

            //List<girbal_msgs.msg.StateArray> msg = new List<girbal_msgs.msg.StateArray>();

            //msg.Data = paths; //path;

            //publisher.Publish(msg);
        }

        public static void SubscriberCallback(girbal_msgs.msg.StateArray msg) //what type do we give this?
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(msg))
            {
                Console.WriteLine(descriptor);
            }
            // State incomingState = new State() { x = msg.X, y = msg.Y, time = msg.Time };
            // msg.States[0]
            // int droneIndex = executiveController.pathPlanners.FindIndex(agent => agent.id == msg.droneId);

            // //agent doesn't already exist in the list
            // if (droneIndex == -1)
            // {
            //     //initialise the agent
            //     AStar newAgent = new AStar(incomingState, Globals.goalStates[msg.droneId], msg.droneId);

            //     executiveController.pathPlanners.Add(newAgent);
            //     newAgent.InitialisePathPlanner(executiveController.map, executiveController.staticObstacles);
            //     droneIndex = 0;

            // }
            // else
            // {
            //     //drone currently has a startstate in the list
            //     //replace the start state with incomingState
            //     //Assuming each state comes individually
            //     executiveController.pathPlanners[droneIndex].startState = incomingState;
            // }

            // //only start planning once we have initialised all the agents
            // if (executiveController.pathPlanners.Count == Globals.noOfAgents)
            // {
            //     //define obstacle positions

            //     //start planning
            //     executiveController.planPath(); //how would we use the previous constraints to make it quicker? 
            // }
        }
    }
}
