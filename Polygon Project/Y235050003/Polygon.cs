using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

// ***************************************************************************************************************************
// **                                                                                                                       **
// ** STUDENT NAME: OĞUZHAN DEMİR                                                                                           **
// ** STUDENT NUMBER: Y235050003                                                                                            **
// ***************************************************************************************************************************
namespace Y235050003
{
    internal class Polygon:Point2D
    {
        // Defining fields
        private Point2D _center;
        private int _length;
        private int _numberofEdges;

        // Defining properties
        public int Length { get => _length; set => _length = value; }
        public int NumberofEdges { get => _numberofEdges; set => _numberofEdges = value; }
        internal Point2D Center { get => _center; set => _center = value; }

        // Constructor with no parameters
        public Polygon()
        {
            
        }

        // Constructor with three parameters; center, length and number of edges
        public Polygon(Point2D center,int length,int edges)
        {
            Center = center;
            Length = length; 
            NumberofEdges=edges;
        }

        // Calculates corner points of polygon
        public Point2D[] calculateEdgeCoordinates(Point2D center, double r, int edges)
        {
            double theta = 0;
            
            // Creating a vertex array to store points information of polygon
            Point2D[] vertex = new Point2D[edges];

            // For cycle determines the corners of polygon
            for(int  i = 0; i < edges;i++)
            {
                // pAdd is a corner point of polygon, sends r and theta to Cartesian Method 
                Point2D pAdd = calculateCartesianCoordinates(r, theta);

                // Vertex object is created on every step
                vertex[i] = new Point2D(pAdd.x,pAdd.y);

                // Corner points are added to center points typed on textboxes
                vertex[i].x = center.x + pAdd.x;
                vertex[i].y = center.y + pAdd.y;

                // On every step, theta is increased to calculate next point
                theta += 360 / edges;
            }
            // This function returns array of polygon corners
            return vertex;
        }

        // Calculates rotated corner points of polygon
        // It uses only the first point
        // Because r is constant for a straight polygon, rotation just requires adding theta angle on current theta angle
        public Point2D[] rotatePolygon(Point2D sendCoor,double angle,int edges)
        {
            // A polar coordinate of the polygon is calculated using the firts point of it
            Point2D polCoor = calculatePolarCoordinates(sendCoor.x,sendCoor.y);

            // Theta angle is incrased by rotation angle
            // polCoor.y value is theta angle
            // Polar Coordinates Calculation function returns r and theta
            // r is constant, thus only theta angle is required
            // Angle value takes negative value to rotate polygon clockwise
            polCoor.y += -angle;

            // rotPoints array is formed from Point2D class to store rotated points
            Point2D[] rotPoints = new Point2D[edges];

            // For cycle determines the new (rotated) corners of polygon
            for (int i=0;i< edges;i++)
            {
                // Rotated coordinates calculated by Cartesian Coordinates function
                // It returns x and y values
                rotPoints[i] = calculateCartesianCoordinates(polCoor.x,polCoor.y);

                // Owing to this equation, every corner of polygon is rotated by rotation angle
                polCoor.y += 360/edges;
            }
            // This function returns array of new (rotated) polygon corners
            return rotPoints;
        }
        

    }
}
