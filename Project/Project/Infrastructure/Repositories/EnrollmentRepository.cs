using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Abstraction;
using Domain.Models.AssotiativeEntities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Infrastructure.Repositories
{
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> Enroll(Enrollment enrollment, CancellationToken token = default)
        {
            return await base.Create(enrollment,token).ConfigureAwait(false);
        }

        public async Task<bool> UpdateEnrollemtn(Enrollment enrollment, CancellationToken token = default)
        {
            return await base.Update(enrollment,token).ConfigureAwait(false);
        }
    }
}
