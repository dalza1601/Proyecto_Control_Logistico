using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using Proyecto_Control_Logistico.UI.MVC.Utils;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SaleController : BaseController
    {
        public SaleController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
        {            
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            var draw = Request.Query["draw"].FirstOrDefault();
            var searchValue = Request.Query["search[value]"].FirstOrDefault()?.ToLower();
            var start = Convert.ToInt32(Request.Query["start"].FirstOrDefault());
            var length = Convert.ToInt32(Request.Query["length"].FirstOrDefault());

            var query = await _unitOfWork.SaleRepository.GetAll();
            var recordsTotal = await query.CountAsync();

            if (!string.IsNullOrEmpty(searchValue))
                query = query.Where(c => EF.Functions.Like(c.NumberSale, $"%{searchValue}%"));
            //query = query.Where(c => c.Name.ToLower().Contains(searchValue.ToLower()));

            //Liberamos el dbcontext para evitar problemas de tracking y rendimiento
            var filteredList = await query.ToListAsync();

            var recordsFiltered = filteredList.Count();

            var sales = filteredList.OrderBy(c => c.Id)
                .Skip(start)
                .Take(length)
                .Select(c => _mapper.Map<SaleDTO>(c))
                .ToList();

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = sales });
        }

        public async Task<IActionResult> Create()
        {
            var sale = new SaleDTO();
            return PartialView("_Create", sale);
        }
    }
}
