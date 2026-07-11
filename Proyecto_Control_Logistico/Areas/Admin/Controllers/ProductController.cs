using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.FL.UTIL.Excel.Interfaces;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using Proyecto_Control_Logistico.UI.MVC.Utils;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
        { }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var draw = Request.Query["draw"].FirstOrDefault();
            var searchValue = Request.Query["search[value]"].FirstOrDefault()?.ToLower();
            var start = Convert.ToInt32(Request.Query["start"].FirstOrDefault());
            var length = Convert.ToInt32(Request.Query["length"].FirstOrDefault());

            var query = (await _unitOfWork.ProductRepository.GetAll())

                   .Where(x => x.Active);

            var recordsTotal = await query.CountAsync();

            if (!string.IsNullOrEmpty(searchValue))
                query = query.Where(c => EF.Functions.Like(c.Name, $"%{searchValue}%"));

            var filteredList = await query.ToListAsync();

            var recordsFiltered = filteredList.Count();

            var products = filteredList
                .OrderBy(c => c.Id)
                .Skip(start)
                .Take(length)
                .Select(c => _mapper.Map<ProductDTO>(c))
                .ToList();

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = products });
        }
    }
}
