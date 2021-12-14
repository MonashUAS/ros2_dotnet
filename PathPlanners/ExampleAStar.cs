using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.Tools.Algorithmia.PriorityQueues;

namespace GirbalPathfinding
{
    internal class ExampleAStar : IPathPlannable
    {
        private List<StaticObstacle> staticObstacles;
        private List<State> stateList;
        private Map map;
        private List<double> hTableStatic;

        private double herr, qtime_avg;

        private SimplePriorityQueue<State> globalOpenList;
        private SimplePriorityQueue<State> goalQueue;

        private Comparison<State> comparisonF_n = new Comparison<State>((item2, item1) => item1.comparisonFhat - item2.comparisonFhat);

        public List<State> lookaheadRegion { get => globalClosedList; }

        public List<State> globalClosedList { get; set; }
        public double Collision_cost { get; private set; }
        public List<State> path { get; set; }

        public ExampleAStar()
        {
            path = new List<State>();

            globalOpenList = new SimplePriorityQueue<State>(comparisonF_n);
            goalQueue = new SimplePriorityQueue<State>(comparisonF_n);

            globalClosedList = new List<State>();
            Collision_cost = 1000;
        }

        public void InitialisePathPlanner(Map mp, List<StaticObstacle> staticObs)
        {
            staticObstacles = staticObs;
            stateList = new List<State>();
            map = mp;
            map.OnGoalUpdate += UpdateGoal;

            hTableStatic = new List<double>(map.width * map.height);
        }

        public List<State> PlanPath(State requestStart)
        {
            path.Clear();
            AStarSearch(requestStart);

            if (globalOpenList.Count == 0)
                return null;

            var sgoal = PickBestState();
            var state = sgoal;

            while (state != map.startState)
            {
                state.tempc = state.cost_d;
                path.Add(state);
                state = state.parent;
            }

            return path;
        }

        public int AStarSearch(State startState)
        {
            var currentState = startState;

            //Go through all states and prune/set starting
            foreach (var state in stateList.ToList())
            {
                //Time has passed, delete it
                if (state.time < startState.time)
                {
                    stateList.Remove(state);
                }
                else
                {
                    //apply heuristic decay
                    state.h_s = hTableStatic[TransformCoordToIndex(state.x, state.y)];

                    //reset costs to inf
                    state.cost_s = state.cost_d = double.MaxValue;

                    state.generateComparisonFhat();
                }
            }
            //return 0;

            //clear open/close
            globalOpenList.Clear();
            var openCheck = new List<State>(stateList.Count);
            globalClosedList.Clear();

            //Set start state to 0/defaults
            startState.cost_d = 0;
            startState.cost_s = 0;
            startState.depth = 0;
            startState.qtime = 0;

            startState.h_s = hTableStatic[TransformCoordToIndex(startState.x, startState.y)];
            startState.generateComparisonFhat();

            //startState.heading = initialHeading;

            long temp_qtime_sum = 0;
            double temp_accumulate_heuristic = 0;

            int expansions = 0;

            //push start into open then start expanding
            globalOpenList.Add(startState);
            openCheck.Add(startState);
            double hsum = 0;

            do
            {
                var state = globalOpenList.Remove();

                state.f_c = state.cost_d + state.h_s;
                state.generateComparisonFhat();
                temp_qtime_sum += expansions - state.qtime;
                temp_accumulate_heuristic += state.h_d + state.h_s;

                globalClosedList.Add(state);
                openCheck.Remove(state);
                expansions++;
                State bestChild = null;
                State dummyState = new State();

                //Calculate dynamic cost for all nearby nodes
                //double[,] dCosts = new double[3, 3];

                //Goto all nearby nodes
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        //find child state
                        var childState = stateList.Find((st) => st.x == state.x + i && st.y == state.y + j && st.time == state.time + 1);

                        //check to make sure it isnt a static obstacle
                        if (!(childState is null) && childState.checkIfStaticObstacle(staticObstacles))
                            continue;
                        //Check object exists and is not on closed list
                        if (childState is null || !globalClosedList.Exists(st => childState.Equals(st)))
                        {
                            //If state does not exist then make it
                            if (childState is null)
                            {
                                childState = new State();
                                //Set properties and if not valid, continue
                                if (!childState.setProperties(state.x + i, state.y + j, state.time + 1, map.width, map.height))
                                    continue;

                                //Set other properties
                                childState.cost_d = double.MaxValue;
                                childState.cost_s = double.MaxValue;
                                childState.h_s = 0;
                                childState.h_d = 0;
                                childState.frontier_time = state.time + 1;

                                //Set max yaw rate
                                //double dHeading =
                                //childState.headingAv =
                                childState.generateComparisonFhat();

                                CreatePredecessors(childState, state.time);
                                stateList.Add(childState);
                            }

                            //Check to see if this is the goal
                            if (childState.positionEqual(map.goalState))
                                return 0;

                            childState.h_s = hTableStatic[TransformCoordToIndex(childState.x, childState.y)];
                            childState.generateComparisonFhat();
                            double scost = state.cost_s + staticCost(state, childState);

                            //Check if child costs are larger than calculated costs and if so, set the correct costs
                            //Debug.WriteLine("");
                            //Debug.WriteLine("{0}, {1}, {2}, {3},", childState.cost_s, childState.cost_d, scost, dcost);
                            if (childState.cost_s + childState.cost_d > scost)
                            {
                                //Debug.WriteLine("hit");
                                childState.cost_s = scost;
                                childState.cost_d = 0;
                                childState.parent = state;
                                childState.depth = state.depth + 1;
                                childState.h_err = 0;

                                //Set heading for uav dynamics
                                //childState.headingAv = state.headingAv + newHeadingFactor * DHeadingFromCoord(i, j, state.headingAv);
                                //childState.headingDAv = newHeadingFactor * Math.Abs(DHeadingFromCoord(i, j, state.headingAv)) + oldHeadingFactor * state.headingDAv;
                                //childState.headingAv = DHeadingFromCoord(i, j, 0);

                                childState.cost_turning = 0;

                                childState.generateComparisonFhat();

                                //add to open list if it's not on there
                                if (!openCheck.Contains(childState))
                                {
                                    globalOpenList.Add(childState);
                                    openCheck.Add(childState);
                                    childState.qtime = expansions;
                                }
                                else
                                {
                                    //Move childstate up openlist to qindex
                                }
                            }
                            //Debug.WriteLine("{0}, {1}, {2}, {3},", childState.cost_s, childState.cost_d, scost, dcost);
                        }
                        //Set best child
                        if (bestChild is null || bestChild.f_static() > childState.f_static())
                            bestChild = childState;
                    }
                }
                //foreach (var lestate in stateList)
                //{
                //    if (lestate.cost_s > 100)
                //    {
                //        Debug.WriteLine("{0}, {1}", lestate.cost_s, lestate.cost_d);
                //    }
                //}
                if (!(bestChild is null))
                {
                    double fdiff = bestChild.f_static() - state.f_static();
                    fdiff = (fdiff < 0) ? 0 : fdiff;
                    hsum += fdiff;
                }
            } while (globalOpenList.Count != 0);

            herr = hsum / expansions;
            qtime_avg = temp_qtime_sum / expansions;
            //accumulate_heuristic = temp_accumulate_heuristic;

            return 0;
        }

        public void UpdateGoal(object obj, StateUpdateEventArgs e)
        {
            //create a static lookup table to speed up creation
            bool[] staticObstacleLUT = Enumerable.Repeat(false, map.height * map.width).ToArray();
            //staticObstacleLUT.AddRange(Enumerable.Repeat(false, map.height * map.width));
            hTableStatic.AddRange(Enumerable.Repeat(0d, map.height * map.width));
            //d_errTable.AddRange(Enumerable.Repeat(0d, map.height * map.width));
            //dTable.AddRange(Enumerable.Repeat(0d, map.height * map.width));
            foreach (var obs in staticObstacles)
            {
                staticObstacleLUT[TransformCoordToIndex(obs.x, obs.y)] = true;
            }

            //var kernel = accelerator.LoadAutoGroupedStreamKernel<Index2, ArrayView2D<double>, int, int>(InitUpdateLUTKernel);
            //var staticObsKernel = accelerator.LoadAutoGroupedStreamKernel<Index2, ArrayView2D<double>, ArrayView2D<int>>(SetStaticMaxFromLUT);

            //using (var distanceBuffer = accelerator.Allocate<double>(map.width, map.height))
            //using (var staticObsLutBuffer = accelerator.Allocate<int>(map.width, map.height))
            //{
            //    staticObsLutBuffer.CopyFrom(staticObstacleLUT, 0, LongIndex2.Zero, map.width * map.height);
            //    //Array.Copy(staticObstacleLUT, , map.width*map.height);

            //    kernel(distanceBuffer.Extent, distanceBuffer.View, map.goalState.x, map.goalState.y);
            //    staticObsKernel(distanceBuffer.Extent, distanceBuffer.View, staticObsLutBuffer.View);
            //    accelerator.Synchronize();

            //    // Resolve data
            //    var data = distanceBuffer.GetAsArray();
            //    hTableStatic.AddRange(data);
            //    d_errTable.AddRange(data);
            //    dTable.AddRange(data);
            //}

            //Run a new htableupdate
            for (int i = 1; i < map.height; i++)
            {
                for (int j = 0; j < map.width; j++)
                {
                    var index = TransformCoordToIndex(j, i);
                    //Check if in this coordinate, there is a static obs
                    if (staticObstacleLUT[index])
                    {
                        //set hval as maxvalue
                        hTableStatic.Insert(index, double.MaxValue);
                    }
                    else
                    {
                        //No static obs
                        var dist = map.goalState.distanceTo(j, i);
                        hTableStatic.Insert(index, dist);
                    }
                }
            }
        }

        private State PickBestState()
        {
            foreach (var st in globalOpenList)
            {
                goalQueue.Add(st);
            }
            globalOpenList.Clear();

            var state = goalQueue.Peek();
            do
            {
                var peekState = goalQueue.Peek();
                if (state.time <= peekState.time && state.h_d + state.h_s > peekState.h_s + peekState.h_d)
                {
                    state = goalQueue.Peek();
                }
                globalOpenList.Add(goalQueue.Remove());
            } while (goalQueue.Count != 0);

            return state;
        }

        private int TransformCoordToIndex(int x, int y)
        {
            return map.height * y + x;
        }

        private void CreatePredecessors(State state, int time)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    state.predecessors.Add(new PointWithTime() { x = state.x + i, y = state.y + j, time = time });
                }
            }
        }

        /// <summary>
        /// Returns a movement cost unless the goal is moving to the goal
        /// </summary>
        /// <param name="state"></param>
        /// <param name="childState"></param>
        /// <returns></returns>
        private double staticCost(State state, State childState)
        {
            if (state.positionEqual(map.goalState) && childState.positionEqual(map.goalState))
                return 0;
            return 1;
        }
    }
}
