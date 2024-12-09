using HahnSoftwareTest.Infrastructure.Data;
using HahnSoftwareTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HahnSoftwareTest.Infrastructure.Repositories
{
    public class MyEntityRepository : IRepository<MyEntity>
    {
        private readonly ApplicationDbContext _context;

        public MyEntityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MyEntity> GetByIdAsync(int id)
        {
            return await _context.MyEntities.FindAsync(id);
        }

        public async Task<IEnumerable<MyEntity>> GetAllAsync()
        {
            return await _context.MyEntities.ToListAsync();
        }

        public async Task AddAsync(MyEntity entity)
        {
            await _context.MyEntities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MyEntity entity)
        {
            _context.MyEntities.Update(entity);
            await _context.SaveChangesAsync();
        }      

        public async Task DeleteAsync(MyEntity entity)
        {
            if (entity != null)
            {
                _context.MyEntities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
