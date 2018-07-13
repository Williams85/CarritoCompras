using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Testing
{
    public class PedidoEntity
    {
        public int Cod_Pedido { get; set; }
        public string Num_Pedido { get; set; }
        public ClienteEntity Cliente { get; set; }
        public MedioPagoEntity MedioPago { get; set; }
        public string Dir_Entrega { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public double Total_Neto { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
    }
}
