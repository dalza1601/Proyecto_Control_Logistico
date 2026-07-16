using Proyecto_Control_Logistico.Domain.Constant;

namespace Proyecto_Control_Logistico.Domain.Maps
{
    public class StatusMap
    {
        private readonly Dictionary<string, string> _statusDescriptions = new Dictionary<string, string>()
        {
            { StatusConstants.PENDING_CODE, StatusConstants.PENDING },
            { StatusConstants.APPROVED_CODE, StatusConstants.APPROVED },
            { StatusConstants.REJECTED_CODE, StatusConstants.REJECTED },
            { StatusConstants.CANCELLED_CODE, StatusConstants.CANCELLED }
        };

        private readonly Dictionary<string, string> _descriptionToStatus = new Dictionary<string, string>();

        public StatusMap()
        {
            // Generar diccionario inverso automáticamente
            foreach (var par in _statusDescriptions)
            {
                _descriptionToStatus[par.Value.ToLower()] = par.Key;
            }
        }

        // De Código a nombre (ej: "P" -> "Pendiente")
        public string ObtenerDescripcion(string codigo)
        {
            return _statusDescriptions.TryGetValue(codigo.ToUpper(), out string valor) ? valor : StatusConstants.UNKNOWN;
        }

        // De nombre a Codigo (ej: "pendiente" -> "P")
        public string ObtenerCodigo(string descripcion)
        {
            return _descriptionToStatus.TryGetValue(descripcion.ToLower(), out string valor) ? valor : StatusConstants.UNKNOWN_CODE;
        }
    }
}
