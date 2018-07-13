using CarritoCompras.Process.PS;
using CarritoCompras.Process.US;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarritoCompras.Process
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdministracionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdministracionService.svc or AdministracionService.svc.cs at the Solution Explorer and start debugging.
    public class AdministracionService : IAdministracionService
    {

        public UsuarioEntidad ValidarUsuario(UsuarioEntidad entidad)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();
            return proxy.ValidarUsuario(entidad);
        }

        public List<PedidoEntidad> ConsultarPedido(PedidoEntidad entidad)
        {
            PedidoServiceClient proxy = new PedidoServiceClient();
            return proxy.ConsultarPedido(entidad);
        }

        public ResponseWeb ModificarEstadoPedido(PedidoEntidad entidad)
        {
            PedidoServiceClient proxy = new PedidoServiceClient();
            return proxy.ModificarPedido(entidad);
        }
    }
}
