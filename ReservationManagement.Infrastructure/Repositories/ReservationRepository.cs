using Microsoft.CodeAnalysis;
using ReservationManagement.Core.Entities.General;
using ReservationManagement.Core.Interfaces.IRepositories;
using ReservationManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagement.Infrastructure.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
