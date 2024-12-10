using HahnSoftwareTest.Application.Dtos;
using HahnSoftwareTest.Application.Interfaces;
using HahnSoftwareTest.Application.Responses;
using Newtonsoft.Json;

namespace HahnSoftwareTest.Application.Services;

public class ExternalApiService : IExternalApiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ExternalApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<AdviceSlipDto?> GetRandomAdviceAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetStringAsync("https://api.adviceslip.com/advice");

        var adviceResponse = JsonConvert.DeserializeObject<SlipResponse>(response);
        return adviceResponse?.Slip == null
            ? null
            : new AdviceSlipDto
            {
                SlipId = adviceResponse.Slip.SlipId,
                Advice = adviceResponse.Slip.Advice
            };
    }
}