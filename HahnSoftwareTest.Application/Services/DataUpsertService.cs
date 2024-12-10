using HahnSoftwareTest.Application.Interfaces;

namespace HahnSoftwareTest.Application.Services;

public class DataUpsertService : IDataUpsertService
{
    private readonly IExternalApiService _apiService;
    private readonly IAdviceSlipRepositoryService _repositoryService;

    public DataUpsertService(IExternalApiService apiService, IAdviceSlipRepositoryService repositoryService)
    {
        _apiService = apiService;
        _repositoryService = repositoryService;
    }

    public async Task PerformDataUpsertAsync()
    {
        var advice = await _apiService.GetRandomAdviceAsync();
        if (advice == null) throw new Exception("Failed to retrieve advice.");

        var existingAdvice = (await _repositoryService.GetAllAsync())
            .FirstOrDefault(e => e.Advice == advice.Advice);

        if (existingAdvice == null)
        {
            await _repositoryService.AddAsync(advice);
        }
        else
        {
            await _repositoryService.UpdateAsync(existingAdvice.SlipId, advice);
        }
    }
}
