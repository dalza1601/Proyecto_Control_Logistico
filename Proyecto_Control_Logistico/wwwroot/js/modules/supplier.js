var datatableSupplier;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatableSupplier = $("#tbSuppliers").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Admin/Supplier/GetAllSuppliers",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "ruc", "width": "15%" },
            { "data": "name", "width": "20%" },
            { "data": "address", "width": "20%" },
            { "data": "phone", "width": "20%" },
            { "data": "email", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="row w-100">
                                <div class="col-6">
                                    <a onclick=openEditSupplierModal(${data})
                                    class="btn btn-success text-white btn-sm p-1" style="cursor:pointer; width:50px;">
                                    <i class="fa-solid fa-pen-to-square"></i>Editar
                                    </a>
                                </div>
                                <div class="col-6">
                                    <a onclick=Delete("/Admin/Supplier/Delete/${data}") 
                                    class="btn btn-danger text-white btn-sm p-1" style="cursor:pointer; width:50px;">
                                    <i class="fa-solid fa-trash"></i>Borrar
                                </a>
                            </div>`;
                },
                "width": "50%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros de Proveedores",
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

function openModalSupplier() {
    $.get("/Admin/Supplier/Create", function (response) {
        $("#supplierModalContent").html(response);
    });
}

function openEditSupplierModal(id) {
    $.ajax({
        url: "/Admin/Supplier/Edit/" + id,
        type: "GET",
        success: function (response) {
            $("#supplierModalContent").html(response);
            $("#supplierModal").modal("show");
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
                    datatableSupplier.ajax.reload(null, false);
                    Swal.fire({
                        title: "Eliminado!",
                        text: "Se elimino la proveedor con exito.",
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

$(document).on("submit", "#frmSupplier", function (event) {
    event.preventDefault();
    $.ajax({
        url: $(this).attr("action"),
        type: $(this).attr("method"),
        data: $(this).serialize(),

        success: function (response) {

            if (response.success) {

                $("#supplierModal").modal("hide");
                datatableSupplier.ajax.reload(null, false);
                toastr.success(response.message);

            }
            else {

                // El formulario permanece abierto
                toastr.error(response.message);
            }
        },
        error: function (error) {
            if (xhr.responseJSON && xhr.responseJSON.message) {
                toastr.error(xhr.responseJSON.message);
            } else {
                toastr.error("Ocurrió un error al guardar el proveedor.");
            }
        }
    });
});
