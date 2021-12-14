using System;
using System.Collections.Generic;
using System.Text;

namespace GirbalPathfinding
{
    public class DynamicObstacle
    {
        public double x;
        public double y;
        public double estimate_h;
        public double estimate_s;
        public double heading;
        public double speed;
        public double radius;
        public double speedX;
        public double speedY;

        public DynamicObstacle()
        {
            x = 0;
            y = 0;
            estimate_h = 0;
            estimate_s = 0;
            heading = 0;
            speed = 0;
            radius = 0;
        }

        public DynamicObstacle(double x, double y, double heading, double speed, double radius)
        {
            this.x = x;
            this.y = y;
            this.speedX = Math.Cos(heading) * speed;
            this.speedY = Math.Sin(heading) * speed;
            this.estimate_h = heading;
            this.estimate_s = speed;
            this.heading = heading;
            this.speed = speed;
            this.radius = radius;
        }

        public void updateSpeedAndHeading(double heading, double speed)
        {
            this.speedX = Math.Cos(heading) * speed;
            this.speedY = Math.Sin(heading) * speed;
            this.estimate_h = heading;
            this.estimate_s = speed;
            this.heading = heading;
            this.speed = speed;
        }
    }
}
