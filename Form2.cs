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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save CSV file";

            DialogResult result = saveFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                
                StringBuilder sb = new StringBuilder();

                foreach(ColumnHeader column in listView1.Columns)
                {
                    
                 sb.Append(column.Text);
                 sb.Append(",");

                    
                }
                sb.AppendLine();

                foreach (ListViewItem item in listView1.Items)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        sb.Append(subItem.Text);
                        sb.Append(",");
                    }
                    sb.AppendLine();
                }


                File.WriteAllText(filePath, sb.ToString());
            }
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
                
                listView1.Items.Add(duplicate.value + " " + duplicate.Count);
            }

            

            foreach(var x in oligo)
            {
                if (!duplicates.Any(d => d.value == x))
                {
                    listView1.Items.Add(x + " 1");
                }
            }
            




            

        }
    }
}
