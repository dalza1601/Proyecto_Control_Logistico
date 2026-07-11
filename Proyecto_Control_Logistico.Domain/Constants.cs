using System.Collections.Immutable;

namespace Proyecto_Control_Logistico.Domain
{
    public static class Constants
    {
        public const string TITLE_MESSAGE_DELETE = "¿Estás seguro de eliminar este registro?";
        public const string TEXT_MESSAGE_DELETE = "¡No podrás revertir esta acción!";
        public const string TITLE_CONFIRM_DELETE = "¡Confirmar eliminación!";
        public const string TITLE_CANCEL_DELETE = "¡Cancelar eliminación!";
        public const string TITLE_DELETED = "¡Eliminado!";
        public const string TEXT_DELETED = "El registro ha sido eliminado.";
        public const string TEXT_CANCELLED = "La operación ha sido cancelada    .";
        public const string TEXT_SAFE_FILE = "El registro está a salvo.";

        //Sale constants
        public const string SALE_STATUS_REGISTERED = "Registrado";
        public const string SALE_STATUS_REVIEWED = "Revisado";
        public const string SALE_STATUS_PENDING_SHIPMENT = "Pendiente de envio";
        public const string SALE_STATUS_DELIVERED = "Entregado";
        public const string SALE_STATUS_CANCELLED = "Anulado";

        public static readonly ImmutableDictionary<string, string> TypeErrors = new Dictionary<string, string>
        {
            { "NotFound", "Registro no encontrado." },
            { "Conflict", "Conflicto de datos." },
            { "InternalServerError", "Error interno del servidor." }
        }.ToImmutableDictionary();
    }
}
