using ReservationManagement.Core.Entities.Business;
using ReservationManagement.Core.Entities.General;
using ReservationManagement.Core.Interfaces.IMapper;
using ReservationManagement.Core.Interfaces.IRepositories;
using ReservationManagement.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagement.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IBaseMapper<Reservation, ReservationViewModel> _reservationViewModelMapper;
        private readonly IBaseMapper<ReservationViewModel, Reservation> _reservationMapper;
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(
            IBaseMapper<Reservation, ReservationViewModel> reservationViewModelMapper,
            IBaseMapper<ReservationViewModel, Reservation> reservationMapper,
            IReservationRepository reservationRepository)
        {
            _reservationMapper = reservationMapper;
            _reservationViewModelMapper = reservationViewModelMapper;
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<ReservationViewModel>> GetReservations()
        {
            return _reservationViewModelMapper.MapList(await _reservationRepository.GetAll());
        }

        public async Task<PaginatedDataViewModel<ReservationViewModel>> GetPaginatedReservations(int pageNumber, int pageSize)
        {
            //Get peginated data
            var paginatedData = await _reservationRepository.GetPaginatedData(pageNumber, pageSize);

            //Map data with ViewModel
            var mappedData = _reservationViewModelMapper.MapList(paginatedData.Data);

            var paginatedDataViewModel = new PaginatedDataViewModel<ReservationViewModel>(mappedData.ToList(), paginatedData.TotalCount);

            return paginatedDataViewModel;
        }

        public async Task<ReservationViewModel> GetReservation(int id)
        {
            return _reservationViewModelMapper.MapModel(await _reservationRepository.GetById(id));
        }

        public async Task<bool> IsExists(string key, string value)
        {
            return await _reservationRepository.IsExists(key, value);
        }

        public async Task<bool> IsExistsForUpdate(int id, string key, string value)
        {
            return await _reservationRepository.IsExistsForUpdate(id, key, value);
        }

        public async Task<ReservationViewModel> Create(ReservationViewModel model)
        {
            //Mapping through AutoMapper
            var entity = _reservationMapper.MapModel(model);
            entity.EntryDate = DateTime.Now;

            return _reservationViewModelMapper.MapModel(await _reservationRepository.Create(entity));
        }

        public async Task Update(ReservationViewModel model)
        {
            var existingData = await _reservationRepository.GetById(model.Id);

            //Manual mapping
            existingData.ReservationDate = model.ReservationDate;
            existingData.ClientName = model.ClientName;
            existingData.NumberOfGuests = model.NumberOfGuests;
            existingData.UpdateDate = DateTime.Now;

            await _reservationRepository.Update(existingData);
        }

        public async Task Delete(int id)
        {
            var entity = await _reservationRepository.GetById(id);
            await _reservationRepository.Delete(entity);
        }
    }
}
