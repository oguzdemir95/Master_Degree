using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

// ***************************************************************************************************************************
// **                                                                                                                       **
// ** STUDENT NAME: OÐUZHAN DEMÝR                                                                                           **
// ** STUDENT NUMBER: Y235050003                                                                                            **
// ***************************************************************************************************************************
namespace Y235050003
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The initial angle for picturebox
        // It requires this angle to show polygon straight and rotate regularly
        double pAngle = 0;

        // Random angle value is stored to be used by Rotate Button
        // Draw button clears the angle after clicked
        // But owing to this variable, draw button enables random angle to apply without reset
        int rRotAngle = 0;

        // After clicking Draw button, the coordinates of polygon is written on listbox and the polygon is drawn on picturebox
        private void btnDraw_Click(object sender, EventArgs e)
        {
            // First, all values are checked whether they are typed as numbers
            if (!(cntTbX.Text.All(char.IsDigit))|| !(cntTbY.Text.All(char.IsDigit))|| !(lntTb.Text.All(char.IsDigit)) ||
                !(noeTb.Text.All(char.IsDigit)))
            {
                MessageBox.Show("All values must be numeric!");
                return;
            }

            // Receives the values from textboxes
            Point2D center = new Point2D(Convert.ToInt32(cntTbX.Text), Convert.ToInt32(cntTbY.Text));
            int length = Convert.ToInt32(lntTb.Text);
            int edge = Convert.ToInt32(noeTb.Text);

            // Edge number is checked whether it is smaller than 3
            if(edge<3)
            {
                MessageBox.Show("Number of edges must be greater than or equal to 3!");
                return;
            }

            if (rRotAngle != 0)
            {
                // If random angle assigned by Random Button is different from 0, it remains on textbox to be applied by Rotate Button
                // For Draw Button, on second click, it resets
                // Rotate Button may use it more than once until Draw Button's second click
                raTb.Text = rRotAngle.ToString();
                rRotAngle = 0;
            }
            else 
            {
                // If there is no random angle, which means Random Button has not been used, therefore Draw Button resets Rotation
                // Angle in order to get the picturebox to draw the polygon straight and in start form
                raTb.Text = "0";
            }

            // Draw button resets pAngle in order to get the picturebox to draw the polygon straight and in start form
            pAngle = 0;

            // Creates a new polygon object from Polygon class
            Polygon polygon = new Polygon();

            // Creates a coordinates array from Point2D class, it uses Calculate Edges method and stores points
            Point2D[] coordinates = polygon.calculateEdgeCoordinates(center, length, edge);

            // Writes corner points of polygon on listbox, sends the listbox that is on form as a parameter to print method
            polygon.printCoodinates(coorLb , coordinates, edge);

            // Triggers the picturebox, hence the polygon is drawn on picturebox
            pictureBox1.Invalidate();
        }

        // The initial angle
        // Rotation button must apply the angle typed on textbox
        // In order for button to apply this, the value on textbox must be added on initial angle
        // It creates a cycle
        double angle = 270;

        // After clicking Rotate button, the coordinates of new (rotated) polygon is written on listbox and the polygon is drawn as rotated on picturebox
        private void btnRotate_Click(object sender, EventArgs e)
        {
            // First, all values are checked whether they are typed as numbers
            if (!(cntTbX.Text.All(char.IsDigit)) || !(cntTbY.Text.All(char.IsDigit)) || !(lntTb.Text.All(char.IsDigit)) ||
                !(noeTb.Text.All(char.IsDigit))|| !(raTb.Text.All(char.IsDigit)))
            {
                MessageBox.Show("All values must be numeric!");
                return;
            }

            // Second, the coordinates are checked whether a polygon is drawn
            if(coorLb.Items.Count==0)
            {
                MessageBox.Show("A polygon must be drawn first!");
                return;
            }

            // Receives the values from textboxes
            Point2D center = new Point2D(Convert.ToInt32(cntTbX.Text), Convert.ToInt32(cntTbY.Text));
            int length = Convert.ToInt32(lntTb.Text);
            int edge = Convert.ToInt32(noeTb.Text);

            // Edge number is checked whether it is smaller than 3
            if (edge < 3)
            {
                MessageBox.Show("Number of edges must be greater than or equal to 3!");
                return;
            }

            double rotAngle = Convert.ToDouble(raTb.Text);

            // Angle is increased on every click of button, hence polygon is rotated by the value
            angle += rotAngle;

            // Creates a new polygon object from Polygon class
            Polygon polygon = new Polygon();

            // Creates a rotcoordinates array from Point2D class, it uses Rotate Polygon method and stores points
            Point2D[] rotCoordinates = polygon.rotatePolygon(center, length, edge, angle);

            // Types corner points of the new (rotated) polygon on listbox, sends the listbox that is on form as a
            // parameter to print method
            polygon.printCoodinates(coorLb, rotCoordinates, edge);

            // Triggers the picturebox, hence the new (rotated) polygon is drawn on picturebox
            pictureBox1.Invalidate();

            // It resets the Random Angle to prevent Draw Button to get the value and draw unintented polygons
            rRotAngle = 0;

        }

        // Picturebox object is used to show polygon on it
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            // Receives the values from textboxes
            Point2D center = new Point2D(Convert.ToInt32(cntTbX.Text), Convert.ToInt32(cntTbY.Text));
            int length = Convert.ToInt32(lntTb.Text);
            int edge = Convert.ToInt32(noeTb.Text);
            double rotAngle = Convert.ToDouble(raTb.Text);
            
            // pAngle is required for rotation of polygon, it increases as rotation angle in every step
            pAngle += -rotAngle;

            // Creates a new polygon object from Polygon class
            // Creates a coordinates array from Point2D class, it uses Calculate Edges method and stores points
            // Creates a rotcoordinates array from Point2D class, it uses Rotate Polygon method and stores points
            Polygon polygon = new Polygon();
            Point2D[] coordinates = polygon.calculateEdgeCoordinates(center, length, edge);
            Point2D[] rotatedPoints = polygon.rotatePolygon(center, length, edge, pAngle);

            // Creates a g object from Graphics class
            Graphics g = e.Graphics;

            // Creates a pen object from Pen class
            Pen pen = new Pen(Color.Black);

            // Creates a points array from PointF class
            PointF[] points = new PointF[coordinates.Length];

            // For cycle determines the corner points of polygon
            // The coordinates are based on rotated points
            // If the polygon is not rotated, it gets the initial drawing coordinates
            for (int i = 0; i < coordinates.Length; i++)
            {
                points[i] = new PointF((float)rotatedPoints[i].x, (float)rotatedPoints[i].y);
            }

            // The coordinates are checked whether a polygon is drawn
            if (coorLb.Items.Count > 0)
            {
                // Polygon is drawn
                g.DrawPolygon(pen, points);
            }

            // Clears pen
            pen.Dispose();
        }

        private void btnRnd_Click(object sender, EventArgs e)
        {
            // Clears coordinates to calculate new coordinates from random values
            coorLb.Items.Clear();

            // Gets and types random center values from default constructor of Point2D class
            Point2D cnt = new Point2D();
            cntTbX.Text = cnt.x.ToString();
            cntTbY.Text = cnt.y.ToString();

            // Types random values on textboxes between predetermined ranges
            Random rnd = new Random();
            int lnt = rnd.Next(3, 9);
            int noe=rnd.Next(3,10);
            int ang = rnd.Next(0, 359);
            lntTb.Text = lnt.ToString();
            noeTb.Text=noe.ToString();
            raTb.Text=ang.ToString();

            // Random angle value is assigned by Random Button
            rRotAngle = ang;
        }
    }
}
