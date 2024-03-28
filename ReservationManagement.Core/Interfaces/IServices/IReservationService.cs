using ReservationManagement.Core.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagement.Core.Interfaces.IServices
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationViewModel>> GetReservations();
        Task<PaginatedDataViewModel<ReservationViewModel>> GetPaginatedReservations(int pageNumber, int pageSize);
        Task<ReservationViewModel> GetReservation(int id);
        Task<bool> IsExists(string key, string value);
        Task<bool> IsExistsForUpdate(int id, string key, string value);
        Task<ReservationViewModel> Create(ReservationViewModel model);
        Task Update(ReservationViewModel model);
        Task Delete(int id);
    }
}
