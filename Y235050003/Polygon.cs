using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Y235050003
{
    internal class Polygon:Point2D
    {
        private Point2D _center;
        private int _length=4;
        private int _numberofEdges=5;

        public int Length { get => _length; set => _length = value; }
        public int NumberofEdges { get => _numberofEdges; set => _numberofEdges = value; }
        internal Point2D Center { get => _center; set => _center = value; }

        public Polygon()
        {
            Center=new Point2D(0,0);
        }

        public Polygon(Point2D center,int length,int edges)
        {
            Center = center;
            Length = length; 
            NumberofEdges=edges;
        }

        public Point2D[] calculateEdgeCoordinates(Point2D center, int length,int edges)
        {
            double theta = 0;
            Point2D[] vertex=new Point2D[edges];
            for(int i=0;i<edges;i++)
            {
                vertex[i] = new Point2D();
                Point2D pAdd = calculateCartesianCoordinates(length, theta);
                vertex[i].x = center.x + pAdd.x;
                vertex[i].y = center.y + pAdd.y;
                theta += 360 / edges;
            }
            return vertex;
        }
        
             
        



    }
}
