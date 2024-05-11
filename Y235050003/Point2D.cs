using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y235050003
{
    internal class Point2D
    {
        private int _x;
        private int _y;

        public int x
        {
            
            get { return _x; }
            set { _x = value; }
        }
        public int y
        {
            
            get { return _y; }
            set { _y = value; }

        }

        public Point2D() { }

        public Point2D(int xMax,int yMax)
        {
            Random rnd=new Random();
            _x = rnd.Next(xMax);
            _y = rnd.Next(yMax);
        }

        public void printCoodinates()
        {
            
            MessageBox.Show("Point: ("+x+", "+y+")");
        }

        public double calculatePolarCoordinates(int x,int y)
        {
            double r=Math.Sqrt(x*x+y*y);
            double theta = Math.Atan(y / x);
            return 1;
        }

        public double calculateCartesianCoordinates(double r,double theta)
        {
            double x=r*Math.Cos(theta);
            double y=r*Math.Sin(theta);
            return 1;
        }
    }
}
