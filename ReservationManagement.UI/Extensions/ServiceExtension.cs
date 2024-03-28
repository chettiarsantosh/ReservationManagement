using AutoMapper;
using ReservationManagement.Core.Entities.Business;
using ReservationManagement.Core.Entities.General;
using ReservationManagement.Core.Interfaces.IMapper;
using ReservationManagement.Core.Interfaces.IRepositories;
using ReservationManagement.Core.Interfaces.IServices;
using ReservationManagement.Core.Mapper;
using ReservationManagement.Core.Services;
using ReservationManagement.Infrastructure.Repositories;

namespace ReservationManagement.UI.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IReservationService, ReservationService>();

            #endregion

            #region Repositories
            services.AddTransient<IReservationRepository, ReservationRepository>();

            #endregion

            #region Mapper
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Reservation, ReservationViewModel>();
                cfg.CreateMap<ReservationViewModel, Reservation>();
            });

            IMapper mapper = configuration.CreateMapper();

            // Register the IMapperService implementation with your dependency injection container
            services.AddSingleton<IBaseMapper<Reservation, ReservationViewModel>>(new BaseMapper<Reservation, ReservationViewModel>(mapper));
            services.AddSingleton<IBaseMapper<ReservationViewModel, Reservation>>(new BaseMapper<ReservationViewModel, Reservation>(mapper));

            #endregion

            return services;
        }
    }
}
