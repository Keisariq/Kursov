using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursov
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<String> selectedDates = new List<String>();
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите данные для анализа");
                return;
            }
            foreach (var item in checkedListBox1.CheckedItems)
            {
                selectedDates.Add((String)item);
            }
            var frmGist1 = new Form3(selectedDates);
            frmGist1.ShowDialog();
            this.Close();
        }
    }
}
