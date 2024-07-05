using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.AssotiativeEntities;

namespace Application.Services.Abstraction
{
    public interface IEnrollmentServices
    {
        public Task<bool> Enroll(Enrollment enrollment, CancellationToken token = default);
        public Task<bool> UpdateEnrollemtn(Enrollment enrollment, CancellationToken token = default);
    }
}
