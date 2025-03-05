using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Задание_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitDataGridView();
        }


        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        private DataGridViewColumn dataGridViewColumn4 = null;
        private DataGridViewColumn dataGridViewColumn5 = null;

        private IList<Student> studentList = new List<Student>();
        


        //Инициализация таблицы
        private void InitDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(GetDataGridViewColumn1());
            dataGridView1.Columns.Add(GetDataGridViewColumn2());
            dataGridView1.Columns.Add(GetDataGridViewColumn3());
            dataGridView1.Columns.Add(GetDataGridViewColumn4());
            dataGridView1.Columns.Add(GetDataGridViewColumn5());
            dataGridView1.AutoResizeColumns();
        }
        //Динамическое создание первой колонки в таблице
        private DataGridViewColumn GetDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
        {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Имя";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn1;
        }
        //Динамическое создание второй колонки в таблице
        private DataGridViewColumn GetDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Фамилия";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn2;
        }
        //Динамическое создание третей колонки в таблице
        private DataGridViewColumn GetDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
        {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Зачетка";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn3;
        }
        private DataGridViewColumn GetDataGridViewColumn4()
        {
            if (dataGridViewColumn4 == null)
            {
                dataGridViewColumn4 = new DataGridViewTextBoxColumn();
                dataGridViewColumn4.Name = "";
                dataGridViewColumn4.HeaderText = "Группа";
                dataGridViewColumn4.ValueType = typeof(string);
                dataGridViewColumn4.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn4;
        }
        private DataGridViewColumn GetDataGridViewColumn5()
        {
            if (dataGridViewColumn5 == null)
            {
                dataGridViewColumn5 = new DataGridViewTextBoxColumn();
                dataGridViewColumn5.Name = "";
                dataGridViewColumn5.HeaderText = "Статус";
                dataGridViewColumn5.ValueType = typeof(string);
                dataGridViewColumn5.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn5;
        }


        private void addStudent(string name, string surname, string recordBookNumbe, string group, string status)
        {
            bool exists = studentList.Any(s => s.GetName() == name && s.GetSurname() == surname && s.GetRecordBookNumber() == recordBookNumbe && s.GetGroup() == group && s.GetStatus() == status);

            if (exists)
            {
                MessageBox.Show("Ошибка. Такой студент уже есть");
                return;
            }

            studentList.Add(new Student(name, surname, recordBookNumbe, group, status));
            showListInGrid();
        }
        //Удаление студента с колекции
        private void deleteStudent(int elementIndex)
        {
            studentList.RemoveAt(elementIndex);
            showListInGrid();
        }

        private void editStudent(int elementIndex)
        {
            studentList.RemoveAt(elementIndex);

            string name = textBox1.Text;
            string surname = textBox2.Text;
            string recordBookNumber = textBox3.Text;
            string group = textBox4.Text;
            string status = textBox5.Text;

            studentList.Add(new Student(name, surname, recordBookNumber, group, status));
            showListInGrid();
        }

        //Отображение колекции в таблице
        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Student s in studentList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell4 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell5 = new
                DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = s.GetName();
                cell2.ValueType = typeof(string);
                cell2.Value = s.GetSurname();
                cell3.ValueType = typeof(string);
                cell3.Value = s.GetRecordBookNumber();
                cell4.ValueType = typeof(string);
                cell4.Value = s.GetGroup();
                cell5.ValueType = typeof(string);
                cell5.Value = s.GetStatus();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                dataGridView1.Rows.Add(row);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string recordBookNumber = textBox3.Text;
            string group = textBox4.Text;
            string status = textBox5.Text;

            if (name != string.Empty && surname != string.Empty && recordBookNumber != string.Empty && group != string.Empty && status != string.Empty) 
            {
                addStudent(name, surname, recordBookNumber, group, status);

            }
            else
            {
                MessageBox.Show("Ошибка. Заполните все поля");
            }


        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Удалить студента?", "",
            MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    deleteStudent(selectedRow);
                }
                catch (Exception)
                {
                }
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Редактировать студента?", "",
            MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    editStudent(selectedRow);
                }
                catch (Exception)
                {
                }
            }
        }

        private void fddfdfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

