using System;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Threading;

using ROS2;

namespace ConsoleApplication {
  public class RCLDotnetListener {
    public static void Main (string[] args) {
      RCLdotnet.Init ();

      INode node = RCLdotnet.CreateNode ("listener");

      ISubscription<girbal_msgs.msg.State> chatter_sub = node.CreateSubscription<girbal_msgs.msg.State> (
        "chatter", msg => Console.WriteLine ("I heard: [" + msg.X + "]"));

      RCLdotnet.Spin (node);
    }
  }
}
