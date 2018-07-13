using CarritoCompras.Entidad;
using CarritoCompras.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarritoCompras.EntityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPedidoService" in both code and config file together.
    [ServiceContract]
    public interface IPedidoService
    {
        [OperationContract]
        ResponseWeb GuardarPedido(PedidoEntidad entidad);
        [OperationContract]
        List<PedidoEntidad> ConsultarPedido(PedidoEntidad entidad);
        [OperationContract]
        ResponseWeb ModificarPedido(PedidoEntidad entidad);

    }
}
