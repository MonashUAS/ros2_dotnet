using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;

namespace GirbalPathfinding
{
    public class State
    {
        public int x; 
        public int y;

        public int time { get; set; }

        //neighbours
        public List<PointWithTime> predecessors { get; set; }
        public List<PointWithTime> staticPredecessors { get; set; }

        public double g { get; set; }
        public double h { get; set; }
        public int frontier_time { get; set; }
        public State parent { get; set; }
        public int comparisonFhat { get; set; }

        public State()
        {
            x = -1; //why is this set twice
            x = -1;
            time = 0;
            predecessors = new List<PointWithTime>();
            staticPredecessors = new List<PointWithTime>();
            comparisonFhat = 0;
        }

        public State(int x, int y, double cost_s, double h_s, int time) : this()
        {
            this.x = x;
            this.y = y;
            this.g = cost_s;
            this.h = h_s;
            this.time = time;
        }

        public State(State state) : this(state.x, state.y, state.g, state.h, state.time)
        {
            this.parent = state.parent;
            this.predecessors = state.predecessors;
        }

        public double fhat()
        {
            return g + h;
            //return f_static();
        }

        public double f_static()
        {
            return g + h;
        }

        /// <summary>
        /// Sets the properties of this state instance and checks validity
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="time"></param>
        /// <returns>True if state is valid</returns>
        public bool setProperties(int x, int y, int time, int boardw, int boardh)
        {
            setProperties(x, y, time); //uses lower level overide

            if (this.x <= 0 || this.x >= boardw || this.y <= 0 || this.y >= boardh)
            {
                return false;
            }
            return true;
        }

        public void setProperties(int x, int y, int time)
        {
            this.x = x;
            this.y = y;
            this.time = time;
        }

        public void setProperties(PointWithTime point)
        {
            setProperties(point.x, point.y, point.time);
        }

        public void setProperties(State state)
        {
            setProperties(state.x, state.y, state.time);
        }

        /// <summary>
        /// Checks to see if the state is a static obstacle
        /// </summary>
        /// <param name="staticObstacles">List of static obstacles</param>
        /// <returns>True if state is a static obstacle</returns>
        public bool checkIfStaticObstacle(int[,] staticObstacles)
        {
            for (int i = 0; i <= Globals.droneRadius; i++)
            {
                for (int j = 0; j <= Globals.droneRadius; j++)
                {
                    if (staticObstacles[i,j] != 0)
                    {
                        return true; //checks if the state is an obsticle
                    }
                }
            }
            return false;

            //return staticObstacles.Exists((obs) => obs.x == this.x && obs.y == this.y);
        }

        public bool checkIfConstraint(List<(State, int)> constraints, int agentIndex)
        {
            if (constraints.Exists((constraint) => constraint.Item1.x == this.x && constraint.Item1.y == this.y && constraint.Item1.time == this.time && constraint.Item2 == agentIndex))
            {
                //Trace.WriteLine("Constraint found: " + this.x.ToString() + " " + this.y.ToString() + " " + this.time.ToString() + " " + agentIndex.ToString());
                return true;
            }

            return false;
        }

        public float distanceTo(State input)
        {
            return MathF.Sqrt(MathF.Pow(x - input.x, 2) + MathF.Pow(y - input.y, 2));
        }

        public float distanceTo(int x, int y)
        {
            return MathF.Sqrt(MathF.Pow(this.x - x, 2) + MathF.Pow(this.y - y, 2));
        }

        public void generateComparisonFhat()
        {
            try
            {
                comparisonFhat = (int)(fhat());
            }
            catch (OverflowException)
            {
                comparisonFhat = int.MaxValue;
            }
            if (comparisonFhat == int.MinValue)
                comparisonFhat = int.MaxValue;
            //Debug.WriteLine("{0}, {1}, {2}, {3}, {4}", cost_s, cost_d, h_s, h_d, h_err);
        }

        public bool positionEqual(State state, bool includeRadius)
        {
            if (includeRadius)
            {
                if ((state.x - Globals.droneRadius <= x && x <= state.x + Globals.droneRadius) && (state.y - Globals.droneRadius <= y && y <= state.y + Globals.droneRadius))
                {

                    return true;
                }

                return false;

            } else
            {

                return x == state.x && y == state.y;
            }
        }

        public bool Equals(State state, bool includeRadius)
        {
            if (includeRadius)
            {
                if ((state.x - Globals.droneRadius <= x && x <= state.x + Globals.droneRadius) && (state.y - Globals.droneRadius <= y && y <= state.y + Globals.droneRadius) && state.time == time)
                {

                    return true;
                }

                return false;
            } else
            {
                return x == state.x && y == state.y && time == state.time;
            }
        }


        public static bool operator ==(State a, State b)
        {
            return a.x == b.x && a.y == b.y && a.time == b.time;
        }

        public static bool operator !=(State a, State b)
        {
            return !(a == b);
        }
    }
}
