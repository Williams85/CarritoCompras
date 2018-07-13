using CarritoCompras.Process.PS;
using CarritoCompras.Process.US;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CarritoCompras.Process
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdministracionService" in both code and config file together.
    [ServiceContract]
    public interface IAdministracionService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ValidarUsuario", ResponseFormat = WebMessageFormat.Json)]
        UsuarioEntidad ValidarUsuario(UsuarioEntidad entidad);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ConsultarPedido", ResponseFormat = WebMessageFormat.Json)]
        List<PedidoEntidad> ConsultarPedido(PedidoEntidad entidad);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ModificarEstadoPedido", ResponseFormat = WebMessageFormat.Json)]
        ResponseWeb ModificarEstadoPedido(PedidoEntidad entidad);



    }
}
