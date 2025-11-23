using AdmissionComittee.Entities;
using Services.Contracts;

namespace AdmissionComitteeDataGrid.Forms
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        private IApplicantStorage applicantStorage;
        private readonly BindingSource bindingSource = new();

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm(IApplicantStorage applicantStorage)
        {
            InitializeComponent();
            this.applicantStorage = applicantStorage;
            SetUpDataGridView();
            LoadTestData();
        }

        private async void LoadTestData()
        {
            var applicants = new List<Applicant>
            {
            new() { FullName = "Иванов Иван Иванович", Gender = Gender.Male, BirthDay = new DateTime(2006, 5, 14), StudyForm = StudyForm.FullTime, MathScore = 70, RussianScore = 68, InformaticScore = 85 },
            new() { FullName = "Петрова Анна Сергеевна", Gender = Gender.Female, BirthDay = new DateTime(2007, 2, 10), StudyForm = StudyForm.Mixed, MathScore = 82, RussianScore = 75, InformaticScore = 79 },
            new() { FullName = "Сидоров Николай Павлович", Gender = Gender.Male, BirthDay = new DateTime(2006, 9, 23), StudyForm = StudyForm.PartTime, MathScore = 60, RussianScore = 63, InformaticScore = 70 },
            new() { FullName = "Кузнецова Елизавета Дмитриевна", Gender = Gender.Female, BirthDay = new DateTime(2007, 1, 30), StudyForm = StudyForm.FullTime, MathScore = 90, RussianScore = 89, InformaticScore = 95 },
            new() { FullName = "Белов Артём Викторович", Gender = Gender.Male, BirthDay = new DateTime(2006, 11, 8), StudyForm = StudyForm.Mixed, MathScore = 45, RussianScore = 55, InformaticScore = 40 },
            };

            foreach (var aplicant in applicants)
            {
                await applicantStorage.Add(aplicant, CancellationToken.None);
            }
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
            ColumnStudyForm.DataPropertyName = nameof(Applicant.StudyForm);
            ColumnGender.DataPropertyName = nameof(Applicant.Gender);
        }

        /// <summary>
        /// Обновление статистики
        /// </summary>
        private async Task SetStatistics()
        {
            var stats = await applicantStorage.GetStatistics(CancellationToken.None);
            toolStripStatusLabelApplicants150.Text = $"Количество абитуриентов баллы которых больше 150: {stats.ApplicantsCountPassed}";
            toolStripStatusLabelCountApplicants.Text = $"Общее число абитуриентов: {stats.ApplicantsCount}";
            toolStripStatusLabelScoreForSuccess.Text = $"Количество проходящих абитуриентов: {stats.ApplicantsCountPassed}";
        }

        private async void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addForm = new AddOrEditForm();

            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                await applicantStorage.Add(addForm.CurrentApplicant, CancellationToken.None);
                await OnUpdate();
            }
        }

        private async void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите абитуриента для редактирования.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Выбранный абитуриент
            var selectedApplicant = (Applicant)dataGridView.SelectedRows[0].DataBoundItem;
            var editForm = new AddOrEditForm(selectedApplicant);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await applicantStorage.Update(editForm.CurrentApplicant, CancellationToken.None);
                await OnUpdate();
            }
        }

        private async void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите абитуриента для удаления.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedApplicant = (Applicant)dataGridView.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Удалить '{selectedApplicant.FullName}'?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await applicantStorage.Delete(selectedApplicant.Id, CancellationToken.None);
                await OnUpdate();
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "ColumnSumScore")
            {
                if (dataGridView.Rows[e.RowIndex].DataBoundItem is Applicant applicant)
                {
                    e.Value = applicant.MathScore + applicant.RussianScore + applicant.InformaticScore;
                }
            }
        }

        private async Task LoadData()
        {
            var applicant = await applicantStorage.GetAll(CancellationToken.None);
            bindingSource.DataSource = applicant.ToList();
            dataGridView.DataSource = bindingSource;
            await SetStatistics();
        }

        private async Task OnUpdate()
        {
            var applicant = await applicantStorage.GetAll(CancellationToken.None);
            bindingSource.DataSource = applicant.ToList();
            bindingSource.ResetBindings(false);
            await SetStatistics();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}
