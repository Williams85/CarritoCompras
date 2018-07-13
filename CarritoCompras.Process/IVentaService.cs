using System.Collections.Generic;
using System.ServiceModel;

namespace CarritoCompras.Process
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVentaService" in both code and config file together.
    [ServiceContract]
    public interface IVentaService
    {
        [OperationContract]
        List<CPS.CategoriaEntidad> ListarCategoria();

        [OperationContract]
        List<PDS.ProductoEntidad> BuscarProducto(PDS.ProductoEntidad entidad);

        [OperationContract]
        PDS.ResponseWeb ReservarProducto(PDS.ProductoEntidad entidad);

        [OperationContract]
        List<DPS.DetallePedidoEntidad> BuscarDetallePedido();

        [OperationContract]
        List<MPS.MedioPagoEntidad> ListarMediosPago();

        [OperationContract]
        PDS.ResponseWeb GrabarVenta(PS.PedidoEntidad entidad);

    }
}
