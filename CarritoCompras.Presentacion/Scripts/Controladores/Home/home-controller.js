$(document).ready(function () {

    $("#btn-comprar").hide()
    $(".btn-agregar").on("click", function () {
        var cantidad = $(this).parents("article").find("input").val();
        var parametros = {
            "Cod_Producto": $(this).attr("data-id"),
            "Cantidad": cantidad
        };
        ReservarProducto(parametros);
    });
    
});

function ReservarProducto(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ReservarProducto;
    info.parametros = parametros;
    ajax(info, function (data) {
        if (data != null) {
            alert(data.Message);
            if (data.Estado == true)
                $("#btn-comprar").show();
        } else {
            alert("Ocurrio un error al reservar el producto...");
        }
    });
}