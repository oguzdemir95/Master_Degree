using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;

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

        // The first point calculted through Draw Button will be stored in sendCoor to use it in rotation calculation
        // For rotation, only firts point is adequate
        Point2D sendCoor;

        // Coordinates calculted through Draw Button will be stored in newCoor array to use it in Rotate Button and Picturebox
        // Rotated coordinates will be new coordinates and typed on listbox
        Point2D[] newCoor;

        // r, the distance from center of polygon to an edge of polygon will be stored in this variable
        double r;
        
        // Random angle value is stored to be used by Rotate Button
        // Draw button clears the angle after clicked
        // But owing to this variable, draw button enables random angle to apply without reset
        double rRotAngle = 0;

        // After clicking Draw button, the coordinates of polygon is written on listbox and the polygon is drawn on picturebox
        private void btnDraw_Click(object sender, EventArgs e)
        {
            // Checks whether textboxes are empty
            if(string.IsNullOrEmpty(cntTbX.Text)||string.IsNullOrEmpty(cntTbY.Text)
                ||string.IsNullOrEmpty(lntTb.Text)||string.IsNullOrEmpty(noeTb.Text))
            {
                MessageBox.Show("Values could not be null!");
                return;
            }

            // Checks whether inputs are numeric
            if (!(cntTbX.Text.All(c => char.IsDigit(c) || c == '-' && cntTbX.Text.IndexOf(c) <= 0
            || c == ',' && cntTbX.Text.IndexOf(c) > 0 && cntTbX.Text.Count(x => x == ',') <= 1))
            || !(cntTbY.Text.All(c => char.IsDigit(c) || (c == '-' && cntTbY.Text.IndexOf(c) <= 0)
            || (c == ',' && cntTbY.Text.IndexOf(c) > 0 && cntTbY.Text.Count(x => x == ',') <= 1))))
            {
                MessageBox.Show("All values must be numeric!");
                return;
            }

            // Receives the values from textboxes
            Point2D center = new Point2D(Convert.ToInt32(cntTbX.Text), Convert.ToInt32(cntTbY.Text));
            double length = Convert.ToDouble(lntTb.Text);

            // Checks whether inputs are numeric
            if (!(lntTb.Text.All(c => char.IsDigit(c) || c == '-' && lntTb.Text.IndexOf(c) == 0 && lntTb.Text.Length > 1
                || (c == ',' && lntTb.Text.Count(x => x == ',') == 1) && lntTb.Text.Length > 1)))
            {
                MessageBox.Show("All values must be numeric!");
                return;
            }

            // Checks whether length is smaller than zero, it must be greater than zero
            if (length <= 0)
            {
                MessageBox.Show("Polygon's edge length must be greater than 0 (zero)!");
                return;
            }

            // Checks whether inputs are numeric
            if (!(noeTb.Text.All(c => char.IsDigit(c) || c == '-' && noeTb.Text.IndexOf(c) == 0 && noeTb.Text.Length > 1
                || (c == ',' && noeTb.Text.Count(x => x == ',') == 1) && noeTb.Text.Length > 1)))
            {
                MessageBox.Show("All values must be numeric!");
                return;
            }

            int edge = Convert.ToInt32(noeTb.Text);

            // Checks whether number of edges value is an integer and greater than 3
            int number;
            if (!(int.TryParse(noeTb.Text, out number) && edge >= 3))
            {
                MessageBox.Show("Number of edges must be an integer value equal to or greater than 3!");
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

            // Creates a new polygon object from Polygon class
            Polygon polygon = new Polygon();

            // r is calcultated, r = (l/2) * sin(theta)
            double r = (length / 2) / (Math.Sin((180 / edge) * (Math.PI / 180)));

            // Creates a coordinates array from Point2D class, it uses Calculate Edges method and stores points
            Point2D[] coordinates = polygon.calculateEdgeCoordinates(center, r, edge);

            // sendCoor is the first point of the polygon
            sendCoor = coordinates[0];

            // newCoor is all the corner points of the polygon
            newCoor = coordinates;

            // Writes corner points of polygon on listbox, sends the listbox that is on form as a parameter to print method
            polygon.printCoodinates(coorLb, coordinates, edge);

            // Triggers the picturebox, hence the polygon is drawn on picturebox
            pictureBox1.Invalidate();
        }

        // The initial angle
        // Rotation button must apply the angle typed on textbox
        // In order for button to apply this, the value on textbox must be added on initial angle
        // It creates a cycle
        double angle = 0;

        // After clicking Rotate button, the coordinates of new (rotated) polygon is written on listbox and the polygon is drawn as rotated on picturebox
        private void btnRotate_Click(object sender, EventArgs e)
        {
            // Checks whether textboxes are empty
            if (string.IsNullOrEmpty(raTb.Text))
            {
                MessageBox.Show("Values could not be null!");
                return;
            }

            // Checks whether inputs are numeric
            if (!(raTb.Text.All(c => char.IsDigit(c) || c == '-' && raTb.Text.IndexOf(c) == 0 && raTb.Text.Length > 1
                || c == ',' && raTb.Text.Count(x => x == ',') == 1 && raTb.Text.Length > 1)))
            {
                MessageBox.Show("All values must be numeric!");
                return;
            }

            // The coordinates are checked whether a polygon is drawn
            if (coorLb.Items.Count == 0)
            {
                MessageBox.Show("A polygon must be drawn first!");
                return;
            }

            int edge = Convert.ToInt32(noeTb.Text);

            double rotAngle = Convert.ToDouble(raTb.Text);

            // Angle is increased on every click of button, hence polygon is rotated by the value
            angle += rotAngle;

            // Creates a new polygon object from Polygon class
            Polygon polygon = new Polygon();

            // newCoor is the rotated coordinates of the polygon
            newCoor = polygon.rotatePolygon(sendCoor, angle, edge);

            // Types corner points of the new (rotated) polygon on listbox, sends the listbox that is on form as a
            // parameter to print method
            polygon.printCoodinates(coorLb, newCoor, edge);

            // Triggers the picturebox, hence the new (rotated) polygon is drawn on picturebox
            pictureBox1.Invalidate();

            // It resets the Random Angle to prevent Draw Button to get the value and draw unintented polygons
            rRotAngle = 0;
        }

        //Picturebox object is used to show polygon on it
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Edge value is required for the cycle and drawing
            int edge;

            // Creates a new polygon object from Polygon class
            Polygon polygon = new Polygon();

            // Creates a g object from Graphics class
            Graphics g = e.Graphics;

            // Creates pen object from Pen class, one of them is for axes and one of them is for polygon
            Pen pen1 = new Pen(Color.Blue);
            Pen pen2 = new Pen(Color.Black);

            // Cartesian plain is drawn
            g.DrawLine(pen1, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(pen1, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            // The coordinates are checked whether a polygon is drawn
            if (coorLb.Items.Count > 0)
            {
                edge = Convert.ToInt32(noeTb.Text);

                // Creates a points array from PointF class
                PointF[] points = new PointF[edge];

                // For cycle determines the corner points of polygon
                // The coordinates are based on rotated points
                // If the polygon is not rotated, it gets the initial drawing coordinates
                for (int i = 0; i < edge; i++)
                {
                    points[i] = new PointF((float)newCoor[i].x + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newCoor[i].y );
                }

                // Polygon is drawn
                g.DrawPolygon(pen2, points);
            }

            // Clears pen
            pen2.Dispose();

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
            int noe = rnd.Next(3, 10);
            double ang = rnd.Next(0, 359);
            lntTb.Text = lnt.ToString();
            noeTb.Text = noe.ToString();
            raTb.Text = ang.ToString();

            // Random angle value is assigned by Random Button
            rRotAngle = ang;
        }
    }
}
