"use strict";
$(function () {

    var report = {
        Id: "",
        Name: "",
        Order: 0,
        BoxSize: "",
        ChartType: ""
    }

    $(".repotGrid").on("click", "#reportViewCreate", function () {
        $("#reportIdCreate").val("");
        clearCreateUpDateForm();
        $("#modalTitle").children().remove();
        $("#modalTitle").append('<h2>Crear</h2>');
    });

    $("#reportSave").click(createUpdate);

    $(".repotGrid").on("click", ".reportDelete", SelectToDelete);

    $(".repotGrid").on("click", ".reportUpdate", function () {
        $("#modalTitle").children().remove();
        $("#modalTitle").append('<h2>Editar</h2>');
        console.log("acá");
    }, SelectToEdit);


    function SelectToDelete() {
        var selectedId = $(this).data("report-reportid");
        DeleteReport(selectedId);
    };

    function createUpdate() {       
        report.Id= $("#reportIdCreate").val();
        report.Name= $("#reportNameCreate").val();
        report.Order=$("#reportOrderCreate").val();
        report.BoxSize= $("#reportBoxSizeCreate").val();
        report.ChartType= $("#reportChartTypeCreate").val();    
    
    if (createReportIsValid(report) === true) {
        createUpdateReportAjax(report);
        clearCreateUpDateForm();
    }

}

    function createReportIsValid(report) {
        var isValid = true;
        var errorDiv = $("#createErrorDiv")
        errorDiv.empty();

        if (report.Name.length === 0) {
            errorDiv.append('<p class="errorMes" style="color:red">• Introducir Nombre</p>');
            isValid = false;
        }
        if (report.Order <= 0) {
            errorDiv.append('<p class="errorMes" style="color:red">• Introducir Orden, mayor a cero hola</p>');
            isValid = false;
        }

        return isValid;

    }

    function createUpdateReportAjax(report) {
        $.ajax({
            url: '/Report/Create',
            type: 'POST',
            cache: false,
            traditional: true,
            data: report
        }).success(function () {
            $("#createReportModal").modal("hide"); //close modal
            LoadReportsGrid();
        });
    }

    function LoadReportsGrid() {
        $.ajax({
            url: '/Report/ReportGrid',
            type: 'GET',
            cache: false,
            contentType: "application/HTML; charset=utf-8",
            dataType: "HTML",
        }).success(function (result) {
            $(".repotGrid").html(result);
        });
    }

    function DeleteReport(id) {
        $.ajax({
            url: '/Report/Delete',
            type: 'POST',
            cache: false,
            traditional: true,
            data: { 'id': id }
        }).success(function () {
            LoadReportsGrid();
        });
    }

    function SelectToEdit() {
        var selectedId = $(this).data("report-reportid");
        LoadEditReportForm(selectedId);
        console.log(selectedId);
    };



    function LoadEditReportForm(id) {
        $.ajax({
            url: '/Report/LoadUpdateForm',
            type: 'Get',
            cache: false,
            traditional: true,
            data: { 'id': id }
        }).success(function (data) {
            $("#reportIdCreate").val(data.Id);
            $("#reportNameCreate").val(data.Name);
            $("#reportOrderCreate").val(data.Order);
            $("#reportBoxSizeCreate").prop('selectedIndex', data.BoxSize);
            $("#reportChartTypeCreate").prop('selectedIndex', data.ChartType);
            LoadReportsGrid();
        });
    }

    function clearCreateUpDateForm() {
        $("#reportNameCreate").val("");
        $("#reportOrderCreate").val(0);
        $("#reportBoxSizeCreate").prop('selectedIndex', 0);
        $("#reportChartTypeCreate").prop('selectedIndex', 0);
    }

});


