using HotelReservation.Core.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.Core.Repository
{
    // TODO
    public abstract class BaseRepository<T,C> where T: class where C: DbContext
    {
        protected readonly C context;

        public BaseRepository(C context)
        {
            this.context = context;
        }

        public virtual List<T> Get()
        {
            return context.GetEntity<T>().ToList();
        }
        public virtual T GetById(Guid id)
        {
            return context.GetEntity<T>().Find(id);
        }
        public virtual void Insert(T task)
        {
            context.GetEntity<T>().Add(task);
        }
        public virtual void Delete(Guid id)
        {
            T task = context.GetEntity<T>().Find(id);
            context.GetEntity<T>().Remove(task);
        }
        public virtual void Update(T task)
        {
            context.Entry(task).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
