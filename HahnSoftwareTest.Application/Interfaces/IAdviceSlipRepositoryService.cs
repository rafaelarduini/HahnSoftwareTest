using HahnSoftwareTest.Application.Dtos;

namespace HahnSoftwareTest.Application.Interfaces;

public interface IAdviceSlipRepositoryService
{
    Task<AdviceSlipDto?> GetByIdAsync(int id);

    Task<IEnumerable<AdviceSlipDto>> GetAllAsync();

    Task<AdviceSlipDto> AddAsync(AdviceSlipDto slipDto);

    Task<AdviceSlipDto?> UpdateAsync(int id, AdviceSlipDto slipDto);

    Task<bool> DeleteAsync(int id);
}