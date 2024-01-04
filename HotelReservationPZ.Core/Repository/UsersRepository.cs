using HotelReservation.EF;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace HotelReservation.Core.Repository
{
    public class UsersRepository : BaseRepository<IdentityUser, HotelDBContext>, IUsersRepository
    {
        #region Constructros

        /// <summary>
        /// Default constructro
        /// </summary>
        /// <param name="context">Context of database</param>
        public UsersRepository(HotelDBContext context) :base(context)
        {
            
        }

        #endregion

        #region Override

        public override IdentityUser GetById(Guid id)
        {
            return context.Users.Find(id.ToString());
        }

        public override async Task<IdentityUser> GetByIdAsync(Guid id)
        {
            return await context.Users.FindAsync(id.ToString());
        }

        #endregion
    }
}
