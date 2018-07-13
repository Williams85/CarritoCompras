$(document).ready(function () {
    $("#btn-aceptar").on("click", function () {
        var parametros = {
            "Nom_Usuario": $("#Nom_Usuario").val(),
            "Pass_Usuario": $("#Pass_Usuario").val(),
        };

        ValidarUsuario(parametros);
    });

    $("#IdBuscarPedidos").on("click", function () {
        var parametros = {
            "Fecha_Inicio": $("#Fecha_Inicio").val(),
            "Fecha_Fin": $("#Fecha_Fin").val(),
        };
        $("#FechaInicio").val(parametros.Fecha_Inicio);        
        $("#FechaFin").val(parametros.Fecha_Fin);
        BuscarPedidos(parametros);
    });
});

function ValidarUsuario(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ValidarUsuario;
    info.parametros = parametros;
    ajax(info, function (data) {
        if (data != null) {
            if (data.Estado == true)
                location.href = "/Admin/ConsultarPedido/";
            else
                alert(data.Message);
        } else {
            alert("Ocurrio un error al grabar la venta...");
        }
    });
}

function BuscarPedidos(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.BuscarPedidos;
    info.parametros = parametros;
    ajaxPartialView(info, function (data) {
        if (data != null && data != "") {
            $("#ResultadoPedidos").html(data);
            $(".btn-accion").on("click",function(){
                var parametros={
                    "Cod_Pedido":$(this).attr("data-id"),
                    "Fecha_Inicio": $("#FechaInicio").val(),
                    "Fecha_Fin": $("#FechaFin").val(),
                };
                ModificarEstadoPedido(parametros);
            });
        } else {
            $("#ResultadoPedidos").empty();
        }
    });
}

function ModificarEstadoPedido(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ModificarEstadoPedido;
    info.parametros = parametros;
    ajax(info, function (data) {
        if (data != null) {
            if (data.Estado == true){
                BuscarPedidos(parametros);
            }else{
                alert(data.Message);
            }
        } else {
            alert("Ocurrio un error al grabar la venta...");
        }
    });
}