using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdmissionComitteeDataGrid.Models
{
    public class Applicant
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Введите ФИО абитуриента!")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Выберите пол!")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; } = Gender.Uknown;

        [DisplayName("Пол")]
        public string GenderDisplay => Gender == Gender.Male ? "Мужской" : "Женский";

        [Required(ErrorMessage = "Укажите дату рождения!")]
        [CustomValidation(typeof(Applicant), nameof(ValidateAge))]
        public DateTime BirthDay { get; set; } = DateTime.Now.AddYears(-18);

        [Required(ErrorMessage = "Выберите форму обучения!")]
        [EnumDataType(typeof(StudyForm))]
        public StudyForm StudyForm { get; set; }

        [Range(AppConstants.MinExamScore, AppConstants.MaxExamScore, ErrorMessage = "Баллы по математике должны быть от 0 до 100!")]
        public int MathScore { get; set; }

        [Range(AppConstants.MinExamScore, AppConstants.MaxExamScore, ErrorMessage = "Баллы по русскому должны быть от 0 до 100!")]
        public int RussianScore { get; set; }

        [Range(AppConstants.MinExamScore, AppConstants.MaxExamScore, ErrorMessage = "Баллы по информатике должны быть от 0 до 100!")]
        public int InformaticScore { get; set; }

        public int TotalScore => MathScore + RussianScore + InformaticScore;

        public Applicant Clone() => (Applicant)MemberwiseClone();

        // --- Валидация возраста ---
        public static ValidationResult? ValidateAge(DateTime birthDay, ValidationContext context)
        {
            var age = DateTime.Now.Year - birthDay.Year;
            if (birthDay > DateTime.Now.AddYears(-age))
            {
                age--;

            }

            if (age < AppConstants.MinAge || age > AppConstants.MaxAge)
            {
                return new ValidationResult($"Возраст должен быть от {AppConstants.MinAge} до {AppConstants.MaxAge} лет!");
            }

            return ValidationResult.Success;
        }
    }
}
