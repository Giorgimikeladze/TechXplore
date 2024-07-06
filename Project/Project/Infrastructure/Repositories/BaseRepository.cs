using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<T> where T : Entity
    {
        protected DbContext _context;
        protected DbSet<T> _set;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        protected async Task<T> GetEntity(int id, CancellationToken token = default)
        {
            return await _set.FirstOrDefaultAsync(x => x.Id == id, token)
                .ConfigureAwait(false);
        }
        protected async Task<List<T>> GetAll(CancellationToken token = default)
        {
            return await _set.ToListAsync(token).ConfigureAwait(false);
        }
        protected async Task<bool> Create(T entity, CancellationToken token = default)
        {
            if (await Exists(entity.Id))
            {
                return false;
            }
            await _set.AddAsync(entity, token);
            await _context.SaveChangesAsync(token).ConfigureAwait(false);
            return true;
        }
        protected async Task<bool> Update(T entity, CancellationToken token = default)
        {
            if (!await Exists(entity.Id))
            {
                return false;
            }
            _set.Update(entity);
            await _context.SaveChangesAsync(token).ConfigureAwait(false);
            return true;

        }
        protected async Task<bool> Delete(int id, CancellationToken token = default)
        {
            if (!await Exists(id))
            {
                return false;
            }
            var temp = await _set.FirstOrDefaultAsync(x => x.Id == id, token).ConfigureAwait(false);
            _set.Remove(temp);
            await _context.SaveChangesAsync(token).ConfigureAwait(false);
            return true;
        }
        protected async Task<bool> Exists(int id, CancellationToken token = default)
        {
            var temp = await _set.FirstOrDefaultAsync(x => x.Id == id, token).ConfigureAwait(false);
            if (temp == null)
            {
                return false;
            }
            return true;
        }
        protected async Task UpdateRange(List<T> values, CancellationToken token = default)
        {
            _set.UpdateRange(values);
            await _context.SaveChangesAsync(token).ConfigureAwait(false);
        }
        public async Task<T> FindByCondition(Expression<Func<T, bool>> expression, CancellationToken token = default)
        {
            return await _set.FirstOrDefaultAsync(expression, token).ConfigureAwait(false);
        }
        public async Task<List<T>> FindAllByCondition(Expression<Func<T, bool>> expression, CancellationToken token = default)
        {
            return await _set.Where(expression).ToListAsync(token).ConfigureAwait(false);
        }
    }

}
