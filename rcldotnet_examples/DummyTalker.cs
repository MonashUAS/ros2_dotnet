using System;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;

using ROS2;
using ROS2.Utils;


/* This Talker is intened to act as a tester as the thread network is likely not going to be completely ready  for testing*/ 
namespace ConsoleApplication { //namespace needs changing right 
  public class DummyTalker {
    public static void Main (string[] args) {
      RCLdotnet.Init ();

      INode node = RCLdotnet.CreateNode ("talker");

      IPublisher<girbal_msgs.msg.StateArray> chatter_pub = node.CreatePublisher<girbal_msgs.msg.StateArray> ("chatter");

      girbal_msgs.msg.StateArray msg = new girbal_msgs.msg.StateArray (); //create the data 

      int i = 1;

      while (RCLdotnet.Ok ()) {
        foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(msg))
          {
              string name = descriptor.Name; //what does this do?
              object value = descriptor.GetValue(msg);
              Console.WriteLine("{0}={1}", name, value); //not needed?
          }
        msg.X = i; //raw data needs to be entered here 
        i++;
        Console.WriteLine ("Publishing: \"" + msg.X + "\"");
        chatter_pub.Publish (msg); //publishing here

        // Sleep a little bit between each message
        Thread.Sleep (1000);
      }
    }
  }
}
