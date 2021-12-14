using System;
using System.Collections.Generic;
using SD.Tools.Algorithmia.PriorityQueues;
using System.Text;

namespace GirbalPathfinding
{
    public interface IPathPlannable
    {
        List<State> path { get; } // gets the list of states in the path
        List<State> closedList { get; set; }
        SimplePriorityQueue<State> openList { get; set; }

        int id { get; set; }

        State startState { get; set; } 
        State goalState { get; set; }

        bool isFinished { get; set; }

        List<(State, int)> constraints { get; set; }

        List<State> PlanPath(List<(State, int)> newConstraints);

        int pathCost { get; set; }

        void InitialisePathPlanner(Map mp, int[,] staticObs);

    }
}