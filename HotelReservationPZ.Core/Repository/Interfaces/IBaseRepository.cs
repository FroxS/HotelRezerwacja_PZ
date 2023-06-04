using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Delete Entity by Id
        /// </summary>
        /// <param name="id">Id of this entity</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Delete Entity by Id
        /// </summary>
        /// <param name="id">Id of this entity</param>
        /// <returns></returns>
        void Delete(Guid id);

        /// <summary>
        /// Method to gel all entities
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Method to gel all entities
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Method to get Entity by Id
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Method to get Entity by Id
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns></returns>
        T GetById(Guid id);

        /// <summary>
        /// Method to insert entity to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task InsertAsync(T entity);

        /// <summary>
        /// Method to insert entity to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Insert(T task);

        /// <summary>
        /// Method to save database
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();

        /// <summary>
        /// Method to save database
        /// </summary>
        /// <returns></returns>
        void Save();

        /// <summary>
        /// Method to update database
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(T entity);
    }
}