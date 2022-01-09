using ExamTiPEIS.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExamTiPEIS.Forms
{
    public partial class FormEmployee : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TipEIS;Integrated Security=True;MultipleActiveResultSets=True;";

        public FormEmployee()
        {
            InitializeComponent();
        }

        private async void LoadData()
        {
            List<Employee> list = new List<Employee>();

            string sqlExpression = "select * from Employee";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    list.Add(new Employee
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        FIO = reader.GetValue(1).ToString(),
                        Department = reader.GetValue(2).ToString(),
                        Post = reader.GetValue(3).ToString(),
                        Category = reader.GetValue(4).ToString()
                    });
                }

                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].HeaderText = "ФИО";
                dataGridView.Columns[2].HeaderText = "Отделение";
                dataGridView.Columns[3].HeaderText = "Должность";
                dataGridView.Columns[4].HeaderText = "Категория";

                connection.Close();
            }
            textBoxFIO.Clear();
            textBoxDepartment.Clear();
            textBoxPost.Clear();
            textBoxCategory.Clear();
            dataGridView.ClearSelection();
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
            {
                string sqlExpression = $"insert into Employee(FIO, Department, Post, Category)" +
                    $" values(N'{textBoxFIO.Text}'," +
                   $"N'{textBoxDepartment.Text}'," +
                   $"N'{textBoxPost.Text}'," +
                   $"N'{textBoxCategory.Text}')";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    connection.Close();
                }

                LoadData();
            }
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
            {
                if (dataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Не выбрана строка на изменение", "Ошибка");
                    return;
                }

                string sqlExpression = $"update Employee set " +
                    $"FIO = N'{textBoxFIO.Text}'," +
                    $"Department = N'{textBoxDepartment.Text}'," +
                    $"Post = N'{textBoxPost.Text}'," +
                    $"Category N'{textBoxCategory.Text}' where Id = {dataGridView.SelectedRows[0].Cells[0].Value} ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    connection.Close();
                }

                LoadData();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            string sqlExpression = $"delete from Employee where Id = {dataGridView.SelectedRows[0].Cells[0].Value} ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                connection.Close();
            }

            LoadData();
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Поле \"ФИО\" должно быть заполнено", "Ошибка");
                return false;
            }
            if (string.IsNullOrEmpty(textBoxDepartment.Text))
            {
                MessageBox.Show("Поле \"Отделение\" должно быть заполнено", "Ошибка");
                return false;
            }
            if (string.IsNullOrEmpty(textBoxPost.Text))
            {
                MessageBox.Show("Поле \"Должность\" должно быть заполнено", "Ошибка");
                return false;
            }
            if (string.IsNullOrEmpty(textBoxCategory.Text))
            {
                MessageBox.Show("Поле \"Категория\" должно быть заполнено", "Ошибка");
                return false;
            }
            if (!Regex.IsMatch(textBoxFIO.Text, @"^[а-яА-яa-zA-Z ]+$") || !Regex.IsMatch(textBoxPost.Text, @"^[а-яА-яa-zA-Z ]+$"))
            {
                MessageBox.Show("Поля \"ФИО\", \"Должность\" может содержать только буквы и пробелы", "Ошибка");
                return false;
            }
            return true;
        }

        private void dataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 0)
            {
                textBoxFIO.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                textBoxDepartment.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                textBoxPost.Text = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                textBoxCategory.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
            }
        }
    }
}
