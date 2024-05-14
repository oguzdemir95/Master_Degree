using System;
using System.Collections.Generic;
using System.Linq;
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
        public Point2D[] calculateEdgeCoordinates(Point2D center, double length,int edges)
        {
            double theta = 0;

            // r is the distance from origin to a corner of polygon, r = l/2*sin(theta)
            double r = (length / 2) / (Math.Sin((180 / edges)*(Math.PI/180)));

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
                // There are 190 and 175 values, because picturebox take its center in these points (its size is 380x350)
                // 190 = x, 175 = y => (190, 175)
                // Therefore, the polygon is created on picturebox' center
                // Picturebox' and polygon's centers are different from each other; user sees only polygon's center values
                vertex[i].x = center.x + pAdd.x+190;
                vertex[i].y = center.y + pAdd.y+175;

                // On every step, theta is increased to calculate next point
                theta += 360 / edges;
            }
            // This function returns array of polygon corners
            return vertex;
        }

        // Calculates rotated corner points of polygon
        public Point2D[] rotatePolygon(Point2D center, double length, int edges, double angle)
        {
            // Theta's initial value is 270 to get the polygon straight
            double theta = 270;

            // The angle entered textbox is added to initial theta value, on every step polygon is rotated as angle value
            theta += -angle;

            // r is the distance from origin to a corner of polygon, r = l/2*sin(theta)
            double r = (length / 2) / (Math.Sin((180 / edges) * (Math.PI / 180)));

            // Creating a rotPoints array to store new (rotated) points information of polygon
            Point2D[] rotPoints = new Point2D[edges];

            // For cycle determines the new (rotated) corners of polygon
            for (int i = 0; i < edges; i++)
            {
                // pAdd is the new (rotated) corner point of polygon, sends r and theta to Cartesian Method 
                Point2D pAdd = calculateCartesianCoordinates(r, theta);

                // New (rotated) corner points are added to center points typed on textboxes
                // There are 190 and 175 values, because picturebox take its center in these points (its size is 380x350)
                // 190 = x, 175 = y => (190, 175)
                // Therefore, the polygon is rotated on picturebox' center
                // Picturebox' and polygon's centers are different from each other; user sees only polygon's center values
                rotPoints[i] = new Point2D(pAdd.x, pAdd.y);
                rotPoints[i].x = center.x + pAdd.x + 190;
                rotPoints[i].y = center.y + pAdd.y + 175;

                // On every step, theta is increased to calculate next point
                theta += 360 / edges;
            }
            // This function returns array of new (rotated) polygon corners
            return rotPoints;
        }

    }
}
