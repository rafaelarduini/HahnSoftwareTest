namespace HahnSoftwareTest.Application.Services
{
    using HahnSoftwareTest.Application.Interfaces;
    using HahnSoftwareTest.Application.Dtos;
    using HahnSoftwareTest.Infrastructure.Repositories;
    using HahnSoftwareTest.Domain.Entities;

    public class MyEntityService : IMyEntityService
    {
        private readonly IRepository<MyEntity> _repository;

        public MyEntityService(IRepository<MyEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MyEntityDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => new MyEntityDto
            {
                Id = e.Id,
                Name = e.Name
            });
        }

        public async Task<MyEntityDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new MyEntityDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public async Task AddAsync(MyEntityDto entity)
        {
            var myEntity = new MyEntity
            {
                Name = entity.Name
            };

            await _repository.AddAsync(myEntity);
        }

        public async Task UpdateAsync(int id, MyEntityDto entity)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity != null)
            {
                existingEntity.Name = entity.Name;
                await _repository.UpdateAsync(existingEntity);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }
    }
}