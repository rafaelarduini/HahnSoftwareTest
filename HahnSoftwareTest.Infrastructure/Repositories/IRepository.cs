namespace HahnSoftwareTest.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves all records of the entity.
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific record by ID.
        /// </summary>
        /// <param name="id">The ID of the record.</param>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Adds a new record to the database.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates an existing record in the database.
        /// </summary>
        /// <param name="entity">The entity with the updates.</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes a record from the database.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        Task DeleteAsync(T entity);
    }
}