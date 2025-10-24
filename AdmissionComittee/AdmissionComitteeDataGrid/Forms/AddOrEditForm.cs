using AdmissionComitteeDataGrid.Models;

namespace AdmissionComitteeDataGrid.Forms
{
    public partial class AddOrEditForm : Form
    {
        /// <summary>
        /// Текущий абитуриент
        /// </summary>
        private Applicant targetApplicant;

        /// <summary>
        /// Свойство для доступа к текущему абитуриенту
        /// </summary>
        public Applicant CurrentApplicant => targetApplicant;

        private readonly ErrorProvider errorProvider = new();

        /// <summary>
        /// Форма добавления или редактирования абитуриента
        /// </summary>
        public AddOrEditForm(Applicant? sourceApplicant = null)
        {
            InitializeComponent();

            if (sourceApplicant == null)
            {
                // Создание нового абитуриента (по умолчанию)
                targetApplicant = new Applicant(
                    fullName: string.Empty,
                    gender: Gender.Male,
                    birthDate: DateTime.Now,
                    form: StudyForm.FullTime,
                    mathScore: 0,
                    russianScore: 0,
                    informaticsScore: 0
                );

                Text = "Добавление абитуриента";
                buttonAddOrEdit.Text = "Добавить";
            }
            else
            {
                // Копирование существующего абитуриента для редактирования
                targetApplicant = new Applicant(
                    fullName: sourceApplicant.FullName,
                    gender: sourceApplicant.Gender,
                    birthDate: sourceApplicant.BirthDay,
                    form: sourceApplicant.StudyForm,
                    mathScore: sourceApplicant.MathScore,
                    russianScore: sourceApplicant.RussianScore,
                    informaticsScore: sourceApplicant.InformaticScore
                );

                Text = "Редактирование абитуриента";
                buttonAddOrEdit.Text = "Сохранить";
            }

            BindControls();
            SetUpFields();
        }

        /// <summary>
        /// Настройка комбобоксов и ограничений
        /// </summary>
        private void SetUpFields()
        {
            numericUpDownMath.Maximum = 100;
            numericUpDownRussian.Maximum = 100;
            numericUpDownInformatic.Maximum = 100;

            numericUpDownMath.Minimum = 0;
            numericUpDownRussian.Minimum = 0;
            numericUpDownInformatic.Minimum = 0;

            // Настраиваем комбобоксы
            comboBoxGender.DataSource = Enum.GetValues(typeof(Gender));
            comboBoxStudyForm.DataSource = Enum.GetValues(typeof(StudyForm));
        }

        /// <summary>
        /// Привязка данных из модели к контролам
        /// </summary>
        private void BindControls()
        {
            textBoxFullName.DataBindings.Add("Text", targetApplicant, nameof(Applicant.FullName));
            comboBoxGender.DataBindings.Add("SelectedItem", targetApplicant, nameof(Applicant.Gender));
            dateTimePickerBirthDate.DataBindings.Add("Value", targetApplicant, nameof(Applicant.BirthDay));
            comboBoxStudyForm.DataBindings.Add("SelectedItem", targetApplicant, nameof(Applicant.StudyForm));
            numericUpDownMath.DataBindings.Add("Value", targetApplicant, nameof(Applicant.MathScore));
            numericUpDownRussian.DataBindings.Add("Value", targetApplicant, nameof(Applicant.RussianScore));
            numericUpDownInformatic.DataBindings.Add("Value", targetApplicant, nameof(Applicant.InformaticScore));
        }

        /// <summary>
        /// Проверка корректности введённых данных
        /// </summary>
        private bool ValidateForm()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(targetApplicant.FullName))
            {
                errorProvider.SetError(textBoxFullName, "Введите ФИО абитуриента!");
                isValid = false;
            }

            if (targetApplicant.Gender == Gender.Uknown)
            {
                errorProvider.SetError(comboBoxGender, "Выберите пол!");
                isValid = false;
            }

            var age = DateTime.Now.Year - targetApplicant.BirthDay.Year;
            if (targetApplicant.BirthDay > DateTime.Now.AddYears(-age))
            {
                age--;
            }

            if (age < 16 || age > 25)
            {
                errorProvider.SetError(dateTimePickerBirthDate, "Возраст должен быть от 16 до 100 лет!");
                isValid = false;
            }

            if (targetApplicant.MathScore < 0 || targetApplicant.MathScore > 100)
            {
                errorProvider.SetError(numericUpDownMath, "Баллы по математике должны быть от 0 до 100!");
                isValid = false;
            }

            if (targetApplicant.RussianScore < 0 || targetApplicant.RussianScore > 100)
            {
                errorProvider.SetError(numericUpDownRussian, "Баллы по русскому должны быть от 0 до 100!");
                isValid = false;
            }

            if (targetApplicant.InformaticScore < 0 || targetApplicant.InformaticScore > 100)
            {
                errorProvider.SetError(numericUpDownInformatic, "Баллы по информатике должны быть от 0 до 100!");
                isValid = false;
            }

            return isValid;
        }


        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите отменить?", "Отмена", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
