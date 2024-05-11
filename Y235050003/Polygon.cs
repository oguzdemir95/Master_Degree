using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y235050003
{
    internal class Polygon:Point2D
    {
        private Point2D _center;
        private int _length;
        private int _numberofEdges;

        public int Length { get => _length; set => _length = value; }
        public int NumberofEdges { get => _numberofEdges; set => _numberofEdges = value; }
        internal Point2D Center { get => _center; set => _center = value; }

        public Polygon()
        {

        }

        public Polygon(Point2D center,int radius)
        {
            _center = center;

        }

        public double calculateEdgeCoordinates()




    }
}
