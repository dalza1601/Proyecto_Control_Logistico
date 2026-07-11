$(document).ready(function () {

    $.get("/Admin/Purchase/GetSuppliers", function (data) {

        console.log(data); // Debe mostrar los proveedores

        var combo = $("#cmbProveedor");

        combo.empty();
        combo.append('<option value="">Seleccione...</option>');

        $.each(data, function (i, item) {
            combo.append(
                $("<option>")
                    .val(item.id)
                    .text(item.text)
            );
        });

    });

});
$("#cmbArticulo").change(function () {

    var precio = $("#cmbArticulo option:selected").data("precio");

    $("#txtCosto").val(precio);

    calcular();

});

$("#txtCantidad,#txtCosto").keyup(function () {

    calcular();

});

function calcular() {

    var cantidad = Number($("#txtCantidad").val());

    var costo = Number($("#txtCosto").val());

    $("#txtTotal").val((cantidad * costo).toFixed(2));

}
function calcularTotalGeneral() {

    let total = 0;

    $("#tblDetalle tbody tr").each(function () {

        total += parseFloat($(this).find("td:eq(3)").text()) || 0;

    });

    $("#lblTotalGeneral").text(total.toFixed(2));

}
$("#btnAgregar").click(function () {

    var articulo = $("#cmbArticulo option:selected").text();
    var id = $("#cmbArticulo").val();
    var cantidad = $("#txtCantidad").val();
    var costo = $("#txtCosto").val();
    var total = $("#txtTotal").val();

    if (id == "") {
        alert("Seleccione un producto");
        return;
    }

    if (cantidad <= 0) {
        alert("Ingrese cantidad válida");
        return;
    }


    if (filaEditar != null) {

        // EDITAR FILA EXISTENTE

        filaEditar.find("td:eq(0)").contents().first()[0].textContent = articulo;
        filaEditar.find("td:eq(1)").contents().first()[0].textContent = cantidad;
        filaEditar.find("td:eq(2)").contents().first()[0].textContent = parseFloat(costo).toFixed(2);
        filaEditar.find("td:eq(3)").contents().first()[0].textContent = parseFloat(total).toFixed(2);


        filaEditar.find("input[name='ArticuloId']").val(id);
        filaEditar.find("input[name='Cantidad']").val(cantidad);
        filaEditar.find("input[name='Costo']").val(costo);
        filaEditar.find("input[name='Total']").val(total);


        filaEditar = null;

    }
    else {

        // NUEVA FILA

        var fila = `
        <tr>

            <td>
                ${articulo}
                <input type="hidden" 
                       name="ArticuloId" 
                       value="${id}">
            </td>


            <td>
                ${cantidad}
                <input type="hidden" 
                       name="Cantidad" 
                       value="${cantidad}">
            </td>


            <td>
                ${parseFloat(costo).toFixed(2)}
                <input type="hidden" 
                       name="Costo" 
                       value="${costo}">
            </td>


            <td>
                ${parseFloat(total).toFixed(2)}
                <input type="hidden" 
                       name="Total" 
                       value="${total}">
            </td>


            <td class="text-center">

                <button type="button" 
                        class="btn btn-sm btn-warning btnEditar">
                    Editar
                </button>


                <button type="button" 
                        class="btn btn-sm btn-danger btnEliminar">
                    Eliminar
                </button>

            </td>

        </tr>`;

        $("#tblDetalle tbody").append(fila);
    }


    calcularTotalGeneral();


    $("#modalDetalle").modal("hide");


    // limpiar modal

    $("#cmbArticulo").val("");
    $("#txtCantidad").val("1");
    $("#txtCosto").val("");
    $("#txtTotal").val("");

});
let filaEditar = null;
$(document).on("click", ".btnEditar", function () {

    filaEditar = $(this).closest("tr");

    $("#cmbArticulo").val(filaEditar.find("input[name$='ArticuloId']").val());

    $("#txtCantidad").val(filaEditar.find("input[name$='Cantidad']").val());

    $("#txtCosto").val(filaEditar.find("input[name$='Costo']").val());

    $("#txtTotal").val(filaEditar.find("input[name$='Total']").val());

    $("#modalDetalle").modal("show");

});
$(document).on("click", ".btnEliminar", function () {

    $(this).closest("tr").remove();

    calcularTotalGeneral();

});
$("#btnGuardarCompra").click(function () {
    guardarCompra();
});
function guardarCompra() {

    var compra = {
        NumberOrder: $("#txtNumberOrder").val(),
        SupplierId: $("#cmbProveedor").val(),
        DateOrder: new Date(),
        Details: []
    };

    $("#tblDetalle tbody tr").each(function () {

        console.log("Fila encontrada");
        compra.Details.push({

            ProductId: $(this).find("input[name='ArticuloId']").val(),
            Quantity: $(this).find("input[name='Cantidad']").val(),
            UnitPrice: $(this).find("input[name='Costo']").val()

        });

    });
    console.log(compra);
    $.ajax({

        url: "/Admin/Purchase/Save",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(compra),

        success: function (response) {

            alert(response.message);

            location.reload();

        },

        error: function () {

            alert("Ocurrió un error al guardar.");

        }

    });

} 