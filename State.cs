using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GirbalPathfinding
{
    public class State
    {
        public int x;
        public int y;
        public double headingAv;
        public double headingDAv;
        public double cost_turning;
        public int qindex { get; set; }
        public int depth { get; set; }
        public int qtime { get; set; }
        public int time { get; set; }
        public double fakeh { get; set; }
        public double fakec { get; set; }
        public double tempc { get; set; }
        public List<PointWithTime> predecessors { get; set; }
        public List<PointWithTime> staticPredecessors { get; set; }

        public double cost_s { get; set; }
        public double cost_d { get; set; }
        public double h_s { get; set; }
        public double h_d { get; set; }
        public double d_err { get; set; }
        public double h_err { get; set; }
        public double d { get; set; }
        public double f_c { get; set; }
        public int frontier_time { get; set; }
        public State parent { get; set; }
        public int comparisonFhat { get; set; }

        public State()
        {
            x = -1;
            x = -1;
            time = 0;
            predecessors = new List<PointWithTime>();
            staticPredecessors = new List<PointWithTime>();
            comparisonFhat = 0;
            headingAv = 0;
            cost_turning = 0;
        }

        public State(int x, int y, double cost_s, double cost_d, double h_s, double h_d, int time) : this()
        {
            this.x = x;
            this.y = y;
            this.cost_s = cost_s;
            this.cost_d = cost_d;
            this.h_s = h_s;
            this.h_d = h_d;
            this.time = time;
        }

        public State(State state) : this(state.x, state.y, state.cost_s, state.cost_d, state.h_s, state.h_d, state.time)
        {
            this.parent = state.parent;
            this.predecessors = state.predecessors;
        }

        public double f()
        {
            return fakeh + fakec;
        }

        public double fhat()
        {
            return cost_s + cost_d + h_s + h_d + h_err + cost_turning;
            //return f_static();
        }

        public double f_static()
        {
            return cost_s + h_s;
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
            setProperties(x, y, time);

            if (this.x < 0 || this.x >= boardw || this.y < 0 || this.y >= boardh)
                return false;
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
            headingAv = state.headingAv;
            headingDAv = state.headingDAv;
        }

        /// <summary>
        /// Checks to see if the state is a static obstacle
        /// </summary>
        /// <param name="staticObstacles">List of static obstacles</param>
        /// <returns>True if state is a static obstacle</returns>
        public bool checkIfStaticObstacle(List<StaticObstacle> staticObstacles)
        {
            return staticObstacles.Exists((obs) => obs.x == this.x && obs.y == this.y);
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

        public bool positionEqual(State state)
        {
            return x == state.x && y == state.y;
        }

        public bool Equals(State state)
        {
            return x == state.x && y == state.y && time == state.time;
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
