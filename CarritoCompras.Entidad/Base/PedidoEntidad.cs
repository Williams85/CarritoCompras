using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Entidad
{
    public partial class PedidoEntidad
    {
        public int Cod_Pedido { get; set; }
        public string Num_Pedido { get; set; }
        public ClienteEntidad Cliente { get; set; }
        public MedioPagoEntidad MedioPago { get; set; }
        public EstadoPedidoEntidad EstadoPedido { get; set; }
        public string Dir_Entrega { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public double Total_Neto { get; set; }
        public List<DetallePedidoEntidad> DetallePedido { get; set; }
    }
}
