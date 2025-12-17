using AdmissionComittee.Context;
using AdmissionComittee.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Services.Contracts;

namespace Repository
{
    /// <summary>
    /// Репозиторий для доступа к абитуриентам
    /// </summary>
    public class ApplicantRepository(ApplicantContext context) : IApplicantStorage
    {
        public async Task Add(Applicant applicant, CancellationToken token)
        {
            context.Add(applicant);
            await context.SaveChangesAsync(token);
        }
        public async Task Delete(Applicant applicant, CancellationToken token)
        {
            context.Remove(applicant);
            await context.SaveChangesAsync(token);
        }
        public async Task<ICollection<Applicant>> GetAll(CancellationToken token)
        {
            return await context.Set<Applicant>().AsNoTracking().ToListAsync(token);
        }
        public async Task<Applicant?> GetById(Guid id, CancellationToken token)
        {
            return await context.Set<Applicant>().FirstOrDefaultAsync(x => x.Id == id, token);
        }
        public async Task<ApplicantStatistics> GetStatistics(CancellationToken token)
        {
            var applicantSet = context.Set<Applicant>();

            var applicantsCount = await applicantSet.CountAsync(token);
            var applicantsCountPassed = await applicantSet
                .CountAsync(x => x.MathScore + x.RussianScore + x.InformaticScore > 150, token);

            var statistics = new ApplicantStatistics
            {
                ApplicantsCount = applicantsCount,
                ApplicantsCountPassed = applicantsCountPassed
            };

            return statistics;
        }
        public async Task Update(Applicant applicant, CancellationToken token)
        {
            context.Update(applicant);
            await context.SaveChangesAsync(token);
        }
    }
}
