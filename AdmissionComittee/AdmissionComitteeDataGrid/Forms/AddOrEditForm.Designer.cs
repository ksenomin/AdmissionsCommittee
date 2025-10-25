namespace AdmissionComitteeDataGrid.Forms
{
    partial class AddOrEditForm
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
            textBoxFullName = new TextBox();
            labelFullName = new Label();
            labelGender = new Label();
            comboBoxGender = new ComboBox();
            dateTimePickerBirthDate = new DateTimePicker();
            labelDateBirth = new Label();
            labelStudyForm = new Label();
            comboBoxStudyForm = new ComboBox();
            numericUpDownMath = new NumericUpDown();
            numericUpDownRussian = new NumericUpDown();
            numericUpDownInformatic = new NumericUpDown();
            labelMath = new Label();
            labelRussian = new Label();
            labelInformatic = new Label();
            buttonAddOrEdit = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMath).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRussian).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInformatic).BeginInit();
            SuspendLayout();
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(206, 129);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(223, 27);
            textBoxFullName.TabIndex = 0;
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Location = new Point(158, 132);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(42, 20);
            labelFullName.TabIndex = 1;
            labelFullName.Text = "ФИО";
            // 
            // labelGender
            // 
            labelGender.AutoSize = true;
            labelGender.Location = new Point(158, 187);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(37, 20);
            labelGender.TabIndex = 2;
            labelGender.Text = "Пол";
            // 
            // comboBoxGender
            // 
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Location = new Point(206, 184);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(223, 28);
            comboBoxGender.TabIndex = 3;
            // 
            // dateTimePickerBirthDate
            // 
            dateTimePickerBirthDate.Location = new Point(206, 232);
            dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            dateTimePickerBirthDate.Size = new Size(223, 27);
            dateTimePickerBirthDate.TabIndex = 4;
            // 
            // labelDateBirth
            // 
            labelDateBirth.AutoSize = true;
            labelDateBirth.Location = new Point(84, 236);
            labelDateBirth.Name = "labelDateBirth";
            labelDateBirth.Size = new Size(116, 20);
            labelDateBirth.TabIndex = 5;
            labelDateBirth.Text = "Дата рождения";
            // 
            // labelStudyForm
            // 
            labelStudyForm.AutoSize = true;
            labelStudyForm.Location = new Point(72, 283);
            labelStudyForm.Name = "labelStudyForm";
            labelStudyForm.Size = new Size(128, 20);
            labelStudyForm.TabIndex = 6;
            labelStudyForm.Text = "Форма обучения";
            // 
            // comboBoxStudyForm
            // 
            comboBoxStudyForm.FormattingEnabled = true;
            comboBoxStudyForm.Location = new Point(206, 279);
            comboBoxStudyForm.Name = "comboBoxStudyForm";
            comboBoxStudyForm.Size = new Size(223, 28);
            comboBoxStudyForm.TabIndex = 7;
            // 
            // numericUpDownMath
            // 
            numericUpDownMath.Location = new Point(206, 331);
            numericUpDownMath.Name = "numericUpDownMath";
            numericUpDownMath.Size = new Size(223, 27);
            numericUpDownMath.TabIndex = 8;
            // 
            // numericUpDownRussian
            // 
            numericUpDownRussian.Location = new Point(206, 382);
            numericUpDownRussian.Name = "numericUpDownRussian";
            numericUpDownRussian.Size = new Size(223, 27);
            numericUpDownRussian.TabIndex = 9;
            // 
            // numericUpDownInformatic
            // 
            numericUpDownInformatic.Location = new Point(206, 434);
            numericUpDownInformatic.Name = "numericUpDownInformatic";
            numericUpDownInformatic.Size = new Size(223, 27);
            numericUpDownInformatic.TabIndex = 10;
            // 
            // labelMath
            // 
            labelMath.AutoSize = true;
            labelMath.Location = new Point(39, 334);
            labelMath.Name = "labelMath";
            labelMath.Size = new Size(161, 20);
            labelMath.TabIndex = 11;
            labelMath.Text = "Баллы по математике";
            // 
            // labelRussian
            // 
            labelRussian.AutoSize = true;
            labelRussian.Location = new Point(57, 384);
            labelRussian.Name = "labelRussian";
            labelRussian.Size = new Size(143, 20);
            labelRussian.TabIndex = 12;
            labelRussian.Text = "Баллы по русскому";
            // 
            // labelInformatic
            // 
            labelInformatic.AutoSize = true;
            labelInformatic.Location = new Point(26, 436);
            labelInformatic.Name = "labelInformatic";
            labelInformatic.Size = new Size(174, 20);
            labelInformatic.TabIndex = 13;
            labelInformatic.Text = "Баллы по информатике";
            // 
            // buttonAddOrEdit
            // 
            buttonAddOrEdit.Location = new Point(57, 518);
            buttonAddOrEdit.Name = "buttonAddOrEdit";
            buttonAddOrEdit.Size = new Size(173, 62);
            buttonAddOrEdit.TabIndex = 14;
            buttonAddOrEdit.Text = "buttonAddOrEdit";
            buttonAddOrEdit.UseVisualStyleBackColor = true;
            buttonAddOrEdit.Click += buttonAddOrEdit_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(302, 518);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(173, 62);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // AddOrEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 623);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAddOrEdit);
            Controls.Add(labelInformatic);
            Controls.Add(labelRussian);
            Controls.Add(labelMath);
            Controls.Add(numericUpDownInformatic);
            Controls.Add(numericUpDownRussian);
            Controls.Add(numericUpDownMath);
            Controls.Add(comboBoxStudyForm);
            Controls.Add(labelStudyForm);
            Controls.Add(labelDateBirth);
            Controls.Add(dateTimePickerBirthDate);
            Controls.Add(comboBoxGender);
            Controls.Add(labelGender);
            Controls.Add(labelFullName);
            Controls.Add(textBoxFullName);
            MaximumSize = new Size(538, 670);
            MinimumSize = new Size(538, 670);
            Name = "AddOrEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddOrEditForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDownMath).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRussian).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInformatic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFullName;
        private Label labelFullName;
        private Label labelGender;
        private ComboBox comboBoxGender;
        private DateTimePicker dateTimePickerBirthDate;
        private Label labelDateBirth;
        private Label labelStudyForm;
        private ComboBox comboBoxStudyForm;
        private NumericUpDown numericUpDownMath;
        private NumericUpDown numericUpDownRussian;
        private NumericUpDown numericUpDownInformatic;
        private Label labelMath;
        private Label labelRussian;
        private Label labelInformatic;
        private Button buttonAddOrEdit;
        private Button buttonCancel;
    }
}
