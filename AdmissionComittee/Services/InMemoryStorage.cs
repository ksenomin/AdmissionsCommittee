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

        public InMemoryStorage()
        {
            applicants = new List<Applicant>();
            applicants.Clear();
            applicants.Add(new Applicant { FullName = "Иванов Иван Иванович", Gender = Gender.Male, BirthDay = new DateTime(2006, 5, 14), StudyForm = StudyForm.FullTime, MathScore = 70, RussianScore = 68, InformaticScore = 85 });
            applicants.Add(new Applicant { FullName = "Петрова Анна Сергеевна", Gender = Gender.Female, BirthDay = new DateTime(2007, 2, 10), StudyForm = StudyForm.Mixed, MathScore = 82, RussianScore = 75, InformaticScore = 79 });
            applicants.Add(new Applicant { FullName = "Сидоров Николай Павлович", Gender = Gender.Male, BirthDay = new DateTime(2006, 9, 23), StudyForm = StudyForm.PartTime, MathScore = 60, RussianScore = 63, InformaticScore = 70 });
            applicants.Add(new Applicant { FullName = "Кузнецова Елизавета Дмитриевна", Gender = Gender.Female, BirthDay = new DateTime(2007, 1, 30), StudyForm = StudyForm.FullTime, MathScore = 90, RussianScore = 89, InformaticScore = 95 });
            applicants.Add(new Applicant { FullName = "Белов Артём Викторович", Gender = Gender.Male, BirthDay = new DateTime(2006, 11, 8), StudyForm = StudyForm.Mixed, MathScore = 45, RussianScore = 55, InformaticScore = 40 });
        }

        public Task<ICollection<Applicant>> GetAll(CancellationToken token)
        {
            return Task.FromResult<ICollection<Applicant>>(applicants);
        }

        public Task<Applicant?> GetById(Guid id, CancellationToken token)
        {
            return Task.FromResult(applicants.FirstOrDefault(x => x.Id == id));
        }

        public Task Add(Applicant applicant, CancellationToken token)
        {
            applicants.Add(applicant);
            return Task.CompletedTask;
        }

        public Task Update(Applicant applicant, CancellationToken token)
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

        public Task Delete(Guid id, CancellationToken token)
        {
            var applicant = applicants.FirstOrDefault(x => x.Id == id);
            if (applicant != null)
            {
                applicants.Remove(applicant);
            }
            return Task.CompletedTask;
        }

        public Task<ApplicantStatistics> GetStatistics(CancellationToken token)
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
