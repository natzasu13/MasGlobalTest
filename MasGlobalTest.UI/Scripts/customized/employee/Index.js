$(document).ready(function () {
    var dataSourceConnection = new kendo.data.DataSource({
        transport: {
            read: {
                url: rootUrl + "api/Employee/EmployeeList",
                dataType: "json",
                type: "GET",
            },
        },
        batch: true,
        pageSize: 7,//Number of items per page for the page
        schema: {

            total: "total",//here the total value of the records in the database for the handling of page is returned
            data: "data"//Here the data to be displayed in the datagrid is returned
        },
        serverPaging: true,//We indicate to the pager that it takes the page data from the server
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
            { field: "salary", title: "Descripción", width: 140 },
            { field: "create", title: "idUser", width: 140, format: "{0:dd/MM/yyyy HH:mm:ss}" },
        ],
        editable: false,
        save: function (e) {

        },
        edit: function (e) {

        },  
        saveChanges: function (e) {


        }
    });

});