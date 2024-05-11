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
            Point2D deneme = new Point2D(10,10);
            deneme.printCoodinates();
        }
    }
}
