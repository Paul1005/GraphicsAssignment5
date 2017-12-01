using System;
using System.Collections.Generic;
using System.Text;

namespace asgn5v1
{
    struct MinMax
    {
        public double minX;
        public double minY;
        public double minZ;
        public double maxX;
        public double maxY;
        public double maxZ;

        MinMax(double minX = 0, double minY = 0, double minZ = 0, double maxX = 0, double maxY = 0, double maxZ = 0)
        {
            this.minX = minX;
            this.minY = minY;
            this.minZ = minZ;
            this.maxX = maxX;
            this.maxY = maxY;
            this.maxZ = maxZ;
        }
    }
}
