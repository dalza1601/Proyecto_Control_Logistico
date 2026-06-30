var datatableSale;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatableSale = $("#tbSales").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Admin/Sale/GetAllSales",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "numberSale", "width": "30%" },
            { "data": "totalAmount", "width": "50%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a onclick=openEditSaleModal(${data})
                                class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                <i class="far fa-edit"></i>Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Sale/Delete/${data}") 
                                class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                <i class="far fa-trash-alt"></i>Borrar
                                </a>
                            </div>`;
                },
                "width": "50%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros de ventas",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 a 0 de 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    })
}

function openModalSale() {
    $.get("/Admin/Sale/Create", function (response) {
        $("#saleModalContent").html(response);
    });
}

function openEditSaleModal(id) {
    $.ajax({
        url: "/Admin/Sale/Edit/" + id,
        type: "GET",
        success: function (response) {
            $("#saleModalContent").html(response);
            $("#saleModal").modal("show");
        },
        error: function (error) {
            toastr.error(error.responseJSON.message);
        }
    });
}

function Delete(url) {
    Swal.fire({
        title: "Esta seguro de borrar?",
        "text": "Este contenido no se puede recuperar",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, borrar!",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    datatableSale.ajax.reload(null, false);
                    Swal.fire({
                        title: "Eliminado!",
                        text: "Se elimino la venta con exito.",
                        icon: "success"
                    });
                    toastr.success(data.message);
                },
                error: function (error) {
                    toastr.error(error.responseJSON.message);
                }
            })

        }
    });
}

$(document).on("submit", "#frmSale", function (event) {
    event.preventDefault();//no permite que recarge la pagina
    $.ajax({
        url: $(this).attr("action"),
        type: $(this).attr("method"),//"POST"
        data: $(this).serialize(),
        success: function (response) {
            if (response.success) {
                $("#saleModal").modal("hide");
                datatableSale.ajax.reload(null, false);
                toastr.success(response.message);
            }
        },
        error: function (error) {
            toastr.error(error.responseJSON.message);
        }
    });
});
