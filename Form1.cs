using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZarplataLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        database db = new database("127.0.0.1", "root", "", "zarplatalab");
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string otch = textBox3.Text;         
            var end = db.download(name, surname, otch);
            if (end != -1)
            {
                label1.Text = String.Format("Успешно. Добавленный id: {0}", end);
            }
            else
            {
                label1.Text = ("Ошибка добавления.");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string otch = textBox3.Text;        
            List<string> end = db.see(name, surname, otch);
            if (end.Count > 0)
            {
                label2.Text = "";
                foreach (var a in end)
                {
                    label2.Text += "\n" +a;
                }
            }
            else
            {
                label2.Text = "Ошибка вывода.";
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string status = textBox4.Text;
            string money = textBox5.Text;
            int fio_id = (int)numericUpDown1.Value;
            var end = db.download2(status, money, fio_id);
            if (end != -1)
            {
                label1.Text = String.Format("Успешно", end);
            }
            else
            {
                label1.Text = ("Ошибка добавления.");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string status = textBox4.Text;
            string money = textBox5.Text;
            int fio_id = (int)numericUpDown1.Value;
            List<string> end = db.see2(status, money, fio_id);
            if (end.Count > 0)
            {
                label2.Text = "";
                foreach (var a in end)
                {
                    label2.Text += "\n" + a;
                }
            }
            else
            {
                label2.Text = "Ошибка вывода.";
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // comboBox1.SelectedValue;
           //использовать для связки Бд для того, чтобы потом сделать нормальное заполнение и выбор фамилии
        }
    }
}
