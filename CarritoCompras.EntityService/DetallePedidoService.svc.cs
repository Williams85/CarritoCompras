using CarritoCompras.Entidad;
using CarritoCompras.EntityService.MCS;
using CarritoCompras.EntityService.MTS;
using System.Collections.Generic;

namespace CarritoCompras.EntityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DetallePedidoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DetallePedidoService.svc or DetallePedidoService.svc.cs at the Solution Explorer and start debugging.
    public class DetallePedidoService : IDetallePedidoService
    {

        public List<DetallePedidoEntidad> BuscarDetallePedido()
        {
            MacroConsultaServiceClient proxy = new MacroConsultaServiceClient();
            return proxy.ObtenerDetallePedido();
        }
    }
}
