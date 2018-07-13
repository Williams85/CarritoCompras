$(document).ready(function () {
    ListarDetallePedido();

    $("#IdPagar").on("click", function () {
        var mediopago = $(".form-check-input:checked").attr("id");
        if (mediopago == null && $.trim(mediopago) == "") {
            alert("Seleccionar un medio de pago");
            return false;
        }

        var parametros = {
            "Cliente": {
                "Nom_Cliente": $("#Nom_Cliente").val(),
                "Ema_Cliente": $("#Ema_Cliente").val()
            },
            "MedioPago": {
                "Cod_MedioPago": $(".form-check-input:checked").attr("id"),
            },
            "Dir_Entrega": $("#Dir_Entrega").val(),
            "Fecha_Entrega": $("#Fecha_Entrega").val()
        };
        console.log(parametros);
        GrabarVenta(parametros);
    });
});

function ListarDetallePedido() {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "GET";
    info.serviceURL = rutas.BuscarDetallePedido;
    info.parametros = {};

    ajaxPartialView(info, function (data) {
        if (data != null && data != "") {
            $("#ResultadoDetalleCompra").html(data);
            ListarMedioPago();
        } else {
            $("#ResultadoDetalleCompra").empty();
        }
    });
}

function ListarMedioPago() {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "GET";
    info.serviceURL = rutas.ListarMediosPago;
    info.parametros = {};

    ajaxPartialView(info, function (data) {
        if (data != null && data != "") {
            $("#ResultadoMediosPago").html(data);
        } else {
            $("#ResultadoMediosPago").empty();
        }
    });
}

function GrabarVenta(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.GrabarVenta;
    info.parametros = parametros;
    ajax(info, function (data) {
        console.log("Hola");
        console.log(data);
        if (data != null) {
            alert(data.Message);
        } else {
            alert("Ocurrio un error al grabar la venta...");
        }
    });
}