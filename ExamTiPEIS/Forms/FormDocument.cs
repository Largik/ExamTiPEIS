using ExamTiPEIS.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamTiPEIS.Forms
{
    public partial class FormDocument : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TipEIS;Integrated Security=True;MultipleActiveResultSets=True;";

        private int? id;
        public FormDocument(int? code)
        {
            InitializeComponent(); 
            LoadComboBoxItems();
            this.id = code;
        }

        private async void LoadComboBoxItems()
        {
            comboBoxType.DataSource = new List<string>
            {
                "Первичный",
                "Повторный"
            };
            comboBoxType.SelectedItem = null;

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
                        FIO = reader.GetValue(1).ToString()
                    });
                }

                connection.Close();
            }

            if (list != null)
            {
                comboBoxEmployee.DisplayMember = "FIO";
                comboBoxEmployee.ValueMember = "Id";
                comboBoxEmployee.DataSource = list;
                comboBoxEmployee.SelectedItem = null;
            } 
            
            List<Patient> listP = new List<Patient>();

            string sqlExpressionP = "select * from Patient";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpressionP, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    listP.Add(new Patient
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        FIO = reader.GetValue(1).ToString()
                    });
                }


                connection.Close();
            }

            if (listP != null)
            {
                comboBoxPatient.DisplayMember = "FIO";
                comboBoxPatient.ValueMember = "Id";
                comboBoxPatient.DataSource = listP;
                comboBoxPatient.SelectedItem = null;
            }
        }

        private void FormDocument_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            if (id.HasValue)
            {
                string sqlExpression = $"select * from Visit where Id = {id}";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();


                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    await reader.ReadAsync();

                    //dateTimePickerDateVisit.Value = DateTime.Parse(reader.GetValue(2).ToString());
                    comboBoxType.Text = reader.GetValue(2).ToString();
                    textBoxComplaints.Text = Convert.ToDecimal(reader.GetValue(5)).ToString();
                    textBoxDiagnosis.Text = Convert.ToDecimal(reader.GetValue(6)).ToString();
                    textBoxPrescribe.Text = Convert.ToDecimal(reader.GetValue(7)).ToString();
                    comboBoxEmployee.SelectedValue = Convert.ToInt32(reader.GetValue(4)); 
                    comboBoxPatient.SelectedValue = Convert.ToInt32(reader.GetValue(3));
                    connection.Close();
                }
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxType.SelectedIndex == 1)
            {
                checkBoxRecovery.Visible = true;
            }
            else
            {
                checkBoxRecovery.Visible = false;
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxType.Text))
            {
                MessageBox.Show("Поле \"Тип\" должно быть заполнено", "Ошибка");
                return;
            }
            if (comboBoxPatient.SelectedItem == null)
            {
                MessageBox.Show("Пациент должен быть выбран", "Ошибка");
                return;
            }
            if (comboBoxEmployee.SelectedItem == null)
            {
                MessageBox.Show("Сотрудник должен быть выбран", "Ошибка");
                return;
            }
            if (string.IsNullOrEmpty(textBoxComplaints.Text))
            {
                MessageBox.Show("Поле \"Жалобы\" должно быть заполнено", "Ошибка");
                return;
            }
            if (string.IsNullOrEmpty(textBoxDiagnosis.Text))
            {
                MessageBox.Show("Поле \"Диагноз\" должно быть заполнено", "Ошибка");
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrescribe.Text))
            {
                MessageBox.Show("Поле \"Назначение\" должно быть заполнено", "Ошибка");
                return;
            }

            DateTime? date = null;

            if (checkBoxRecovery.Checked)
            {
                date = DateTime.Now;
            }

            if (id.HasValue)
            {
                string sqlExpression = $"update Visit set " +
                    $"DateVisit = N'{Convert.ToDateTime(dateTimePickerDateVisit.Value.ToShortDateString())}'," +
                    $"Type = N'{comboBoxType.Text}'," +
                    $"PatientId = N'{Convert.ToInt32(comboBoxPatient.SelectedValue)}'," +
                    $"EmployeeId = N'{Convert.ToInt32(comboBoxEmployee.SelectedValue)}'," +
                    $"Complaints = N'{textBoxComplaints.Text}'," +
                    $"Diagnosis = N'{textBoxDiagnosis.Text}'," +
                    $"Prescribe = N'{textBoxPrescribe.Text}'," +
                    $"DateRecovery = N'{date}' where Id = {id} ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    connection.Close();
                }

                LoadData();
            }
            else
            {
                string sqlExpression = $"insert into Visit(DateVisit, Type, PatientId, EmployeeId, Complaints, Diagnosis, Prescribe, DateRecovery)" +
                    $" values(N'{Convert.ToDateTime(dateTimePickerDateVisit.Value.ToShortDateString())}'," +
                    $"N'{comboBoxType.Text}', " +
                    $"N'{Convert.ToInt32(comboBoxPatient.SelectedValue)}', " +
                    $"N'{Convert.ToInt32(comboBoxEmployee.SelectedValue)}', " +
                    $"N'{textBoxComplaints.Text}', " +
                    $"N'{textBoxDiagnosis.Text}', " +
                    $"N'{textBoxPrescribe.Text}', " +
                    $"N'{date}')";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    connection.Close();
                }

                DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
