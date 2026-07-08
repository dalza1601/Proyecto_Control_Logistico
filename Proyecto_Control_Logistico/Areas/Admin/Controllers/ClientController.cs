using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Domain.Constant;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Domain.Enums;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.UI.MVC.Utils;

namespace Proyecto_Control_Logistico.UI.MVC.Areas.Admin.Controllers
{
    [Area(AreaConstants.ADMIN)]
    public class ClientController : BaseController
    {
        public ClientController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _unitOfWork.ClientRepository.GetAll();
            var activeClients = clients.Where(x => x.Active).ToList();
            return View(activeClients.Select(x => _mapper.Map<ClientDTO>(x)));
        }

        public async Task<IActionResult> Create()
        {
            return PartialView("_Create", new ClientDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientDTO clientDTO)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<Client>(clientDTO);
                await _unitOfWork.ClientRepository.AddAsync(client);
                await _unitOfWork.SaveAsync();
                AlertTitleTextAndIcon("Cliente registrado", "El cliente ha sido registrado exitosamente.", TypeIconsNotification.success);
            }

            return Json(new { success = true, message = "Cliente registrado exitosamente." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var draw = Request.Query["draw"].FirstOrDefault();
            var searchValue = Request.Query["search[value]"].FirstOrDefault()?.ToLower();
            var start = Convert.ToInt32(Request.Query["start"].FirstOrDefault());
            var length = Convert.ToInt32(Request.Query["length"].FirstOrDefault());

            var query = await _unitOfWork.ClientRepository.GetAll(filter: Client => Client.Active);
            var recordsTotal = await query.CountAsync();

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(c => EF.Functions.Like(c.FullName.ToLower(), $"%{searchValue}%"));
            }

            var filteredList = await query.ToListAsync();

            var recordsFiltered = filteredList.Count();

            var clients = filteredList.Where(x => x.Active)
                .OrderBy(c => c.Id)
                .Skip(start)
                .Take(length)
                .Select(c => _mapper.Map<ClientDTO>(c))
                .ToList();

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = clients });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var client = await _unitOfWork.ClientRepository.GetByDniAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            var clientDTO = _mapper.Map<ClientDTO>(client);
            return PartialView("_Edit", clientDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ClientDTO clientDTO)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<Client>(clientDTO);
                await _unitOfWork.ClientRepository.Update(client);
                await _unitOfWork.SaveAsync();
                AlertTitleTextAndIcon("Cliente actualizado", "El cliente ha sido actualizado exitosamente.", TypeIconsNotification.success);
            }
            return Json(new { success = true, message = "Cliente actualizado exitosamente." });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            client.Active = false;
            await _unitOfWork.ClientRepository.Update(client);
            await _unitOfWork.SaveAsync();
            AlertTitleTextAndIcon("Cliente deshabilitado", "El cliente ha sido deshabilitado exitosamente.", TypeIconsNotification.success);
            return Json(new { success = true, message = "Cliente deshabilitado exitosamente." });
        }
    }
}
