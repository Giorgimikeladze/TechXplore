using Domain.Models.AssotiativeEntities;

namespace Application.Repositories.Abstraction
{
    public interface IEnrollmentRepository
    {
        public Task<bool> Enroll(Enrollment enrollment,CancellationToken token = default);
        public Task<bool> UpdateEnrollemtn(Enrollment enrollment, CancellationToken token = default);
    }
}
