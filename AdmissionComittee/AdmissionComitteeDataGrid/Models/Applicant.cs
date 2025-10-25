using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdmissionComitteeDataGrid.Models
{
    /// <summary>
    /// Класс абитуриента
    /// </summary>
    public class Applicant
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        [Required(ErrorMessage = "Введите ФИО абитуриента!")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Гендер
        /// </summary>
        [DeniedValues(Gender.Uknown, ErrorMessage = "Выберите пол абитуриента!")]
        [EnumDataType(typeof(Gender))]
        [Browsable(false)]
        public Gender Gender { get; set; }

        /// <summary>
        /// Отображаемый пол
        /// </summary>
        [DisplayName("Пол")]
        public string GenderDisplay => Gender == Gender.Male ? "Мужской" : "Женский";

        /// <summary>
        /// День рождения
        /// </summary>
        [Required]
        [CustomValidation(typeof(Applicant), nameof(ValidateAge))]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Форма обучения
        /// </summary>
        [DeniedValues(StudyForm.Uknown, ErrorMessage = "Выберите форму обучения!")]
        [EnumDataType(typeof(StudyForm))]
        [Browsable(false)]
        public StudyForm StudyForm { get; set; }

        /// <summary>
        /// Отображаемая форма обучения
        /// </summary>
        [DisplayName("Форма обучения")]
        public string StudyFormDisplay => StudyForm switch
        {
            StudyForm.FullTime => "Очная",
            StudyForm.Mixed => "Очно-заочная",
            StudyForm.PartTime => "Заочная",
            _ => "Не указано"
        };

        /// <summary>
        /// Баллы по математике
        /// </summary>
        [Range(AppConstants.MinExamScore, AppConstants.MaxExamScore, ErrorMessage = "Баллы по математике должны быть больше 25 и меньше 100!")]
        public int MathScore { get; set; }

        /// <summary>
        /// Баллы по русскому
        /// </summary>
        [Range(AppConstants.MinExamScore, AppConstants.MaxExamScore, ErrorMessage = "Баллы по русскому должны быть больше 25 и меньше 100!")]
        public int RussianScore { get; set; }

        /// <summary>
        /// Баллы по информатике
        /// </summary>
        [Range(AppConstants.MinExamScore, AppConstants.MaxExamScore, ErrorMessage = "Баллы по информатике должны быть больше 25 и меньше 100!")]
        public int InformaticScore { get; set; }

        /// <summary>
        /// Общее количество баллов
        /// </summary>
        public int TotalScore => MathScore + RussianScore + InformaticScore;

        /// <summary>
        /// Копия абитуриента
        /// </summary>
        public Applicant Clone() => (Applicant)MemberwiseClone();

        /// <summary>
        /// Проверка возраста
        /// </summary>
        public static ValidationResult? ValidateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age))
            {
                age--;
            }

            return (age < 18 || age > 30)
                ? new ValidationResult("Возраст должен быть от 18 до 30 лет!")
                : ValidationResult.Success;
        }
    }
}
