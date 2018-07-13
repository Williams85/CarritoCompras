using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarritoCompras.Process
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VentaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select VentaService.svc or VentaService.svc.cs at the Solution Explorer and start debugging.
    public class VentaService : IVentaService
    {

        public List<CPS.CategoriaEntidad> ListarCategoria()
        {
            CPS.CategoriaProductoServiceClient proxy = new CPS.CategoriaProductoServiceClient();
            return proxy.ListarCategoria();
        }

        public List<PDS.ProductoEntidad> BuscarProducto(PDS.ProductoEntidad entidad)
        {
            PDS.ProductoServiceClient proxy = new PDS.ProductoServiceClient();
            return proxy.BuscarProducto(entidad);
        }

        public PDS.ResponseWeb ReservarProducto(PDS.ProductoEntidad entidad)
        {
            PDS.ProductoServiceClient proxy = new PDS.ProductoServiceClient();
            return proxy.ReservarProducto(entidad);
        }


        public List<DPS.DetallePedidoEntidad> BuscarDetallePedido()
        {
            DPS.DetallePedidoServiceClient proxy = new DPS.DetallePedidoServiceClient();
            return proxy.BuscarDetallePedido();
        }


        public List<MPS.MedioPagoEntidad> ListarMediosPago()
        {
            MPS.MedioPagoServiceClient proxy = new MPS.MedioPagoServiceClient();
            return proxy.ListarMediosPago();
        }


        public PDS.ResponseWeb GrabarVenta(PS.PedidoEntidad entidad)
        {
            var cliente = entidad.Cliente;
            CLIS.ClienteEntidad objCliente = new CLIS.ClienteEntidad();
            objCliente.Nom_Cliente = cliente.Nom_Cliente;
            objCliente.Ema_Cliente = cliente.Ema_Cliente;

            PDS.ResponseWeb oResponseWeb = new PDS.ResponseWeb();
            CLIS.ClienteServiceClient proxyCliente = new CLIS.ClienteServiceClient();
            PS.PedidoServiceClient proxyPedido = new PS.PedidoServiceClient();
            var client = proxyCliente.BuscarCliente(objCliente);
            if (client != null)
            {
                objCliente.Cod_Cliente = client.Cod_Cliente;
                var response = proxyCliente.ActualizarCliente(objCliente);
                oResponseWeb.Estado = response.Estado;
            }
            else
            {
                var response = proxyCliente.GuardarCliente(objCliente);
                oResponseWeb.Estado = response.Estado;
            }
            if (oResponseWeb.Estado)
            {
                client = proxyCliente.BuscarCliente(objCliente);
                entidad.Cliente.Cod_Cliente = client.Cod_Cliente;
                entidad.Cliente.Nom_Cliente = client.Nom_Cliente;
                entidad.Cliente.Ema_Cliente = client.Ema_Cliente;
                var response = proxyPedido.GuardarPedido(entidad);
                if (response.Estado)
                {
                    oResponseWeb.Message = "Se grabó la venta";
                    oResponseWeb.Estado = true;
                }
                else
                {
                    oResponseWeb.Estado = false;
                    if (string.IsNullOrWhiteSpace(response.Message))
                        oResponseWeb.Message = "No se grabó la venta";
                    else
                        oResponseWeb.Message = response.Message;
                }
            }
            return oResponseWeb;
        }
    }
}
