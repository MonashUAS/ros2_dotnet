using System;
using System.Collections.Generic;
using System.Text;
using SD.Tools.Algorithmia.GeneralDataStructures;

namespace GirbalPathfinding
{
    public class ExecutiveController
    {
        public List<DynamicObstacle> dynamicObstacles { get; set; }
        public List<StaticObstacle> staticObstacles { get; set; }
        public List<State> stateList { get; set; }
        private List<State> path { get; set; }
        public Map map { get; set; }
        public IPathPlannable pathPlanner { get; set; }
        public int lookahead { get; private set; }

        public ExecutiveController(int lookahead)
        {
            this.lookahead = lookahead;
            dynamicObstacles = new List<DynamicObstacle>();
            staticObstacles = new List<StaticObstacle>();
            map = new Map();
        }

        public void initialisePlanner<TPathPlanner>() where TPathPlanner : IPathPlannable, new()
        {
            pathPlanner = new TPathPlanner();
            pathPlanner.InitialisePathPlanner(map, staticObstacles);
        }

        public int getMapHeight()
        {
            return map.height;
        }

        public int getMapWidth()
        {
            return map.width;
        }

        public void planPath()
        {
            pathPlanner.PlanPath(map.startState);
        }

        public void moveAlongPath()
        {
            map.startState = new State();
            map.startState.setProperties(pathPlanner.path[pathPlanner.path.Count - 1]);
            map.startState.time++;
            advanceDynamics();

            //map.startState = new State();
            //map.startState.setProperties(pathPlanner.path[pathPlanner.path.Count - 2]);
            //map.startState.time++;
            //advanceDynamics();
        }

        public void setMapDimensions(int x, int y)
        {
            map.width = x;
            map.height = y;
        }

        public void advanceDynamics()
        {
            foreach (var obs in dynamicObstacles)
            {
                obs.x = obs.x + obs.speedX;
                obs.y = obs.y + obs.speedY;
            }
        }
    }
}
