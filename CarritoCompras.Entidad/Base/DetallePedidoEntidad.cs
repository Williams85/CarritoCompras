using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Entidad
{
    public partial class DetallePedidoEntidad
    {
        public int Cod_DetallePedido { get; set; }
        public int Cod_Pedido { get; set; }
        public ProductoEntidad Producto { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
    }
}
