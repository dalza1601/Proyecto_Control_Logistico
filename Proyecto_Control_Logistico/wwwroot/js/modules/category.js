
var datatableCategory;
$(document).ready(function () {
    dataTable = $("#tbCategories").DataTable();
});

function openModalCategory() {

    $.get("/Admin/Category/Create", function (response) {
        $("#categoryModalContent").html(response);
    });

}