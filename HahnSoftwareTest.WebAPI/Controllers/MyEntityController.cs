using HahnSoftwareTest.Infrastructure.Repositories;
using HahnSoftwareTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using HahnSoftwareTest.Infrastructure.Data;

namespace HahnSoftwareTest.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyEntityController : ControllerBase
    {
        private readonly IRepository<MyEntity> _repository;

        public MyEntityController(IRepository<MyEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MyEntity entity)
        {
            await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MyEntity entity)
        {
            if (id != entity.Id)
                return BadRequest("Entity ID mismatch.");

            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            await _repository.DeleteAsync(entity);
            return NoContent();
        }
    }
}