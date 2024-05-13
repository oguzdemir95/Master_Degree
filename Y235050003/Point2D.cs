using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y235050003
{
    internal class Point2D
    {
        // Define fields
        private double _x;
        private double _y;

        //Define properties
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

        // Constructor method with no parameters
        public Point2D() 
        {
            x = 0;
            y = 0;
        }

        // Constructor method with two parameters, x and y
        public Point2D(double x,double y)
        {
            _x = x;
            _y = y;
        }

        // Print method for typing coordinates on listbox
        public void printCoodinates(ListBox lb, Point2D[] coordinates,int edges)
        {
            // Receives the listbox object created on Form
            lb.Items.Clear();
            for (int i = 0; i < edges; i++)
            {
                lb.Items.Add($"Point {i + 1}: ({coordinates[i].x:F3}, {coordinates[i].y:F3})");
            }
        }

        // Transforming from cartesian to polar coordinates
        public Point2D calculatePolarCoordinates(double x,double y)
        {
            double r=Math.Sqrt(x*x+y*y);
            double theta = Math.Atan(y / x);
            Point2D pPoint = new Point2D(x, y);
            return pPoint;
        }

        // Transforming from polar to cartesian coordinates
        public Point2D calculateCartesianCoordinates(double r,double theta)
        {
            double x=r*Math.Cos((theta) * (Math.PI / 180));
            double y=r*Math.Sin((theta) * (Math.PI / 180));
            Point2D cPoint = new Point2D(x, y);
            return cPoint;
        }
    }
}
