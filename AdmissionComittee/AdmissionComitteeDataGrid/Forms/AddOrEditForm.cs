using System.ComponentModel.DataAnnotations;
using AdmissionComitteeDataGrid.Infrastructure;
using AdmissionComitteeDataGrid.Models;

namespace AdmissionComitteeDataGrid.Forms
{
    /// <summary>
    /// Форма добавления/редактирования
    /// </summary>
    public partial class AddOrEditForm : Form
    {
        /// <summary>
        /// Текущий абитуриент
        /// </summary>
        private readonly Applicant targetApplicant;

        private readonly ErrorProvider errorProvider = new();

        /// <summary>
        /// Свойство для доступа к текущему абитуриенту
        /// </summary>
        public Applicant CurrentApplicant => targetApplicant;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public AddOrEditForm(Applicant? sourceApplicant = null)
        {
            InitializeComponent();

            targetApplicant = sourceApplicant?.Clone() ?? new Applicant();
            Text = sourceApplicant == null ? "Добавление абитуриента" : "Редактирование абитуриента";
            buttonAddOrEdit.Text = sourceApplicant == null ? "Добавить" : "Сохранить";

            SetUpFields();
            BindControls();
            errorProvider.BlinkRate = 0;
        }

        /// <summary>
        /// Настройка контролов
        /// </summary>
        private void SetUpFields()
        {
            numericUpDownMath.Minimum = AppConstants.MinExamScore;
            numericUpDownMath.Maximum = AppConstants.MaxExamScore;

            numericUpDownRussian.Minimum = AppConstants.MinExamScore;
            numericUpDownRussian.Maximum = AppConstants.MaxExamScore;

            numericUpDownInformatic.Minimum = AppConstants.MinExamScore;
            numericUpDownInformatic.Maximum = AppConstants.MaxExamScore;

            comboBoxGender.DataSource = Enum.GetValues(typeof(Gender));
            comboBoxStudyForm.DataSource = Enum.GetValues(typeof(StudyForm));
        }

        /// <summary>
        /// Привязка контролов
        /// </summary>
        private void BindControls()
        {
            textBoxFullName.AddBinding(x => x.Text, targetApplicant, x => x.FullName, errorProvider);
            comboBoxGender.AddBinding(x => x.SelectedItem!, targetApplicant, x => x.Gender, errorProvider);
            dateTimePickerBirthDate.AddBinding(x => x.Value, targetApplicant, x => x.BirthDay, errorProvider);
            comboBoxStudyForm.AddBinding(x => x.SelectedItem!, targetApplicant, x => x.StudyForm, errorProvider);
            numericUpDownMath.AddBinding(x => x.Value, targetApplicant, x => x.MathScore, errorProvider);
            numericUpDownRussian.AddBinding(x => x.Value, targetApplicant, x => x.RussianScore, errorProvider);
            numericUpDownInformatic.AddBinding(x => x.Value, targetApplicant, x => x.InformaticScore, errorProvider);
        }

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            var context = new ValidationContext(targetApplicant);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(targetApplicant, context, results, true);

            if (isValid)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            foreach (var validationResult in results)
            {
                foreach (var memberName in validationResult.MemberNames)
                {
                    Control? control = memberName switch
                    {
                        nameof(Applicant.FullName) => textBoxFullName,
                        nameof(Applicant.Gender) => comboBoxGender,
                        nameof(Applicant.BirthDay) => dateTimePickerBirthDate,
                        nameof(Applicant.StudyForm) => comboBoxStudyForm,
                        nameof(Applicant.MathScore) => numericUpDownMath,
                        nameof(Applicant.RussianScore) => numericUpDownRussian,
                        nameof(Applicant.InformaticScore) => numericUpDownInformatic,
                        _ => null
                    };

                    if (control != null)
                    {
                        errorProvider.SetError(control, validationResult.ErrorMessage);
                    }
                }
            }

            MessageBox.Show("Исправьте ошибки перед сохранением.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите отменить?", "Отмена",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void textBoxFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}
