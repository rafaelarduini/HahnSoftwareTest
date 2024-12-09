using HahnSoftwareTest.Application.Dtos;

namespace HahnSoftwareTest.Application.Interfaces
{
    public interface IMyEntityService
    {
        Task<IEnumerable<MyEntityDto>> GetAllAsync();

        Task<MyEntityDto?> GetByIdAsync(int id);

        Task AddAsync(MyEntityDto entity);

        Task UpdateAsync(int id, MyEntityDto entity);

        Task DeleteAsync(int id);
    }
}