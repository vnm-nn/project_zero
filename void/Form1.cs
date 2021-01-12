using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MaterialSkin.Controls;

namespace xml_writer
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e) //Добавление данных в форму
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните все поля.", "Ошибка.");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[3].Value = comboBox2.Text;
                dataGridView1.Rows[n].Cells[4].Value = textBox2.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e) //сохранение данных из формы в XML
        {
            try
            {
                DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
                DataTable dt = new DataTable(); // создаем пока что пустую таблицу данных
                dt.TableName = "Employee"; // название таблицы
                dt.Columns.Add("Name"); // название колонок
                dt.Columns.Add("Param_1");
                dt.Columns.Add("Param_2");
                dt.Columns.Add("Param_3");
                dt.Columns.Add("Param_4");
                ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше

                foreach (DataGridViewRow r in dataGridView1.Rows) // пока в dataGridView1 есть строки
                {
                    DataRow row = ds.Tables["Employee"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                    row["Name"] = r.Cells[0].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                    row["Param_1"] = r.Cells[1].Value; // то же самое со вторыми столбцами
                    row["Param_2"] = r.Cells[2].Value; //то же самое с третьими столбцами
                    row["Param_3"] = r.Cells[3].Value; //то же самое с последубщими столбцами
                    row["Param_4"] = r.Cells[4].Value; //то же самое с последубщими столбцами
                    ds.Tables["Employee"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
                }
                ds.WriteXml("D:\\Data.xml"); //место расположения xml файла
                MessageBox.Show("Файл успешно сохранен.", "Выполнено.");
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить файл.", "Ошибка.");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e) // выбор нужной строки для редактирования
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            numericUpDown1.Value = n;
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e) //редактирование
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = comboBox2.Text;
                dataGridView1.Rows[n].Cells[3].Value = comboBox2.Text;
                dataGridView1.Rows[n].Cells[4].Value = textBox2.Text;
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования.", "Соберись.");
            }
        }

        private void button3_Click(object sender, EventArgs e) //удалить выбранную строку
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Список пуст!.", "Ошибка.");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
