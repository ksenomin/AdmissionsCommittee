
using System.ComponentModel;

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
        [Browsable(false)]
        public Gender Gender { get; set; }

        /// <summary>
        /// Отображаемый пол в гриде
        /// </summary>

        [DisplayName("Пол")]
        public string GenderDisplay => Gender == Gender.Male ? "Мужской" : "Женский";

        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Форма обучения
        /// </summary>
        [Browsable(false)]
        public StudyForm StudyForm { get; set; }

        [DisplayName("Форма обучения")]
        public string StudyFormDisplay
        {
            get
            {
                return StudyForm switch
                {
                    StudyForm.FullTime => "Очная",
                    StudyForm.Mixed => "Очно-заочная",
                    StudyForm.PartTime => "Заочная",
                    _ => "Не указано"
                };
            }
        }

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
    }
}
