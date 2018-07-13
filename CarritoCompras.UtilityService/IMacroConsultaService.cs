using CarritoCompras.Entidad;
using CarritoCompras.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CarritoCompras.UtilityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMacroConsultaService" in both code and config file together.
    [ServiceContract]
    public interface IMacroConsultaService
    {
        [OperationContract]
        List<CategoriaEntidad> ObtenerCategorias();

        [OperationContract]
        List<MedioPagoEntidad> ObtenerMediosPago();
        
        [OperationContract]
        List<ProductoEntidad> ObtenerProductos(ProductoEntidad entidad);

        [OperationContract]
        ClienteEntidad ObtenerCliente(ClienteEntidad entidad);

        [OperationContract]
        List<PedidoEntidad> ObtenerPedido(PedidoEntidad entidad);

        [OperationContract]
        List<DetallePedidoEntidad> ObtenerDetallePedido();

    }
}
