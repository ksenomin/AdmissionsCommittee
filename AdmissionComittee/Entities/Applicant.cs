using System.ComponentModel.DataAnnotations;
using AdmissionComittee.Entities.Contracts;
using AdmissionComittee.Entities.Validators;

namespace AdmissionComittee.Entities
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
        public Gender Gender { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        [Required(ErrorMessage = "Укажите дату рождения.")]
        [AgeRange(AppConstants.MinAge, AppConstants.MaxAge, ErrorMessage = "Возраст должен быть от 18 до 30!")]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Форма обучения
        /// </summary>
        [DeniedValues(StudyForm.Uknown, ErrorMessage = "Выберите форму обучения!")]
        [EnumDataType(typeof(StudyForm))]
        public StudyForm StudyForm { get; set; }

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
    }
}
