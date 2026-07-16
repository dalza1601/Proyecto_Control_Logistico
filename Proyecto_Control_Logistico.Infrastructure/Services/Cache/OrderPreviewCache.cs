using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Application.Interfaces.ICache;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Proyecto_Control_Logistico.Infrastructure.Services.Cache
{
    public class OrderPreviewCache : IOrderPreviewCache
    {
        private const string PREVIEW_KEY = "OrderPreview";
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        //ITempDataDictionaryFactory + IHttpContextAccessor: TempData normalmente
        //es una propiedad que solo existe dentro de un Controller. Por lo que para
        //acceder a ella desde una clase de servicio, necesitamos estos dos servicios.
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataDictionaryFactory _tempDataFactory;

        public OrderPreviewCache(IHttpContextAccessor httpContextAccessor,
            ITempDataDictionaryFactory tempDataFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataFactory = tempDataFactory;
        }

        private ITempDataDictionary TempData =>
        _tempDataFactory.GetTempData(_httpContextAccessor.HttpContext!);

        // Elimina la vista previa de la orden del TempData
        public void Clear()
        {
            TempData.Remove(PREVIEW_KEY);
        }

        // Recupera la vista previa de la orden del TempData.
        // Si keep es true, mantiene la vista previa en el TempData para que pueda
        // ser accedida nuevamente en la siguiente solicitud.
        public OrderDTO? Get(bool keep = true)
        {
            var tempData = TempData;
            if (tempData.TryGetValue(PREVIEW_KEY, out var json) && json is string jsonStr)
            {
                if (keep) tempData.Keep(PREVIEW_KEY);
                return JsonSerializer.Deserialize<OrderDTO>(jsonStr, _jsonOptions);
            }
            return null;
        }

        // Guarda la vista previa de la orden en el TempData.
        public void Save(OrderDTO orderDto)
        {
            TempData[PREVIEW_KEY] = JsonSerializer.Serialize(orderDto, _jsonOptions);
        }
    }
}
