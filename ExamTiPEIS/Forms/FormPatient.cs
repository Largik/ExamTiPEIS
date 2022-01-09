using ExamTiPEIS.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExamTiPEIS.Forms
{
    public partial class FormPatient : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TipEIS;Integrated Security=True;MultipleActiveResultSets=True;";
        public FormPatient()
        {
            InitializeComponent();
        }
        private async void LoadData()
        {
            List<Patient> list = new List<Patient>();
           
            string sqlExpression = "select * from Patient";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    list.Add(new Patient
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        FIO = reader.GetValue(1).ToString(),
                        DateBorn = DateTime.Parse(reader.GetValue(2).ToString()),
                        Gender = reader.GetValue(3).ToString(),
                        Address = reader.GetValue(4).ToString(),
                        Number = Convert.ToInt32(reader.GetValue(5)),
                        Comment = reader.GetValue(6).ToString()
                    });
                }

                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].HeaderText = "ФИО";
                dataGridView.Columns[2].HeaderText = "Дата рождения";
                dataGridView.Columns[3].HeaderText = "Пол";
                dataGridView.Columns[4].HeaderText = "Адрес";
                dataGridView.Columns[5].HeaderText = "Контактный телефон";
                dataGridView.Columns[6].HeaderText = "Комментарий";

                connection.Close();
            }
            textBoxFIO.Clear();
            dateTimePickerBorn.Value = DateTime.Now;
            textBoxAddress.Clear();
            textBoxNumber.Clear();
            textBoxComment.Clear();
            dataGridView.ClearSelection();
        }
        private void FormPatient_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
            {
                string sqlExpression = $"insert into Patient(FIO, DateBorn, Gender, Address, Number, Comment)" +
                    $" values(N'{textBoxFIO.Text}'," +
                    $"N'{Convert.ToDateTime(dateTimePickerBorn.Value.ToShortDateString())}', " +
                    $"N'{comboBoxGender.Text}', " +
                    $"N'{textBoxAddress.Text}', " +
                    $"{Convert.ToInt32(textBoxNumber.Text)}," +
                    $"N'{textBoxComment.Text}')";
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
                string sqlExpression = $"update Patient set " +
                    $"FIO = N'{textBoxFIO.Text}'," +
                    $"DateBorn = '{Convert.ToDateTime(dateTimePickerBorn.Value.ToShortDateString())}'," +
                    $"Gender = N'{comboBoxGender.Text}'," +
                    $"Address = N'{textBoxAddress.Text}'," +
                    $"Number = {Convert.ToInt32(textBoxNumber.Text)}," +
                    $"Comment N'{textBoxComment.Text}' where Id = {dataGridView.SelectedRows[0].Cells[0].Value} ";
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
           
            string sqlExpression = $"delete from Patient where Id = {dataGridView.SelectedRows[0].Cells[0].Value} ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                connection.Close();
            }

            LoadData();
        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '.') && (textBoxNumber.Text.IndexOf(".") == -1) && (textBoxNumber.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void dataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 0)
            {
                textBoxFIO.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                dateTimePickerBorn.Value = Convert.ToDateTime(dataGridView.SelectedRows[0].Cells[2].Value);
                if(dataGridView.SelectedRows[0].Cells[3].Value.ToString() == "Мужской")
                {
                    comboBoxGender.SelectedValue = 0;
                }
                if(dataGridView.SelectedRows[0].Cells[3].Value.ToString() == "Женский")
                {
                    comboBoxGender.SelectedValue = 1;
                }
                textBoxAddress.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                textBoxNumber.Text = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                textBoxComment.Text = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
            }
        }
        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Поле \"ФИО\" должно быть заполнено", "Ошибка");
                return false;
            }
            if (dateTimePickerBorn.Value > DateTime.Now)
            {
                MessageBox.Show("Дата рождения не может быть будущего времени", "Ошибка");
                return false;
            }
            if (comboBoxGender.SelectedItem == null)
            {
                MessageBox.Show("Пол должен быть выбран", "Ошибка");
                return false;
            }
            if (string.IsNullOrEmpty(textBoxAddress.Text))
            {
                MessageBox.Show("Поле \"Адрес\" должно быть заполнено", "Ошибка");
                return false;
            }
            if (string.IsNullOrEmpty(textBoxNumber.Text))
            {
                MessageBox.Show("Поле \"Контактный номер\" должно быть заполнено", "Ошибка");
                return false;
            }
            if (!Regex.IsMatch(textBoxFIO.Text, @"^[а-яА-яa-zA-Z ]+$"))
            {
                MessageBox.Show("Наименование может содержать только буквы и пробелы", "Ошибка");
                return false;
            }
            return true;
        }
    }
}
