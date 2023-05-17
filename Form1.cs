using System.Numerics;

namespace DNAcounter
{
    public partial class Form1 : Form
    {
        string DNA;
        string[] oligo;
        public Form1()
        {
            InitializeComponent();
        }

        private void wyszukaj_Click(object sender, EventArgs e)
        {
            //n - k + 1

            DNA = textBox1.Text;
            //MessageBox.Show(DNA);
            int n = DNA.Length;
            int k = 4;

            int ilosc = n - k + 1;

            oligo = new string[ilosc-1];

            string temp = "";

            for (int i = 0; i < ilosc-1; i++)
            {
                oligo[i] = DNA.Substring(i, k);
            }
            /*
            for (int i = 0; i < oligo.Length; i++)
            {
                MessageBox.Show(oligo[i]);
            }
            */

            Form2 form2 = new Form2(oligo);
            form2.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}