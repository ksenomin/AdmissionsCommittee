using System.Diagnostics;
using AdmissionComittee.Entities;
using Microsoft.Extensions.Logging;
using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    /// <summary>
    /// Менеджер абитуриента
    /// </summary>
    public class ApplicantManager : IApplicantManager
    {
        private readonly IApplicantStorage storage;
        private readonly ILogger logger;

        /// <summary>
        /// Инициализация менеджера
        /// </summary>
        public ApplicantManager(IApplicantStorage storage, ILoggerFactory loggerFactory)
        {
            this.storage = storage;
            logger = loggerFactory.CreateLogger<ApplicantManager>();
        }

        /// <summary>
        /// Добавить запись
        /// </summary>
        public async Task Add(Applicant applicant, CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.Add(applicant, token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"Add выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }

        /// <summary>
        /// Удалить запись
        /// </summary>
        public async Task Delete(Guid id, CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var app = await GetById(id, token);
                await storage.Delete(app, token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"Delete выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }

        /// <summary>
        /// Получить все записи
        /// </summary>
        public async Task<ICollection<Applicant>> GetAll(CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                return await storage.GetAll(token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"GetAll выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }

        /// <summary>
        /// Получить по id
        /// </summary>
        public async Task<Applicant?> GetById(Guid id, CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                return await storage.GetById(id, token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"GetById выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }

        /// <summary>
        /// Получить статистику
        /// </summary>
        public async Task<ApplicantStatistics> GetStatistics(CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                return await storage.GetStatistics(token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"GetStatistics выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }

        /// <summary>
        /// Обновить
        /// </summary>
        public async Task Update(Applicant applicant, CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.Update(applicant, token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"Update выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }
    }
}
