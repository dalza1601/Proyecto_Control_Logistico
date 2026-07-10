var dataTableWarehouse;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTableWarehouse = $("#tblWarehouses").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Admin/WareHouse/GetAllWareHouses",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "10%"},
            { "data": "name", "name": "name", "width": "30%" },
            { "data": "address", "name": "address", "width": "40%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="row w-100">
                                <div class="col-6">
                                    <a onclick=openEditWarehouseModal(${data})
                                    class="btn btn-success text-white btn-sm p-1" style="cursor:pointer; width:50px;">
                                    <i class="fa-solid fa-pen-to-square"></i>Editar
                                    </a>
                                </div>
                                <div class="col-6">
                                    <a onclick=Delete("/Admin/WareHouse/Delete/${data}") 
                                    class="btn btn-danger text-white btn-sm p-1" style="cursor:pointer; width:50px;">
                                    <i class="fa-solid fa-trash"></i>Borrar
                                    </a>
                                </div>
                            </div>`;
                },
                "width": "20%"
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

function openModalWarehouse() {
    $.get("/Admin/Warehouse/Create", function (response) {
        $("#warehouseModalContent").html(response);
    });
}

function openEditWarehouseModal(id) {
    $.ajax({
        url: "/Admin/WareHouse/Edit/" + id,
        type: "GET",
        success: function (response) {
            $("#warehouseModalContent").html(response);
            $("#warehouseModal").modal("show");
        },
        error: function (error) {
            toastr.error(error.responseJSON.message);
        }
    });
}

function openDetailsWarehouseModal(id) {
    $.ajax({
        url: "/Admin/WareHouse/Details/" + id,
        type: "GET",
        success: function (response) {
            $("#warehouseModalContent").html(response);
            $("#warehouseModal").modal("show");
        },
        error: function (error) {
            toastr.error(error.responseJSON.message);
        }
    });
}

function Delete(url) {
    Swal.fire({
        title: "Esta seguro de deshabilitar al almacén?",
        "text": "No podra realizar ninguna operacion con este almacén",
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
                    dataTableWarehouse.ajax.reload(null, false);
                    Swal.fire({
                        title: "Deshabilitado!",
                        text: "Se deshabilito el almacén con exito.",
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

$(document).on("submit", "#frmWarehouse", function (event) {
    event.preventDefault();
    $.ajax({
        url: $(this).attr("action"),
        type: $(this).attr("method"),
        data: $(this).serialize(),
        success: function (response) {
            if (response.success) {
                $("#warehouseModal").modal("hide");
                dataTableWarehouse.ajax.reload(null, false);
                toastr.success(response.message);
            }
        },
        error: function (error) {
            toastr.error(error.responseJSON.message);
        }
    });
});