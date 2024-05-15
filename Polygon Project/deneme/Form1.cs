using System.Windows.Forms.VisualStyles;

namespace deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            double l=Convert.ToDouble(textBox1.Text);
            double ed=Convert.ToDouble(textBox2.Text);   
            double r = (l / 2) / (Math.Sin((180 / ed) * (Math.PI / 180)));
            MessageBox.Show(r.ToString());

        }
    }
}
