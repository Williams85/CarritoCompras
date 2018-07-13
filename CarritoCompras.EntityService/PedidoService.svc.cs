using CarritoCompras.Entidad;
using CarritoCompras.EntityService.MCS;
using CarritoCompras.EntityService.MTS;
using CarritoCompras.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarritoCompras.EntityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PedidoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PedidoService.svc or PedidoService.svc.cs at the Solution Explorer and start debugging.
    public class PedidoService : IPedidoService
    {

        public ResponseWeb GuardarPedido(PedidoEntidad entidad)
        {
            MacroTransaccionServiceClient proxy = new MacroTransaccionServiceClient();
            return proxy.RegistrarPedido(entidad);
        }


        public List<PedidoEntidad> ConsultarPedido(PedidoEntidad entidad)
        {
            MacroConsultaServiceClient proxy = new MacroConsultaServiceClient();
            return proxy.ObtenerPedido(entidad);
        }

        public ResponseWeb ModificarPedido(PedidoEntidad entidad)
        {
            MacroTransaccionServiceClient proxy = new MacroTransaccionServiceClient();
            return proxy.ActualizarPedido(entidad);
        }
    }
}
