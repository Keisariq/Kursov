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
    public partial class Form2_ : Form
    {
        public Form2_()
        {
            InitializeComponent();
        }

        private void Form2__Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                // Отменяем все выбранные элементы, кроме текущего
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                // Отменяем все выбранные элементы, кроме текущего
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        checkedListBox2.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string valueDate = null;
            string valueBase = null;
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите данные для анализа");
                return;
            }
            if (checkedListBox2.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите данные для анализа");
                return;
            }
            // Проверка выбранных элементов в первом CheckedListBox
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                // Взять значение первого выбранного элемента из первого CheckedListBox
                valueDate = checkedListBox1.CheckedItems[0].ToString();
            }

            // Проверка выбранных элементов во втором CheckedListBox
            if (checkedListBox2.CheckedItems.Count > 0)
            {
                // Взять значение первого выбранного элемента из второго CheckedListBox
                valueBase = checkedListBox2.CheckedItems[0].ToString();
            }
            var frmGist2 = new Form4(valueDate, valueBase);
            frmGist2.ShowDialog();
        }
    }
}
