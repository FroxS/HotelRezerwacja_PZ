using HotelReservation.Core.Repository;
using HotelReservation.Core.Service;
using HotelReservation.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservation.Core.Helpers
{
    public static class ServiceCollectionHelper
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IHotelCategoryService, HotelCategoryService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
        }

        public static void ConfigureDatabase(this IServiceCollection services)
        {
            services.AddDbContext<HotelDBContext>(
                    options => options.UseSqlServer("Server=.; Database=hotelreservation; Trusted_Connection=True"));
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IHotelsRepository, HotelsRepository>();
            services.AddScoped<IHotelCategoryRepository, HotelCategoryRepository>();
            services.AddScoped<IRoomsRepository, RoomsRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();

        }
    }
}