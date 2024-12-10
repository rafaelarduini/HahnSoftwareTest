using HahnSoftwareTest.Application.Dtos;
using HahnSoftwareTest.Application.Interfaces;
using HahnSoftwareTest.Domain.Entities;

namespace HahnSoftwareTest.Application.Services;

public class AdviceSlipRepositoryService : IAdviceSlipRepositoryService
{
    private readonly IAdviceSlipRepository _repository;

    public AdviceSlipRepositoryService(IAdviceSlipRepository repository)
    {
        _repository = repository;
    }

    public async Task<AdviceSlipDto?> GetByIdAsync(int id)
    {
        var adviceSlip = await _repository.GetByIdAsync(id);
        return adviceSlip == null ? null : new AdviceSlipDto { SlipId = adviceSlip.Id, Advice = adviceSlip.Advice };
    }

    public async Task<IEnumerable<AdviceSlipDto>> GetAllAsync()
    {
        var adviceSlips = await _repository.GetAllAsync();
        return adviceSlips.Select(slip => new AdviceSlipDto { SlipId = slip.Id, Advice = slip.Advice });
    }

    public async Task<AdviceSlipDto> AddAsync(AdviceSlipDto slipDto)
    {
        var entity = new AdviceSlip { Advice = slipDto.Advice };
        await _repository.AddAsync(entity);
        return new AdviceSlipDto { SlipId = entity.Id, Advice = entity.Advice };
    }

    public async Task<AdviceSlipDto?> UpdateAsync(int id, AdviceSlipDto slipDto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;

        entity.Advice = slipDto.Advice;
        await _repository.UpdateAsync(entity);

        return new AdviceSlipDto { SlipId = entity.Id, Advice = entity.Advice };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}
