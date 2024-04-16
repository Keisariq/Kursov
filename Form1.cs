using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void абонентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "telecomDataSet1.Абонент". При необходимости она может быть перемещена или удалена.
            this.абонентTableAdapter1.Fill(this.telecomDataSet1.Абонент);
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
        }

        private void оПриложенииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAbout = new AboutBox1();
            frmAbout.ShowDialog();
        }

        private void голосовойТрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "telecomDataSet2.Голосовой_трафик". При необходимости она может быть перемещена или удалена.
            this.голосовой_трафикTableAdapter.Fill(this.telecomDataSet2.Голосовой_трафик);
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
        }

        private void передачаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "telecomDataSet3.Передача_данных". При необходимости она может быть перемещена или удалена.
            this.передача_данныхTableAdapter.Fill(this.telecomDataSet3.Передача_данных);
            dataGridView3.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
        }

        private void базыДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "telecomDataSet4.Базовые_станции". При необходимости она может быть перемещена или удалена.
            this.базовые_станцииTableAdapter.Fill(this.telecomDataSet4.Базовые_станции);
            dataGridView4.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void убратьТаблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
        }

        private void дневнойТрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmvsp1 = new Form2_();
            frmvsp1.ShowDialog();
        }


        private void трафикПоБазамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmvsp2 = new Form2();
            frmvsp2.ShowDialog();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
