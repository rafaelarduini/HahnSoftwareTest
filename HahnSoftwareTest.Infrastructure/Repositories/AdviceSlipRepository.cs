using HahnSoftwareTest.Application.Interfaces;
using HahnSoftwareTest.Domain.Entities;
using HahnSoftwareTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HahnSoftwareTest.Infrastructure.Repositories;

public class AdviceSlipRepository : IAdviceSlipRepository
{
    private readonly ApplicationDbContext _context;

    public AdviceSlipRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AdviceSlip?> GetByIdAsync(int id)
    {
        return await _context.AdviceSlips.FindAsync(id);
    }

    public async Task<IEnumerable<AdviceSlip>> GetAllAsync()
    {
        return await _context.AdviceSlips.ToListAsync();
    }

    public async Task AddAsync(AdviceSlip entity)
    {
        await _context.AdviceSlips.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AdviceSlip entity)
    {
        _context.AdviceSlips.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(AdviceSlip entity)
    {
        _context.AdviceSlips.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
