using AdmissionComittee.Entities;
using Services.Contracts;

namespace AdmissionComitte.Web.Models
{
    /// <summary>
    /// Модель главной страницы
    /// </summary>
    public class MainModel
    {
        /// <summary>
        /// Список абитуриентов
        /// </summary>
        public required IEnumerable<Applicant> Applicants { get; set; }

        /// <summary>
        /// Статистика абитуриетов
        /// </summary>
        public ApplicantStatistics Statistics { get; set; }
    }
}
