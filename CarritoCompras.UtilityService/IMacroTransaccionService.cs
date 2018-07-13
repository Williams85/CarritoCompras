using CarritoCompras.Entidad;
using CarritoCompras.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarritoCompras.UtilityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMacroTransaccionService" in both code and config file together.
    [ServiceContract]
    public interface IMacroTransaccionService
    {
        [OperationContract]
        ResponseWeb ReservarProducto(ProductoEntidad entidad);

        [OperationContract]
        ResponseWeb RegistrarPedido(PedidoEntidad entidad);

        [OperationContract]
        ResponseWeb ActualizarPedido(PedidoEntidad entidad);

        [OperationContract]
        ResponseWeb RegistrarCliente(ClienteEntidad entidad);

        [OperationContract]
        ResponseWeb ActualizarCliente(ClienteEntidad entidad);
    }
}
