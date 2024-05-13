using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Y235050003
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
              
        // After clicking Draw button, the coordinates of polygon is written on listbox and the polygon is drawn on picturebox
        private void btnDraw_Click(object sender, EventArgs e)
        {
            // Receives the values from textboxes
            Point2D center = new Point2D(Convert.ToInt32(cntTbX.Text), Convert.ToInt32(cntTbY.Text));
            int length = Convert.ToInt32(lntTb.Text);
            int edge = Convert.ToInt32(noeTb.Text);

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
            // Receives the values from textboxes
            Point2D center = new Point2D(Convert.ToInt32(cntTbX.Text), Convert.ToInt32(cntTbY.Text));
            int length = Convert.ToInt32(lntTb.Text);
            int edge = Convert.ToInt32(noeTb.Text);
            double rotAngle = Convert.ToDouble(raTb.Text);

            // Angle is increased on every click of button, hence polygon is rotated as the value
            angle += rotAngle;

            // Creates a new polygon object from Polygon class
            Polygon polygon = new Polygon();

            // Creates a rotcoordinates array from Point2D class, it uses Rotate Polygon method and stores points
            Point2D[] rotCoordinates = polygon.rotatePolygon(center, length, edge, angle);

            // Writes corner points of the new (rotated) polygon on listbox, sends the listbox that is on form as a parameter to print method
            polygon.printCoodinates(coorLb, rotCoordinates, edge);

            // Triggers the picturebox, hence the new (rotated) polygon is drawn on picturebox
            pictureBox1.Invalidate();

        }

        // Picturebox object is used to show polygon on it
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // The initial angle
            // It requires this angle to show polygon straight
            // Because picturebox triggered when the form is opened
            // And it gets points information from rotatedPoints
            // Thus, as soon as form is opened, drawing occurs and it needs zero angle
            double pAngle = 0;

            // Receives the values from textboxes
            Point2D center = new Point2D(Convert.ToInt32(cntTbX.Text), Convert.ToInt32(cntTbY.Text));
            int length = Convert.ToInt32(lntTb.Text);
            int edge = Convert.ToInt32(noeTb.Text);
            double rotAngle = Convert.ToDouble(raTb.Text);


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

            // Polygon is drawn
            g.DrawPolygon(pen, points);

            // Clears pen
            pen.Dispose();
        }

        private void btnRnd_Click(object sender, EventArgs e)
        {
            // Types random values on textboxes between predetermined ranges
            Random rnd = new Random();
            int cntx = rnd.Next(0, 3);
            int cnty = rnd.Next(0, 3);
            int lnt = rnd.Next(3, 9);
            int noe=rnd.Next(3,10);
            int ang = rnd.Next(0, 359);
            cntTbX.Text = cntx.ToString();
            cntTbY.Text = cnty.ToString();
            lntTb.Text = lnt.ToString();
            noeTb.Text=noe.ToString();
            raTb.Text=ang.ToString();
        }
    }
}
