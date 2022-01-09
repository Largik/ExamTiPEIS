using ExamTiPEIS.DB.Models;
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

namespace ExamTiPEIS.Forms
{
    public partial class FormDocumentList : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TipEIS;Integrated Security=True;MultipleActiveResultSets=True;";
        
        public FormDocumentList()
        {
            InitializeComponent();
        }

        private void FormDocumentList_Load(object sender, EventArgs e)
        {
            dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dateTimePickerTo.Value = new DateTime(DateTime.Now.Year, 12, 31);
            LoadData();
        }

        private async void LoadData()
        {
            List<Visit> list = new List<Visit>();

            string sqlExpression = "select * from Visit";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                Search(list, reader);

                connection.Close();
            }

            dataGridView.ClearSelection();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormDocument form = new FormDocument(null);

            form.ShowDialog();

            LoadData();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                FormDocument form = new FormDocument(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                
                form.ShowDialog();
                
                LoadData();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            string sqlExpression = $"delete from Visit where Id = {dataGridView.SelectedRows[0].Cells[0].Value} ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                connection.Close();
            }

            LoadData();
        }

        private async void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            List<Visit> list = new List<Visit>();

            string sqlExpression = $"select * from Visit where " +
                $"(Type Like N'%{textBoxSearch.Text}%' or " +
                $"Complaints Like N'%{textBoxSearch.Text}%' or " +
                $"Diagnosis Like N'%{textBoxSearch.Text}%' or " +
                $"Prescribe Like N'%{textBoxSearch.Text}%')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                Search(list, reader);

                connection.Close();
            }

            dataGridView.ClearSelection();

        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            ChangedDateSearch();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            ChangedDateSearch();
        }

        private async void ChangedDateSearch()
        {
            List<Visit> list = new List<Visit>();

            string sqlExpression = $"select * from Visit where DateVisit BETWEEN '{dateTimePickerFrom.Value.ToShortDateString()}' and '{dateTimePickerTo.Value.ToShortDateString()}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                Search(list, reader);

                connection.Close();
            }

            dataGridView.ClearSelection();
        }

        private async void Search(List<Visit> list, SqlDataReader reader)
        {

            while (await reader.ReadAsync())
            {
                DateTime? date = null;
                if (!reader.IsDBNull(8) || reader.GetValue(8).ToString() == "1/01/1900")
                {
                    date = Convert.ToDateTime(reader.GetValue(8).ToString());
                }

                list.Add(new Visit
                {
                    Id = Convert.ToInt32(reader.GetValue(0)),
                    DateVisit = Convert.ToDateTime(reader.GetValue(1)),
                    Type = reader.GetValue(2).ToString(),
                    PatientId = Convert.ToInt32(reader.GetValue(3)),
                    EmployeeId = Convert.ToInt32(reader.GetValue(4)),
                    Сomplaints = reader.GetValue(5).ToString(),
                    Diagnosis = reader.GetValue(6).ToString(),
                    Prescribe = reader.GetValue(7).ToString(),
                    DateRecovery = date
                });
            }

            dataGridView.DataSource = list;
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[1].HeaderText = "Дата приема";
            dataGridView.Columns[2].HeaderText = "Тип";
            dataGridView.Columns[5].HeaderText = "Жалобы";
            dataGridView.Columns[6].HeaderText = "Диагноз";
            dataGridView.Columns[7].HeaderText = "Лечение";
            dataGridView.Columns[8].HeaderText = "Дата выздоровления";
            dataGridView.Columns[3].Visible = false;
            dataGridView.Columns[4].Visible = false;
        }
    }
}
