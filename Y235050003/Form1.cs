namespace Y235050003
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Point2D deneme = new Point2D(10, 10);
            ////MessageBox.Show(deneme.x.ToString());
            //deneme.printCoodinates();
            //Polygon deneme2 = new Polygon();
            //deneme2.calculateEdgeCoordinates(deneme, 4);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cntTbX_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Point2D center = new Point2D(Convert.ToInt32(cntTbX.Text), Convert.ToInt32(cntTbY.Text));
            int length = Convert.ToInt32(lntTb.Text);
            int edge = Convert.ToInt32(noeTb.Text);

            Polygon polygon = new Polygon();
            Point2D[] coordinates = polygon.calculateEdgeCoordinates(center, length,edge);

            coorLb.Items.Clear();
            foreach (var coordinate in coordinates)
            {
                coorLb.Items.Add($"({coordinate.x:F3}, {coordinate.y:F3})");
            }


        }

        private void noeTb_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
