using System;
using System.Collections.Generic;
using System.Text;

namespace GirbalPathfinding
{
    public interface IPathPlannable
    {
        List<State> path { get; }
        List<State> lookaheadRegion { get; }

        List<State> PlanPath(State requestStart);

        void InitialisePathPlanner(Map mp, List<StaticObstacle> staticObs);
    }
}
