using AdmissionComittee.Entities;
using Services.Contracts;

namespace Services
{
    public class ApplicantManager : IApplicantManager
    {
        public Task Add(Applicant applicant, CancellationToken token) => throw new NotImplementedException();
        public Task Delete(Guid id, CancellationToken token) => throw new NotImplementedException();
        public Task<ICollection<Applicant>> GetAll(CancellationToken token) => throw new NotImplementedException();
        public Task<Applicant?> GetById(Guid id, CancellationToken token) => throw new NotImplementedException();
        public Task<ApplicantStatistics> GetStatistics(CancellationToken token) => throw new NotImplementedException();
        public Task Update(Applicant applicant, CancellationToken token) => throw new NotImplementedException();
    }
}
