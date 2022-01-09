using ExamTiPEIS.Forms;
using System;
using System.Windows.Forms;

namespace ExamTiPEIS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormEmployee();
            form.Show();
        }

        private void пациентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormPatient();
            form.Show();
        }

        private void приемВрачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormDocumentList();
            form.Show();
        }

        private void приемПациентовПоПериодуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormReport();
            form.Show();
        }
    }
}
