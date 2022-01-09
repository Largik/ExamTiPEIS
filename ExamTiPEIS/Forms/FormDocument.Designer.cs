namespace ExamTiPEIS.Forms
{
    partial class FormDocument
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePickerDateVisit = new System.Windows.Forms.DateTimePicker();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxComplaints = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxDiagnosis = new System.Windows.Forms.TextBox();
            this.labelDiagnosis = new System.Windows.Forms.Label();
            this.textBoxPrescribe = new System.Windows.Forms.TextBox();
            this.labelPrescribe = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelVisit = new System.Windows.Forms.Label();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.comboBoxPatient = new System.Windows.Forms.ComboBox();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.labelPatient = new System.Windows.Forms.Label();
            this.checkBoxRecovery = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePickerDateVisit
            // 
            this.dateTimePickerDateVisit.Location = new System.Drawing.Point(134, 9);
            this.dateTimePickerDateVisit.Name = "dateTimePickerDateVisit";
            this.dateTimePickerDateVisit.Size = new System.Drawing.Size(154, 20);
            this.dateTimePickerDateVisit.TabIndex = 29;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.comboBoxType.Location = new System.Drawing.Point(134, 89);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(154, 21);
            this.comboBoxType.TabIndex = 28;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // textBoxComplaints
            // 
            this.textBoxComplaints.Location = new System.Drawing.Point(134, 116);
            this.textBoxComplaints.Multiline = true;
            this.textBoxComplaints.Name = "textBoxComplaints";
            this.textBoxComplaints.Size = new System.Drawing.Size(154, 46);
            this.textBoxComplaints.TabIndex = 27;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(75, 119);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(53, 13);
            this.labelAddress.TabIndex = 26;
            this.labelAddress.Text = "Жалобы:";
            // 
            // textBoxDiagnosis
            // 
            this.textBoxDiagnosis.Location = new System.Drawing.Point(134, 172);
            this.textBoxDiagnosis.Name = "textBoxDiagnosis";
            this.textBoxDiagnosis.Size = new System.Drawing.Size(154, 20);
            this.textBoxDiagnosis.TabIndex = 25;
            // 
            // labelDiagnosis
            // 
            this.labelDiagnosis.AutoSize = true;
            this.labelDiagnosis.Location = new System.Drawing.Point(74, 175);
            this.labelDiagnosis.Name = "labelDiagnosis";
            this.labelDiagnosis.Size = new System.Drawing.Size(54, 13);
            this.labelDiagnosis.TabIndex = 24;
            this.labelDiagnosis.Text = "Диагноз:";
            // 
            // textBoxPrescribe
            // 
            this.textBoxPrescribe.Location = new System.Drawing.Point(134, 198);
            this.textBoxPrescribe.Multiline = true;
            this.textBoxPrescribe.Name = "textBoxPrescribe";
            this.textBoxPrescribe.Size = new System.Drawing.Size(154, 59);
            this.textBoxPrescribe.TabIndex = 23;
            // 
            // labelPrescribe
            // 
            this.labelPrescribe.AutoSize = true;
            this.labelPrescribe.Location = new System.Drawing.Point(57, 201);
            this.labelPrescribe.Name = "labelPrescribe";
            this.labelPrescribe.Size = new System.Drawing.Size(71, 13);
            this.labelPrescribe.TabIndex = 22;
            this.labelPrescribe.Text = "Назначение:";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(58, 92);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(70, 13);
            this.labelType.TabIndex = 21;
            this.labelType.Text = "Тип приема:";
            // 
            // labelVisit
            // 
            this.labelVisit.AutoSize = true;
            this.labelVisit.Location = new System.Drawing.Point(51, 9);
            this.labelVisit.Name = "labelVisit";
            this.labelVisit.Size = new System.Drawing.Size(77, 13);
            this.labelVisit.TabIndex = 20;
            this.labelVisit.Text = "Дата приема:";
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Location = new System.Drawing.Point(65, 38);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(63, 13);
            this.labelEmployee.TabIndex = 18;
            this.labelEmployee.Text = "Сотрудник:";
            // 
            // comboBoxPatient
            // 
            this.comboBoxPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPatient.FormattingEnabled = true;
            this.comboBoxPatient.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.comboBoxPatient.Location = new System.Drawing.Point(134, 62);
            this.comboBoxPatient.Name = "comboBoxPatient";
            this.comboBoxPatient.Size = new System.Drawing.Size(154, 21);
            this.comboBoxPatient.TabIndex = 30;
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmployee.FormattingEnabled = true;
            this.comboBoxEmployee.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.comboBoxEmployee.Location = new System.Drawing.Point(134, 35);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(154, 21);
            this.comboBoxEmployee.TabIndex = 31;
            // 
            // labelPatient
            // 
            this.labelPatient.AutoSize = true;
            this.labelPatient.Location = new System.Drawing.Point(75, 65);
            this.labelPatient.Name = "labelPatient";
            this.labelPatient.Size = new System.Drawing.Size(53, 13);
            this.labelPatient.TabIndex = 32;
            this.labelPatient.Text = "Пациент:";
            // 
            // checkBoxRecovery
            // 
            this.checkBoxRecovery.AutoSize = true;
            this.checkBoxRecovery.Location = new System.Drawing.Point(168, 263);
            this.checkBoxRecovery.Name = "checkBoxRecovery";
            this.checkBoxRecovery.Size = new System.Drawing.Size(95, 17);
            this.checkBoxRecovery.TabIndex = 33;
            this.checkBoxRecovery.Text = "Выздоровлен";
            this.checkBoxRecovery.UseVisualStyleBackColor = true;
            this.checkBoxRecovery.Visible = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(103, 291);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 34;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(213, 291);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 35;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 344);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.checkBoxRecovery);
            this.Controls.Add(this.labelPatient);
            this.Controls.Add(this.comboBoxEmployee);
            this.Controls.Add(this.comboBoxPatient);
            this.Controls.Add(this.dateTimePickerDateVisit);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxComplaints);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textBoxDiagnosis);
            this.Controls.Add(this.labelDiagnosis);
            this.Controls.Add(this.textBoxPrescribe);
            this.Controls.Add(this.labelPrescribe);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelVisit);
            this.Controls.Add(this.labelEmployee);
            this.Name = "FormDocument";
            this.Text = "Запись на прем";
            this.Load += new System.EventHandler(this.FormDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerDateVisit;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxComplaints;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxDiagnosis;
        private System.Windows.Forms.Label labelDiagnosis;
        private System.Windows.Forms.TextBox textBoxPrescribe;
        private System.Windows.Forms.Label labelPrescribe;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelVisit;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.ComboBox comboBoxPatient;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
        private System.Windows.Forms.Label labelPatient;
        private System.Windows.Forms.CheckBox checkBoxRecovery;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}