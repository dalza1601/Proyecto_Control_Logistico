var dataTableClient;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTableClient = $("#tblClients").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Admin/Client/GetAllClients",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": null,
                "orderable": false,
                "searchable": false,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                },
                "width": "10%"
            },
            { "data": "document", "name": "document", "width": "10%" },
            { "data": "fullName", "name": "fullName", "width": "25%" },
            { "data": "phone", "name": "phone", "width": "20%" },
            { "data": "email", "name": "email", "width": "20%" },
            {
                "data": "document",
                "render": function (data) {
                    return `<div class="text-center">
                                <a onclick=openEditClientModal(${data})
                                class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                <i class="far fa-edit"></i>Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Client/Delete/${data}") 
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
            "emptyTable": "No hay registros de clientes",
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
    });
}

function openModalClient() {
    $.get("/Admin/Client/Create", function (response) {
        $("#clientModalContent").html(response);
    });
}

function openEditClientModal(id) {
    $.ajax({
        url: "/Admin/Client/Edit/" + id,
        type: "GET",
        success: function (response) {
            $("#clientModalContent").html(response);
            $("#clientModal").modal("show");
        },
        error: function (error) {
            toastr.error(error.responseJSON.message);
        }
    });
}

function Delete(url) {
    Swal.fire({
        title: "Esta seguro de deshabilitar al cliente?",
        "text": "No podra realizar ninguna operacion con este cliente",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, deshabilitar!",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    datatableCategory.ajax.reload(null, false);
                    Swal.fire({
                        title: "Deshabilitado!",
                        text: "Se deshabilito el cliente con exito.",
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

$(document).on("submit", "#frmClient", function (event) {
    event.preventDefault();
    $.ajax({
        url: $(this).attr("action"),
        type: $(this).attr("method"),
        data: $(this).serialize(),
        success: function (response) {
            if (response.success) {
                $("#clientModal").modal("hide");
                dataTableClient.ajax.reload(null, false);
                toastr.success(response.message);
            }
        },
        error: function (error) {
            toastr.error(error.responseJSON.message);
        }
    });
});