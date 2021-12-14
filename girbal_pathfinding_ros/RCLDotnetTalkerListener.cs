using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;
using ROS2;
using ROS2.Interfaces;

namespace GirbalPathfinding
{
    public class RCLDotnetTalkerListener
    {

        //private ExecutiveController executiveController = new ExecutiveController(300, Globals.noOfAgents, Globals.mapWidth, Globals.mapHeight);

        //I'm defining the publisher outside of Main to be able to access it inside of PublishPaths().. is this the correct way to do it?
        IPublisher<girbal_msgs.msg.StateArray> publisher;
        INode node_pub;


        //need to also input obstacle positions --> do this in Globals?

        public static void Main(string[] args)
        {
            RCLdotnet.Init();

            //-------Publisher------

            node_pub = RCLdotnet.CreateNode("publisher");
            publisher = node_pub.CreatePublisher<girbal_msgs.msg.StateArray>("paths");


            //-------Subscriber------
            //Receive drone starting positions

            INode node_sub = RCLdotnet.CreateNode("subscriber");

            //use State.msg type
            ISubscription<girbal_msgs.msg.StateArray> chatter_sub = node_sub.CreateSubscription<girbal_msgs.msg.StateArray>(
              "current_positions", msg => SubscriberCallback(msg.States));

            RCLdotnet.Spin(node_sub);
        }

        public void PublishPaths(girbal_msgs.msg.StateArray paths) //how to define msg type?
        {
            //Publish a list of paths

            List<girbal_msgs.msg.StateArray> msg = new List<girbal_msgs.msg.StateArray>();

            msg.Data = paths; //path;

            publisher.Publish(msg);
        }

        public void SubscriberCallback(girbal_msgs.msg.StateArray msg) //what type do we give this?
        {
            foreach (girbal_msgs.msg.State state in msg.States)
            {
                Console.WriteLine(state);
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
