using HahnSoftwareTest.Application.Dtos;
using HahnSoftwareTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HahnSoftwareTest.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdviceSlipController : ControllerBase
{
    private readonly IAdviceSlipRepositoryService _service;

    public AdviceSlipController(IAdviceSlipRepositoryService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var adviceSlip = await _service.GetByIdAsync(id);
        return adviceSlip == null ? NotFound() : Ok(adviceSlip);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var adviceSlips = await _service.GetAllAsync();
        return Ok(adviceSlips);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AdviceSlipDto adviceSlipDto)
    {
        var createdSlip = await _service.AddAsync(adviceSlipDto);
        return CreatedAtAction(nameof(GetById), new { id = createdSlip.SlipId }, createdSlip);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, AdviceSlipDto adviceSlipDto)
    {
        var updatedSlip = await _service.UpdateAsync(id, adviceSlipDto);
        return updatedSlip == null ? NotFound() : Ok(updatedSlip);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _service.DeleteAsync(id);
        return isDeleted ? NoContent() : NotFound();
    }
}
