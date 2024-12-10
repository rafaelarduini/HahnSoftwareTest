using HahnSoftwareTest.Application.Dtos;

namespace HahnSoftwareTest.Application.Interfaces;

public interface IExternalApiService
{
    Task<AdviceSlipDto?> GetRandomAdviceAsync();
}