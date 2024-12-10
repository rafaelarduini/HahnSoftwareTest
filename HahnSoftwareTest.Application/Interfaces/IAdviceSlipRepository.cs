using HahnSoftwareTest.Domain.Entities;

namespace HahnSoftwareTest.Application.Interfaces;

public interface IAdviceSlipRepository
{
    Task<AdviceSlip?> GetByIdAsync(int id);

    Task<IEnumerable<AdviceSlip>> GetAllAsync();

    Task AddAsync(AdviceSlip entity);

    Task UpdateAsync(AdviceSlip entity);

    Task DeleteAsync(AdviceSlip entity);
}