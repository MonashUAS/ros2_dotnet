using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.Tools.Algorithmia.Graphs;

namespace GirbalPathfinding
{
    public class Map
    {
        public NonDirectedGraph<State, Edge> graph { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public State startState { get; set; }
        public State goalState { get; set; }
        public double[] htableStatic { get; set; }

        public delegate void StateUpdateHandler(object sender, StateUpdateEventArgs e);

        public event StateUpdateHandler OnGoalUpdate;

        public Map()
        {
            graph = new NonDirectedGraph<State, Edge>();
            height = width = 0;
        }

        public void setGoal(State goalState)
        {
            this.goalState = goalState;

            //
            if (OnGoalUpdate == null) return;
            OnGoalUpdate(this, new StateUpdateEventArgs(goalState));
        }

        public void generateStaticHTable()
        {
        }

        //public void setEdges()
        //{
        //    var allVert = graph.Vertices;
        //    for (int i = 0; i < allVert.Count(); i++)
        //    {
        //        var state = allVert.ElementAt(i);
        //        if (state.x == 1 && state.y == 0)
        //        {
        //            //top right corner
        //        }
        //        else if (state.x == 1 && state.y == 1)
        //        {
        //            //bottom right corner
        //            graph.Add(new Edge(state, allVert.ElementAt(i - width)));
        //        }
        //        else if (state.y == 0)
        //        {
        //            //Top edge
        //            graph.Add(new Edge(state, allVert.ElementAt(i + 1)));
        //            graph.Add(new Edge(state, allVert.ElementAt(i + width + 1)));
        //        }
        //        else if (state.y == 1)
        //        {
        //            //Bottom edge
        //            graph.Add(new Edge(state, allVert.ElementAt(i - width)));
        //            graph.Add(new Edge(state, allVert.ElementAt(i - width + 1)));
        //            graph.Add(new Edge(state, allVert.ElementAt(i + 1)));
        //        }
        //        else if (state.x == 1)
        //        {
        //            //Right edge
        //            graph.Add(new Edge(state, allVert.ElementAt(i - width)));
        //        }
        //        else
        //        {
        //            //Normal
        //            graph.Add(new Edge(state, allVert.ElementAt(i - width)));
        //            graph.Add(new Edge(state, allVert.ElementAt(i - width + 1)));
        //            graph.Add(new Edge(state, allVert.ElementAt(i + 1)));
        //            graph.Add(new Edge(state, allVert.ElementAt(i + width + 1)));
        //        }
        //    }
        //}
    }

    public class StateUpdateEventArgs : EventArgs
    {
        public State newState { get; private set; }

        public StateUpdateEventArgs(State newState)
        {
            this.newState = newState;
        }
    }
}
