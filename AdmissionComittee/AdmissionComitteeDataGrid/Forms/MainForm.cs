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
        public BindingList<Applicant> applicantsList = new();

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

        private void SetUpDataGridView()
        {
            applicantsBinding.DataSource = applicantsList;
            dataGridView.DataSource = applicantsBinding;

            // Скрытие колонок
            var hiddenColumns = new[] { nameof(Applicant.Id), nameof(Applicant.Gender), nameof(Applicant.StudyForm) };
            foreach (var colName in hiddenColumns)
            {
                if (dataGridView.Columns[colName] != null)
                {
                    dataGridView.Columns[colName].Visible = false;

                }
            }

            // Заголовки для отображаемых колонок
            var headers = new Dictionary<string, string>
            {
                { nameof(Applicant.FullName), "ФИО" },
                { nameof(Applicant.BirthDay), "Дата рождения" },
                { nameof(Applicant.GenderDisplay), "Пол" },
                { nameof(Applicant.StudyFormDisplay), "Форма обучения" },
                { nameof(Applicant.MathScore), "ЕГЭ (Математика)" },
                { nameof(Applicant.RussianScore), "ЕГЭ (Русский)" },
                { nameof(Applicant.InformaticScore), "ЕГЭ (Информатика)" },
                { nameof(Applicant.TotalScore), "Сумма баллов" }
            };

            foreach (var kvp in headers)
            {
                if (dataGridView.Columns[kvp.Key] != null)
                {
                    dataGridView.Columns[kvp.Key].HeaderText = kvp.Value;
                }
            }
        }

        private void LoadApplicants()
        {
            applicantsList.Add(new Applicant("Иванов Иван Иванович", Gender.Male, new DateTime(2006, 5, 14), StudyForm.FullTime, 70, 68, 85));
            applicantsList.Add(new Applicant("Петрова Анна Сергеевна", Gender.Female, new DateTime(2007, 2, 10), StudyForm.Mixed, 82, 75, 79));
            applicantsList.Add(new Applicant("Сидоров Николай Павлович", Gender.Male, new DateTime(2006, 9, 23), StudyForm.PartTime, 60, 63, 70));
            applicantsList.Add(new Applicant("Кузнецова Елизавета Дмитриевна", Gender.Female, new DateTime(2007, 1, 30), StudyForm.FullTime, 90, 89, 95));
            applicantsList.Add(new Applicant("Белов Артём Викторович", Gender.Male, new DateTime(2006, 11, 8), StudyForm.Mixed, 45, 55, 40));
        }

        private void SetStatistics()
        {
            toolStripStatusLabelCountApplicants.Text = $"Общее число абитуриентов: {applicantsList.Count()}";
            toolStripStatusLabelApplicants150.Text = $"Количество абитуриентов баллы которых больше 150: {applicantsList.Where(x => x.TotalScore > 150).Count()}";
            toolStripStatusLabelScoreForSuccess.Text = $"Количество проходящих абитуриентов: {applicantsList.Where(x => x.TotalScore > 150).Count()}";
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AddOrEditForm = new AddOrEditForm();

            if (AddOrEditForm.ShowDialog(this) == DialogResult.OK)
            {
                applicantsList.Add(AddOrEditForm.CurrentApplicant);

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
                var index = applicantsList.IndexOf(selectedApplicant);
                if (index >= 0)
                {
                    applicantsList[index] = editForm.CurrentApplicant;
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
                applicantsList.Remove(selectedApplicant);
                SetStatistics();
            }
        }
    }
}
