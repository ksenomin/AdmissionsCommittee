﻿namespace AdmissionComitteeDataGrid
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            AddToolStripMenuItem = new ToolStripMenuItem();
            EditToolStripMenuItem = new ToolStripMenuItem();
            DeleteToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabelCountApplicants = new ToolStripStatusLabel();
            toolStripStatusLabelApplicants150 = new ToolStripStatusLabel();
            toolStripStatusLabelScoreForSuccess = new ToolStripStatusLabel();
            dataGridView = new DataGridView();
            ColumnFullName = new DataGridViewTextBoxColumn();
            ColumnGender = new DataGridViewComboBoxColumn();
            ColumnDateBirth = new DataGridViewTextBoxColumn();
            ColumnStudyForm = new DataGridViewComboBoxColumn();
            ColumnMathScore = new DataGridViewTextBoxColumn();
            ColumnRussianScore = new DataGridViewTextBoxColumn();
            ColumnInformaticSore = new DataGridViewTextBoxColumn();
            ColumnSumScore = new DataGridViewTextBoxColumn();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1047, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // AddToolStripMenuItem
            // 
            AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            AddToolStripMenuItem.Size = new Size(90, 24);
            AddToolStripMenuItem.Text = "Добавить";
            AddToolStripMenuItem.Click += AddToolStripMenuItem_Click;
            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new Size(125, 24);
            EditToolStripMenuItem.Text = "Редактировать";
            EditToolStripMenuItem.Click += EditToolStripMenuItem_Click;
            // 
            // DeleteToolStripMenuItem
            // 
            DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            DeleteToolStripMenuItem.Size = new Size(79, 24);
            DeleteToolStripMenuItem.Text = "Удалить";
            DeleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelCountApplicants, toolStripStatusLabelApplicants150, toolStripStatusLabelScoreForSuccess });
            statusStrip.Location = new Point(0, 541);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1047, 26);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCountApplicants
            // 
            toolStripStatusLabelCountApplicants.Name = "toolStripStatusLabelCountApplicants";
            toolStripStatusLabelCountApplicants.Size = new Size(151, 20);
            toolStripStatusLabelCountApplicants.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelApplicants150
            // 
            toolStripStatusLabelApplicants150.Name = "toolStripStatusLabelApplicants150";
            toolStripStatusLabelApplicants150.Size = new Size(151, 20);
            toolStripStatusLabelApplicants150.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelScoreForSuccess
            // 
            toolStripStatusLabelScoreForSuccess.Name = "toolStripStatusLabelScoreForSuccess";
            toolStripStatusLabelScoreForSuccess.Size = new Size(151, 20);
            toolStripStatusLabelScoreForSuccess.Text = "toolStripStatusLabel1";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnFullName, ColumnGender, ColumnDateBirth, ColumnStudyForm, ColumnMathScore, ColumnRussianScore, ColumnInformaticSore, ColumnSumScore });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 28);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1047, 513);
            dataGridView.TabIndex = 2;
            // 
            // ColumnFullName
            // 
            ColumnFullName.HeaderText = "ФИО";
            ColumnFullName.MinimumWidth = 6;
            ColumnFullName.Name = "ColumnFullName";
            ColumnFullName.ReadOnly = true;
            // 
            // ColumnGender
            // 
            ColumnGender.HeaderText = "Пол";
            ColumnGender.MinimumWidth = 6;
            ColumnGender.Name = "ColumnGender";
            ColumnGender.ReadOnly = true;
            // 
            // ColumnDateBirth
            // 
            ColumnDateBirth.HeaderText = "Дата рождения";
            ColumnDateBirth.MinimumWidth = 6;
            ColumnDateBirth.Name = "ColumnDateBirth";
            ColumnDateBirth.ReadOnly = true;
            // 
            // ColumnStudyForm
            // 
            ColumnStudyForm.HeaderText = "Форма обучения";
            ColumnStudyForm.MinimumWidth = 6;
            ColumnStudyForm.Name = "ColumnStudyForm";
            ColumnStudyForm.ReadOnly = true;
            // 
            // ColumnMathScore
            // 
            ColumnMathScore.HeaderText = "Баллы по математике";
            ColumnMathScore.MinimumWidth = 6;
            ColumnMathScore.Name = "ColumnMathScore";
            ColumnMathScore.ReadOnly = true;
            // 
            // ColumnRussianScore
            // 
            ColumnRussianScore.HeaderText = "Баллы по русскому яз.";
            ColumnRussianScore.MinimumWidth = 6;
            ColumnRussianScore.Name = "ColumnRussianScore";
            ColumnRussianScore.ReadOnly = true;
            // 
            // ColumnInformaticSore
            // 
            ColumnInformaticSore.HeaderText = "Баллы по информатике";
            ColumnInformaticSore.MinimumWidth = 6;
            ColumnInformaticSore.Name = "ColumnInformaticSore";
            ColumnInformaticSore.ReadOnly = true;
            // 
            // ColumnSumScore
            // 
            ColumnSumScore.HeaderText = "Общая сумма баллов";
            ColumnSumScore.MinimumWidth = 6;
            ColumnSumScore.Name = "ColumnSumScore";
            ColumnSumScore.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 567);
            Controls.Add(dataGridView);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Главная";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem AddToolStripMenuItem;
        private ToolStripMenuItem EditToolStripMenuItem;
        private ToolStripMenuItem DeleteToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabelCountApplicants;
        private ToolStripStatusLabel toolStripStatusLabelApplicants150;
        private ToolStripStatusLabel toolStripStatusLabelScoreForSuccess;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ColumnFullName;
        private DataGridViewComboBoxColumn ColumnGender;
        private DataGridViewTextBoxColumn ColumnDateBirth;
        private DataGridViewComboBoxColumn ColumnStudyForm;
        private DataGridViewTextBoxColumn ColumnMathScore;
        private DataGridViewTextBoxColumn ColumnRussianScore;
        private DataGridViewTextBoxColumn ColumnInformaticSore;
        private DataGridViewTextBoxColumn ColumnSumScore;
    }
}
