using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DNAcounter
{
    public partial class Form2 : Form
    {
        private string[] oligo;
        public Form2(string[] oligo)
        {
            this.oligo = oligo;
            InitializeComponent();
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Zapis_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            int[] ile = new int[oligo.Length];

            var duplicates = oligo
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => new { value = g.Key, Count = g.Count() })
                .ToList();

            foreach(var duplicate in duplicates)
            {
                MessageBox.Show("Element: " + duplicate.value + ",  Count: " + duplicate.Count);
                listView1.Items.Add(duplicate.value + " " + duplicate.Count);
            }

            //string baza = "1";

            foreach(var x in oligo)
            {
                if (!duplicates.Any(d => d.value == x))
                {
                    listView1.Items.Add(x + " 1");
                }
            }
            




            /*
            Array.Fill(ile, 1);

            for (int i=0; i<oligo.Length; i++)
            {
                for(int j=0; j<oligo[i].Length; j++)
                {
                    if (i !=j && oligo[i] == oligo[j])
                    {
                        ile[i]++;
                    }
                }
            }

            for(int i=0; i<oligo.Length; i++)
            {
                MessageBox.Show(oligo[i]);
                MessageBox.Show(ile[i].ToString());
            }
            */


        }
    }
}
