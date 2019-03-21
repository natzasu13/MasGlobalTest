$(document).ready(function () {

    $("#ConsultBtn").kendoButton({
        click: ConsultBtn_onClick
    });

    function ConsultBtn_onClick() {

        idEmployee = document.getElementById("idEmployee").value;
        if (idEmployee === "")
            idEmployee = 0;


        var dataSourceConnection = new kendo.data.DataSource({
            transport: {
                read: {
                    url: rootUrl + "api/GetEmployee/List?idEmployee=" + idEmployee,
                    dataType: "json",
                    type: "GET",
                },
            },
            batch: true,
        });

        $("#gridEmployeeConsult").kendoGrid({
            dataSource: dataSourceConnection,
            navigatable: true,
            pageable: true,
            height: 550,
            persistSelection: true,
            sortable: true,
            scrollable: true,
            filterable: {
                extra: false,
                operators: {
                    string: {
                        contains: "Contiene",
                        eq: "Es igual a",
                        neq: "Es diferente de",
                        startswith: "Inicia con",
                        doesnotcontain: "No contiene",
                        endswith: " Termina en",

                    }
                }
            },
            excel: {
                allPages: true,
                fileName: "EmployeeList.xlsx",
            },
            pdf: {
                allPages: true,
                paperSize: "A4",
                margin: { top: "3cm", right: "1cm", bottom: "1cm", left: "1cm" },
                landscape: true,
                template: $("#page-template").html(),
                fileName: "EmployeeList.pdf"
            },
            columns: [
                { field: "id", title: "id", width: 40 },
                { field: "name", title: "Fecha Ingreso", width: 150, },
                { field: "roleDescription", title: "Descripción", width: 140 },
                { field: "roleId", title: "Descripción", width: 140 },
                { field: "roleName", title: "Descripción", width: 140 },
                { field: "hourlySalary", title: "Descripción", width: 140 },
                { field: "monthlySalary", title: "Descripción", width: 140 },
            ],
            editable: false,
            save: function (e) {

            },
            edit: function (e) {

            },
            saveChanges: function (e) {


            }
        });

    }

});