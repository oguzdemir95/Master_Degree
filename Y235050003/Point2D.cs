using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y235050003
{
    internal class Point2D
    {
        private double _x=0;
        private double _y=0;

        public double x
        {
            
            get { return _x; }
            set { _x = value; }
        }
        public double y
        {
            
            get { return _y; }
            set { _y = value; }

        }

        public Point2D() 
        {
            x = 0;
            y = 0;
        }

        public Point2D(double x,double y)
        {
            _x = x;
            _y = y;
        }

        public void printCoodinates()
        {            
            MessageBox.Show("Point: ("+x+", "+y+")");
            ListBox listBox = new ListBox();
            listBox.Items.Add($"({x}, {y})");
        }

        public double[] calculatePolarCoordinates(double x,double y)
        {
            double r=Math.Sqrt(x*x+y*y);
            double theta = Math.Atan(y / x);
            double[] polar = new double[] { r, theta };
            return polar;
        }

        public Point2D calculateCartesianCoordinates(double r,double theta)
        {
            double x=r*Math.Cos(theta);
            double y=r*Math.Sin(theta);
            Point2D cPoint = new Point2D(x, y);
            return cPoint;
        }
    }
}
