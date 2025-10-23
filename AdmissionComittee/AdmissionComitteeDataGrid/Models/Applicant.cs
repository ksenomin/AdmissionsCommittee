
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
        /// Фио
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Гендер
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Форма обучения
        /// </summary>
        public StudyForm StudyForm { get; set; }

        /// <summary>
        /// Баллы по математике
        /// </summary>
        public int MathScore { get; set; }

        /// <summary>
        /// Баллы по русскому
        /// </summary>
        public int RussianScore { get; set; }

        /// <summary>
        /// Балы по информатике
        /// </summary>
        public int InformaticScore { get; set; }

        /// <summary>
        /// Общее количество баллов за экзамены
        /// </summary>
        public int TotalScore => MathScore + RussianScore + InformaticScore;

        /// <summary>
        /// Конструктор абитуриента
        /// </summary>/
        public Applicant(
        string fullName,
        Gender gender,
        DateTime birthDate,
        StudyForm form,
        int mathScore,
        int russianScore,
        int informaticsScore)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Gender = gender;
            BirthDay = birthDate;
            StudyForm = form;
            MathScore = mathScore;
            RussianScore = russianScore;
            InformaticScore = informaticsScore;
        }
    }
}
