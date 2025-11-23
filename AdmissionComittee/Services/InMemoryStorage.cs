using AdmissionComittee.Entities;
using Services.Contracts;

namespace Services
{
    /// <summary>
    /// Сервис для доступа к турам в памяти
    /// </summary>
    public class InMemoryStorage : IApplicantStorage
    {
        private List<Applicant> applicants;

        public InMemoryStorage(IEnumerable<Applicant>? initialData = null)
        {
            applicants = initialData?.ToList() ?? new List<Applicant>();
        }

        Task<ICollection<Applicant>> IApplicantStorage.GetAll(CancellationToken token)
        {
            return Task.FromResult<ICollection<Applicant>>(applicants);
        }

        Task<Applicant?> IApplicantStorage.GetById(Guid id, CancellationToken token)
        {
            return Task.FromResult(applicants.FirstOrDefault(x => x.Id == id));
        }

        Task IApplicantStorage.Add(Applicant applicant, CancellationToken token)
        {
            applicants.Add(applicant);
            return Task.CompletedTask;
        }

        Task IApplicantStorage.Update(Applicant applicant, CancellationToken token)
        {
            var existApplicant = applicants.FirstOrDefault(x => x.Id == applicant.Id);
            if (existApplicant != null)
            {
                existApplicant.Id = applicant.Id;
                existApplicant.StudyForm = applicant.StudyForm;
                existApplicant.RussianScore = applicant.RussianScore;
                existApplicant.FullName = applicant.FullName;
                existApplicant.BirthDay = applicant.BirthDay;
                existApplicant.InformaticScore = applicant.InformaticScore;
                existApplicant.Gender = applicant.Gender;
                existApplicant.MathScore = applicant.MathScore;
            }
            return Task.CompletedTask;
        }

        Task IApplicantStorage.Delete(Guid id, CancellationToken token)
        {
            var applicant = applicants.FirstOrDefault(x => x.Id == id);
            if (applicant != null)
            {
                applicants.Remove(applicant);
            }
            return Task.CompletedTask;
        }

        Task<ApplicantStatistics> IApplicantStorage.GetStatistics(CancellationToken token)
        {
            var statistics = new ApplicantStatistics
            {
                ApplicantsCount = applicants.Count,
                ApplicantsCountPassed = applicants.Where(x => x.MathScore + x.RussianScore + x.InformaticScore > 150).Count()
            };
            return Task.FromResult(statistics);
        }
    }
}
