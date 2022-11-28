using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Repository
{
    public abstract class BaseRepository<T, C> : IBaseRepository<T> where T : class where C : DbContext
    {
        #region Protected properties

        /// <summary>
        /// Context of database
        /// </summary>
        protected readonly C context;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">Context od database</param>
        public BaseRepository(C context)
        {
            this.context = context;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to get all entites to list
        /// </summary>
        /// <returns></returns>
        public async virtual Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Method to get one Tenity from databae by Id
        /// </summary>
        /// <param name="id">Id of this Entity</param>
        /// <returns></returns>
        public async virtual Task<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Method to insert entity to database
        /// </summary>
        /// <param name="task">Created entiti to past to the database</param>
        /// <returns></returns>
        public async virtual Task InsertAsync(T task)
        {
            await context.Set<T>().AddAsync(task);
        }

        /// <summary>
        /// Method to delete entity from database
        /// </summary>
        /// <param name="id">Id of this entity</param>
        /// <returns></returns>
        public async virtual Task DeleteAsync(Guid id)
        {
            T task = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(task);
        }

        /// <summary>
        /// Method to update entity in database
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Method to save change in database
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        #endregion

    }
}
