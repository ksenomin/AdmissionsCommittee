using System.ComponentModel;
using AdmissionComitteeDataGrid.Forms;
using AdmissionComitteeDataGrid.Models;

namespace AdmissionComitteeDataGrid
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список абитуриентов
        /// </summary>
        public BindingList<Applicant> ApplicantsList = new();

        private readonly BindingSource applicantsBinding = new();

        /// <summary>
        /// Главная форма приложения
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            LoadApplicants();
            SetUpDataGridView();

            SetStatistics();
        }

        /// <summary>
        /// Настройка грида
        /// </summary>
        private void SetUpDataGridView()
        {
            dataGridView.AutoGenerateColumns = false;

            ColumnFullName.DataPropertyName = nameof(Applicant.FullName);
            ColumnDateBirth.DataPropertyName = nameof(Applicant.BirthDay);
            ColumnMathScore.DataPropertyName = nameof(Applicant.MathScore);
            ColumnRussianScore.DataPropertyName = nameof(Applicant.RussianScore);
            ColumnInformaticSore.DataPropertyName = nameof(Applicant.InformaticScore);
            ColumnSumScore.DataPropertyName = nameof(Applicant.TotalScore);
            ColumnStudyForm.DataPropertyName = nameof(Applicant.StudyFormDisplay);
            ColumnGender.DataPropertyName = nameof(Applicant.GenderDisplay);

            applicantsBinding.DataSource = ApplicantsList;
            dataGridView.DataSource = applicantsBinding;
        }

        /// <summary>
        /// Создание записей
        /// </summary>
        private void LoadApplicants()
        {
            ApplicantsList.Add(new Applicant { FullName = "Иванов Иван Иванович", Gender = Gender.Male, BirthDay = new DateTime(2006, 5, 14), StudyForm = StudyForm.FullTime, MathScore = 70, RussianScore = 68, InformaticScore = 85 });
            ApplicantsList.Add(new Applicant { FullName = "Петрова Анна Сергеевна", Gender = Gender.Female, BirthDay = new DateTime(2007, 2, 10), StudyForm = StudyForm.Mixed, MathScore = 82, RussianScore = 75, InformaticScore = 79 });
            ApplicantsList.Add(new Applicant { FullName = "Сидоров Николай Павлович", Gender = Gender.Male, BirthDay = new DateTime(2006, 9, 23), StudyForm = StudyForm.PartTime, MathScore = 60, RussianScore = 63, InformaticScore = 70 });
            ApplicantsList.Add(new Applicant { FullName = "Кузнецова Елизавета Дмитриевна", Gender = Gender.Female, BirthDay = new DateTime(2007, 1, 30), StudyForm = StudyForm.FullTime, MathScore = 90, RussianScore = 89, InformaticScore = 95 });
            ApplicantsList.Add(new Applicant { FullName = "Белов Артём Викторович", Gender = Gender.Male, BirthDay = new DateTime(2006, 11, 8), StudyForm = StudyForm.Mixed, MathScore = 45, RussianScore = 55, InformaticScore = 40 });
        }

        /// <summary>
        /// Обновление статистики
        /// </summary>
        private void SetStatistics()
        {
            toolStripStatusLabelCountApplicants.Text = $"Общее число абитуриентов: {ApplicantsList.Count()}";
            toolStripStatusLabelApplicants150.Text = $"Количество абитуриентов баллы которых больше 150: {ApplicantsList.Where(x => x.TotalScore > 150).Count()}";
            toolStripStatusLabelScoreForSuccess.Text = $"Количество проходящих абитуриентов: {ApplicantsList.Where(x => x.TotalScore > 150).Count()}";
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AddOrEditForm = new AddOrEditForm();

            if (AddOrEditForm.ShowDialog(this) == DialogResult.OK)
            {
                ApplicantsList.Add(AddOrEditForm.CurrentApplicant);

                SetStatistics();
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите абитуриента для редактирования.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Выбранный абитуриент
            var selectedApplicant = (Applicant)dataGridView.SelectedRows[0].DataBoundItem;

            var editForm = new AddOrEditForm(selectedApplicant);

            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                var index = ApplicantsList.IndexOf(selectedApplicant);
                if (index >= 0)
                {
                    ApplicantsList[index] = editForm.CurrentApplicant;
                }

                SetStatistics();
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите абитуриента для удаления.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedApplicant = (Applicant)dataGridView.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show(
                $"Удалить абитуриента \"{selectedApplicant.FullName}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                ApplicantsList.Remove(selectedApplicant);
                SetStatistics();
            }
        }
    }
}
