using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Entidad
{
    public partial class PedidoEntidad
    {
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string FechaPedido { get { return this.Fecha_Pedido.ToString("dd/MM/yyyy"); } }
        public string FechaEntrega { get { return this.Fecha_Entrega.ToString("dd/MM/yyyy"); } }

    }
}
