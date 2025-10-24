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

            dataGridView.Columns[nameof(Applicant.Id)].Visible = false;

            dataGridView.Columns[nameof(Applicant.FullName)].HeaderText = "ФИО";
            dataGridView.Columns[nameof(Applicant.Gender)].HeaderText = "Пол";
            dataGridView.Columns[nameof(Applicant.BirthDay)].HeaderText = "Дата рождения";
            dataGridView.Columns[nameof(Applicant.StudyForm)].HeaderText = "Форма обучения";
            dataGridView.Columns[nameof(Applicant.MathScore)].HeaderText = "ЕГЭ (Математика)";
            dataGridView.Columns[nameof(Applicant.RussianScore)].HeaderText = "ЕГЭ (Русский)";
            dataGridView.Columns[nameof(Applicant.InformaticScore)].HeaderText = "ЕГЭ (Информатика)";
            dataGridView.Columns[nameof(Applicant.TotalScore)].HeaderText = "Сумма баллов";
        }

        private void LoadApplicants()
        {
            applicantsList.Add(new Applicant("Иванов Иван Иванович", Gender.Male, new DateTime(2006, 5, 14), StudyForm.FullTime, 70, 68, 85));
            applicantsList.Add(new Applicant("Петрова Анна Сергеевна", Gender.Female, new DateTime(2007, 2, 10), StudyForm.Mixed, 82, 75, 79));
            applicantsList.Add(new Applicant("Сидоров Николай Павлович", Gender.Male, new DateTime(2006, 9, 23), StudyForm.PartTime, 60, 63, 70));
            applicantsList.Add(new Applicant("Кузнецова Елизавета Дмитриевна", Gender.Female, new DateTime(2007, 1, 30), StudyForm.FullTime, 90, 89, 95));
            applicantsList.Add(new Applicant("Белов Артём Викторович", Gender.Male, new DateTime(2006, 11, 8), StudyForm.Mixed, 45, 55, 60));
        }

        private void SetStatistics()
        {
            toolStripStatusLabelCountApplicants.Text = $"Общее число абитуриентов: {applicantsList.Count()}";
            toolStripStatusLabelApplicants150.Text = $"Количество абитуриентов баллы которых больше 150: {applicantsList.Where(x => x.TotalScore > 150)}";
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
    }
}
