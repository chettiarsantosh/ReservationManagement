using Microsoft.AspNetCore.Mvc;
using ReservationManagement.Core.Entities.Business;
using ReservationManagement.Core.Interfaces.IServices;
using ReservationManagement.Core.Services;
using X.PagedList;

namespace ReservationManagement.UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }

        // GET: ReservationController
        public async Task<IActionResult> Index(int? page)
        {
            try
            {
                int pageSize = 4;
                int pageNumber = (page ?? 1);

                //Get peginated data
                var reservations = await _reservationService.GetPaginatedReservations(pageNumber, pageSize);

                // Convert the list of reservations to an instance of StaticPagedList<ReservationViewModel>>
                var pagedReservations = new StaticPagedList<ReservationViewModel>(reservations.Data, pageNumber, pageSize, reservations.TotalCount);

                return View(pagedReservations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving reservations");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        public async Task<IActionResult> Create(ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _reservationService.Create(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while adding the reservation");
                    ModelState.AddModelError("Error", $"An error occurred while adding the reservation- " + ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: ReservationController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var data = await _reservationService.GetReservation(id);
                return View(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the reservation");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: ReservationController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var data = await _reservationService.GetReservation(id);
                return View(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the reservation");
                return StatusCode(500, ex.Message);
            }
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _reservationService.Update(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while updating the reservation");
                    ModelState.AddModelError("Error", $"An error occurred while updating the reservation- " + ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        // Get: ReservationController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _reservationService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the reservation");
                return View("Error");
            }
        }
    }
}
