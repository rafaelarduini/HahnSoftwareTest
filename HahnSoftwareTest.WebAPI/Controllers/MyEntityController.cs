namespace HahnSoftwareTest.WebAPI.Controllers
{
    using HahnSoftwareTest.Application.Interfaces;
    using HahnSoftwareTest.Application.Dtos;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class MyEntityController : ControllerBase
    {
        private readonly IMyEntityService _myEntityService;

        public MyEntityController(IMyEntityService myEntityService)
        {
            _myEntityService = myEntityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _myEntityService.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _myEntityService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MyEntityDto entity)
        {
            await _myEntityService.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MyEntityDto entity)
        {
            await _myEntityService.UpdateAsync(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _myEntityService.DeleteAsync(id);
            return NoContent();
        }
    }
}
