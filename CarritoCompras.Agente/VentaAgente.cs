using CarritoCompras.Agente.VS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Agente
{
    public class VentaAgente
    {
        public List<CategoriaEntidad> ListarCategoria()
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            return proxy.ListarCategoria();
        }
        public List<ProductoEntidad> BuscarProducto(int id)
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            return proxy.BuscarProducto(new ProductoEntidad
            {
                Categoria = new CategoriaEntidad
                {
                    Cod_Categoria = id
                }
            });
        }

        public ResponseWeb ReservarProducto(ProductoEntidad entidad)
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            return proxy.ReservarProducto(entidad);
        }

        public List<DetallePedidoEntidad> BuscarDetallePedido()
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            return proxy.BuscarDetallePedido();
        }

        public List<MedioPagoEntidad> ListarMediosPago()
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            return proxy.ListarMediosPago();
        }

        public ResponseWeb GrabarVenta(PedidoEntidad entidad)
        {
            VS.VentaServiceClient proxy = new VS.VentaServiceClient();
            entidad.DetallePedido = proxy.BuscarDetallePedido();
            entidad.Total_Neto = entidad.DetallePedido.Sum(x => x.SubTotal);
            return proxy.GrabarVenta(entidad);
        }

    }
}
