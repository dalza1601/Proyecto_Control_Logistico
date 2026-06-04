using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Control_Logistico.Domain;
using Proyecto_Control_Logistico.Domain.Enums;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;

namespace Proyecto_Control_Logistico.UI.MVC.Utils
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<BaseController> _logger;
        protected readonly IMapper _mapper;

        // Constructor para inyectar dependencias
        public BaseController(IUnitOfWork unitOfWork, ILogger<BaseController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public void Alert(string message, NotificationType notificationType)
        {
            var msg = $"<script language='javascript' type='text/javascript'>Swal.fire('{notificationType.ToString().ToUpper()}', '{message}', '{notificationType}')</script>";
            TempData["notification"] = msg;
        }

        public void AlertDraggable(string title, TypeIconsNotification typeIcons)
        {
            var msg = $"<script language='javascript' type='text/javascript'>" +
                "Swal.fire({title:" + $"'{title}', icon: '{typeIcons}', draggable: true" + " })</script>";
            TempData["notification"] = msg;
        }

        public void AlertTitleTextAndIcon(string title, string text, TypeIconsNotification typeIcons)
        {
            var msg = $"<script language='javascript' type='text/javascript'>" +
                "Swal.fire({title:" + $"'{title}', text: '{text}', icon: '{typeIcons}', draggable: true" + " })</script>";
            TempData["notification"] = msg;
        }

        public void AlertErrorWithFooter(string title, TypeIconsNotification typeIcons, string text, string footer = "") 
        {
            var msg = $"<script language='javascript' type='text/javascript'>" +
                "Swal.fire({icon: " + $"'{typeIcons}'" + ", title:" + $"'{title}', text: '{text}', footer: '{footer}'" + " })</script>";
            TempData["notification"] = msg;
        }

        public void AlertWithImage(string imgUrl, int imageHeight, string imageAlt)
        {
            var msg = $"<script language='javascript' type='text/javascript'>" +
                "Swal.fire({imageUrl: " + $"'{imgUrl}'" + ", imageHeight:" + $"'{imageHeight}', imageAlt: '{imageAlt}'" + " })</script>";
            TempData["notification"] = msg;
        }

        public void AlertDeleteYesOrNot() 
        {
            var msg = $"<script language='javascript' type='text/javascript'>" +
                    "const swalWithBootstrapButtons = Swal.mixin({" +
            "customClass:{confirmButton: 'btn btn-success'," +
            "cancelButton: 'btn btn-danger' }, buttonsStyling: false });" +
            "swalWithBootstrapButtons.fire({" +
            "title: " + $"'{Constants.TITLE_MESSAGE_DELETE}'" + ", " +
            "text: " + $"'{Constants.TEXT_MESSAGE_DELETE}'" + ", " +
            "icon: " + $"'{TypeIconsNotification.warning}'" + ", " +
            "showCancelButton: true, " +
            "confirmButtonText: " + $"'{Constants.TITLE_CONFIRM_DELETE}'" + ", " +
            "cancelButtonText: " + $"'{Constants.TITLE_CANCEL_DELETE}'" + $", reverseButtons: true" + "}).then((result) => {" +
            "if (result.isConfirmed) swalWithBootstrapButtons.fire({" +
            "title: " + $"'{Constants.TITLE_DELETED}'" + ", " +
            "text: " + $"'{Constants.TEXT_DELETED}'" + ", " +
            "icon: " + $"'{TypeIconsNotification.success}'" +
            "}); else if (result.dismiss === Swal.DismissReason.cancel)" +
            "swalWithBootstrapButtons.fire({" +
        "title: " + $"'{Constants.TEXT_CANCELLED}'" + ", " +
        "text: " + $"'{Constants.TEXT_SAFE_FILE}'" + "," +
    "icon: " + $"'{TypeIconsNotification.error}'" + " })" +
    "});</script>";
            TempData["notification"] = msg;
        }

        public void Message(string message, NotificationType notificationType) 
        {
            TempData["notification2"] = message;

            switch (notificationType)
            {
                case NotificationType.sucess:
                    TempData["NotificationCSS"] = "alert-box success";
                    break;  
                case NotificationType.error:
                    TempData["NotificationCSS"] = "alert-box error";
                    break;
                case NotificationType.warning:
                    TempData["NotificationCSS"] = "alert-box warning";
                    break;
                case  NotificationType.info:
                    TempData["NotificationCSS"] = "alert-box notice";
                    break;
            }
        }
    }
}
