using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.Helper
{
    public static class Helper
    {
        public static DbSet<E> GetEntity<E>(this DbContext context) where E : class
        {
            var prop = context.GetType().GetProperties();
            var res = prop.FirstOrDefault(x => x.PropertyType == typeof(DbSet<E>));
            var obj = res.GetValue(context);
            return obj as DbSet<E>;
        }
    }
}
