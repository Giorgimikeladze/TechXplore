using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Abstraction;
using Application.Services.Abstraction;
using Domain.Models.AssotiativeEntities;

namespace Application.Services.Implementation
{
    public class EnrollmentServices:IEnrollmentServices
    {
        private readonly IEnrollmentRepository _repo;

        public EnrollmentServices(IEnrollmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Enroll(Enrollment enrollment, CancellationToken token = default)
        {
            return await _repo.Enroll(enrollment, token).ConfigureAwait(false);
        }

        public async Task<bool> UpdateEnrollemtn(Enrollment enrollment, CancellationToken token = default)
        {
            return await _repo.UpdateEnrollemtn(enrollment, token).ConfigureAwait(false) ;
        }
    }
}
