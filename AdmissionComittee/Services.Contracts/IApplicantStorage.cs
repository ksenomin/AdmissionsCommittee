using AdmissionComittee.Entities;

namespace Services.Contracts
{
    /// <summary>
    /// Интерфейс хранилища
    /// </summary>
    public interface IApplicantStorage
    {
        /// <summary>
        /// Добавление абитуриента
        /// </summary>
        Task Add(Applicant applicant, CancellationToken token);

        /// <summary>
        /// Удаление абитуриента
        /// </summary>
        Task Delete(Guid id, CancellationToken token);

        /// <summary>
        /// Получение всех абитуриентов
        /// </summary>
        Task<ICollection<Applicant>> GetAll(CancellationToken token);

        /// <summary>
        /// Получить абитуриента по id
        /// </summary>
        Task<Applicant?> GetById(Guid id, CancellationToken token);

        /// <summary>
        /// Обновление записи абитуриента
        /// </summary>
        Task Update(Applicant applicant, CancellationToken token);

        /// <summary>
        /// Получение статистики туров
        /// </summary>
        Task<ApplicantStatistics> GetStatistics(CancellationToken token);
    }
}
