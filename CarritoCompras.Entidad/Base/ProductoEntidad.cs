using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Entidad
{
    public class ProductoEntidad
    {
        public int Cod_Producto { get; set; }
        public string Nom_Producto { get; set; }
        public CategoriaEntidad Categoria { get; set; }
        public UnidadMedidaEntidad UnidadMedida { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public string Foto { get; set; }
        public bool Estado { get; set; }
    }
}
